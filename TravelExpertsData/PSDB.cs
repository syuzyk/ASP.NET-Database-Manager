using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
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
    }
}
