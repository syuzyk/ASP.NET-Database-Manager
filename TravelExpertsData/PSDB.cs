using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    //All code here written by Ricky.
    
    public class PSDB
    {
        /// <summary>
        /// Checks whether the provided combination of product and supplier already exists
        /// in the Products_Suppliers table.  
        /// Purposes:
        /// - prevent duplicates in Products_Suppliers.
        /// - can't add a package to Packages_Products_Suppliers until it exists in
        ///   Products_Suppliers
        /// </summary>
        /// <param name="prodName">Product name to check</param>.
        /// <param name="supName">Supplier name to check</param>.
        /// <returns>True if exists, false if not.</returns>
        public static bool recordExistsInPS(string prodName, string supName)
        {
            int recordCount;
            bool exists;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT COUNT (*) FROM Products_Suppliers " +
                               "WHERE ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
                               "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "')";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    cmd.CommandText = query;
                    recordCount = (int)cmd.ExecuteScalar();

                    if (recordCount == 0)
                        exists = false;
                    else
                        exists = true;
                }
            }

            return exists;
        }

        /// <summary>
        /// Adds a product to Products_Suppliers.
        /// </summary>
        /// <param name="prodName">Name of product to add.</param>
        /// <param name="supName">That product's supplier.</param>
        /// <returns>True if successfully added, false if not.</returns>
        public static bool addToPSThenConfirmSuccess(string prodName, string supName)
        {
            bool successfullyAdded;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement = "INSERT INTO Products_Suppliers " +
                                         "OUTPUT INSERTED.ProductId " + 
                                         "VALUES (" +
                                         "(SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "'), " +
                                         "(SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "'))";

                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    connection.Open();

                    if (cmd.ExecuteNonQuery() == 1)
                        successfullyAdded = true;
                    else
                        successfullyAdded = false;
                }
            }

            return successfullyAdded;
        }

        /// <summary>
        /// Generates all product-supplier combinations.
        /// </summary>
        /// <param name="packageId">Package's package ID</param>
        /// <returns>List of product names and supplier names.</returns>
        public static List<PS> GetPS(string prodNameCondition, string supNameCondition)
        {
            PS ps;

            List<PS> psList = new List<PS>();

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT * " +
                               "FROM Products_Suppliers " +
                                   "JOIN Products ON Products_Suppliers.ProductId = Products.ProductId " +
                                   "JOIN Suppliers ON Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                               "WHERE Products.ProductId > 0" + prodNameCondition + supNameCondition + 
                               "ORDER BY Products.ProdName, Suppliers.SupName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            ps = new PS();

                            ps.ProdName = (string)dr["ProdName"];
                            ps.SupName = (string)dr["SupName"];

                            psList.Add(ps);
                        }
                    }
                }
            }

            return psList;
        }

        /// <summary>
        /// Delete's a record in Products_Suppliers
        /// </summary>
        /// <param name="prodName">Product name of target record</param>
        /// <param name="supName">Supplier name of target record</param>
        /// <returns>True if delete successful, false if not.</returns>
        public static bool DeletePSThenConfirm(string prodName, string supName)
        {
            bool successfullyDeleted;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string deleteStatement = "DELETE FROM Products_Suppliers " +
                                         "WHERE ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
                                         "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "')";

                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                        successfullyDeleted = true;
                    else
                        successfullyDeleted = false;
                }
            }

            return successfullyDeleted;
        }

        /// <summary>
        /// Checks if a specific product-supplier combination already exists.
        /// Purpose is to prevent duplicates.
        /// </summary>
        /// <param name="packageId">Package ID of the package we are checking.</param>
        /// <param name="prodName">Product name of the package we are checking.</param>
        /// <param name="supName">Supplier name of the package we are checking.</param>
        /// <returns>True if record exists, false if not.</returns>
        public static bool recordAlreadyExistsInPS(string prodName, string supName)
        {
            int recordCount;
            bool alreadyExists;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT COUNT (*) FROM Products_Suppliers " +
                               "WHERE ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
                                     "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "')";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    cmd.CommandText = query;
                    recordCount = (int)cmd.ExecuteScalar();

                    if (recordCount == 0)
                        alreadyExists = false;
                    else
                        alreadyExists = true;
                }
            }

            return alreadyExists;
        }

        /// <summary>
        /// Updates a record in Products_Suppliers.
        /// </summary>
        /// <param name="packageId">Package ID of the record we are updating.</param>
        /// <param name="oldProdName">The original Product Name of the record we are updating.</param>
        /// <param name="oldSupName">The original Supplier Name of the record we are updating.</param>
        /// <param name="newProdName">The new Product Name  of the record we are updating.</param>
        /// <param name="newSupName">The new Supplier Name of the record we are updating.</param>
        /// <returns>True if successfully updated, false if not.</returns>
        public static bool UpdatePSThenConfirmSuccess(string oldProdName, string oldSupName, string newProdName, string newSupName)
        {
            bool successfullyUpdated;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Products_Suppliers " +
                                         "SET " +
                                             "ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + newProdName + "'), " +
                                             "SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + newSupName + "') " +
                                         "WHERE ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + oldProdName + "') " +
                                               "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + oldSupName + "')";

                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    connection.Open();

                    if (cmd.ExecuteNonQuery() == 1)
                        successfullyUpdated = true;
                    else
                        successfullyUpdated = false;
                }
            }

            return successfullyUpdated;
        }
    }
}
