using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    //All code here written by Ricky.

    public class PPSDB
    {
        /// <summary>
        /// Generates a package's product information.
        /// </summary>
        /// <param name="packageId">Package's package ID</param>
        /// <returns>List of product names and supplier names.</returns>
        public static List<PS> GetPPSWithPackageId(int packageId)
        {
            PS ps;

            List<PS> psList = new List<PS>();

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT Products.ProdName, Suppliers.SupName " +
                               "FROM Packages_Products_Suppliers " +
                                   "JOIN Products ON Packages_Products_Suppliers.ProductId = Products.ProductId " +
                                   "JOIN Suppliers ON Packages_Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                               "WHERE PackageId = " + packageId.ToString();

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
        /// Generates packages with a specific product and supplier.
        /// </summary>
        /// <param name="packageId">Package's package ID</param>
        /// <returns>List of product names and supplier names.</returns>
        public static List<PPS> GetPPSWithPS(string prodName, string supName)
        {
            PPS pps;

            List<PPS> ppsList = new List<PPS>();

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT PkgName, ProdName, SupName " +
                               "FROM Packages_Products_Suppliers " +
                                    "JOIN Products ON Packages_Products_Suppliers.ProductId = Products.ProductId " +
                                    "JOIN Suppliers ON Packages_Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                                    "JOIN Packages ON Packages_Products_Suppliers.PackageId = Packages.PackageId " +
                               "WHERE Products.ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
                               "AND Suppliers.SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "') " +
                               "ORDER BY Packages.PackageId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            pps = new PPS();

                            pps.PkgName = (string)dr["PkgName"];
                            pps.ProdName = (string)dr["ProdName"];
                            pps.SupName = (string)dr["SupName"];

                            ppsList.Add(pps);
                        }
                    }
                }
            }

            return ppsList;
        }

        /// <summary>
        /// Delete's a record in Packages_Products_Suppliers
        /// </summary>
        /// <param name="packageId">Package ID of target record</param>
        /// <param name="prodName">Product name of target record</param>
        /// <param name="supName">Supplier name of target record</param>
        /// <returns>True if delete successful, false if not.</returns>
        public static bool DeletePPSWithPackageIdThenConfirm(int packageId, string prodName, string supName)
        {
            bool successfullyDeleted;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string deleteStatement = "DELETE FROM Packages_Products_Suppliers " +
                                         "WHERE PackageId = " + packageId.ToString() +
                                         "AND ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
                                         "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "')";

                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        successfullyDeleted = true;
                    else
                        successfullyDeleted = false;
                }
            }

            return successfullyDeleted;
        }

        /// <summary>
        /// Delete's a record in Packages_Products_Suppliers
        /// </summary>
        /// <param name="packageId">Package ID of target record</param>
        /// <param name="prodName">Product name of target record</param>
        /// <param name="supName">Supplier name of target record</param>
        /// <returns>True if delete successful, false if not.</returns>
        public static bool DeletePPSWithPSThenConfirm(string prodName, string supName)
        {
            bool successfullyDeleted;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string deleteStatement = "DELETE FROM Packages_Products_Suppliers " +
                                         "WHERE ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
                                         "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + supName + "')";

                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                        successfullyDeleted = true;
                    else
                        successfullyDeleted = false;
                }
            }

            return successfullyDeleted;
        }

        /// <summary>
        /// Checks if a specific product-supplier combination already exists in a package.
        /// Purpose is to prevent duplicates.
        /// </summary>
        /// <param name="packageId">Package ID of the package we are checking.</param>
        /// <param name="prodName">Product name of the package we are checking.</param>
        /// <param name="supName">Supplier name of the package we are checking.</param>
        /// <returns>True if record exists, false if not.</returns>
        public static bool recordAlreadyExistsInPPS(int packageId, string prodName, string supName)
        {
            int recordCount;
            bool alreadyExists;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT COUNT (*) FROM Packages_Products_Suppliers " +
                               "WHERE PackageId = " + packageId.ToString() + " " + 
                               "AND ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + prodName + "') " +
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
        /// Adds a record to Packages_Products_Suppliers
        /// </summary>
        /// <param name="packageId">PackageID of the record we are adding.</param>
        /// <param name="prodName">Product Name of the record we are adding.</param>
        /// <param name="supName">SupplierID of the record we are adding.</param>
        /// <returns>True if successfully added, false if not.</returns>
        public static bool addToPPSThenConfirmSuccess(int packageId, string prodName, string supName)
        {
            bool successfullyAdded;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string insertStatement = "INSERT INTO Packages_Products_Suppliers " +
                                         "OUTPUT INSERTED.PackageId " + 
                                         "VALUES (" + packageId.ToString() + ", " + 
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
        /// Updates a record in Packages_Products_Suppliers.
        /// </summary>
        /// <param name="packageId">Package ID of the record we are updating.</param>
        /// <param name="oldProdName">The original Product Name of the record we are updating.</param>
        /// <param name="oldSupName">The original Supplier Name of the record we are updating.</param>
        /// <param name="newProdName">The new Product Name  of the record we are updating.</param>
        /// <param name="newSupName">The new Supplier Name of the record we are updating.</param>
        /// <returns>True if successfully updated, false if not.</returns>
        public static bool UpdatePPSThenConfirmSuccess(int packageId, string oldProdName, string oldSupName, string newProdName, string newSupName)
        {
            bool successfullyUpdated;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Packages_Products_Suppliers " +
                                         "SET " +
                                             "ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + newProdName + "'), " +
                                             "SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + newSupName + "') " +
                                         "WHERE PackageId = " + packageId + " " +
                                         "AND ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + oldProdName + "') " +
                                         "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + oldSupName + "')";

                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    connection.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        successfullyUpdated = true;
                    else
                        successfullyUpdated = false;
                }
            }

            return successfullyUpdated;
        }

        /// <summary>
        /// Updates several records in Packages_Products_Suppliers.
        /// </summary>
        /// <param name="oldProdName">The original Product Name of the records we are updating.</param>
        /// <param name="oldSupName">The original Supplier Name of the records we are updating.</param>
        /// <param name="newProdName">The new Product Name  of the records we are updating.</param>
        /// <param name="newSupName">The new Supplier Name of the records we are updating.</param>
        /// <returns>True if successfully updated, false if not.</returns>
        public static bool UpdatePPSWithPSThenConfirmSuccess(string oldProdName, string oldSupName, string newProdName, string newSupName)
        {
            bool successfullyUpdated;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement = "UPDATE Packages_Products_Suppliers " +
                                         "SET " +
                                             "ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + newProdName + "'), " +
                                             "SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + newSupName + "') " +
                                         "WHERE ProductId = (SELECT ProductId FROM Products WHERE ProdName = '" + oldProdName + "') " +
                                         "AND SupplierId = (SELECT SupplierId FROM Suppliers WHERE SupName = '" + oldSupName + "')";

                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    connection.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        successfullyUpdated = true;
                    else
                        successfullyUpdated = false;
                }
            }

            return successfullyUpdated;
        }
    }
}
