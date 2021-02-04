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
