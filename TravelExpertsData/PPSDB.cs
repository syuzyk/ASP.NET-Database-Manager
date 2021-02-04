using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PPSDB
    {
        public static List<PPS> GetPPS(int packageId)
        {
            PPS pps;

            List<PPS> ppsList = new List<PPS>();

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
                            pps = new PPS();
                            
                            pps.ProdName = (string)dr["ProdName"];
                            pps.SupName = (string)dr["SupName"];

                            ppsList.Add(pps);
                        }
                    }
                }
            }

            return ppsList;
        }

        public static bool DeletePPSThenConfirm(int packageId, string prodName, string supName)
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
                    if (cmd.ExecuteNonQuery() == 1)
                        successfullyDeleted = true;
                    else
                        successfullyDeleted = false;
                }
            }

            return successfullyDeleted;
        }

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

        public static bool UpdateOrderThenConfirmSuccess(int packageId, string oldProdName, string oldSupName, string newProdName, string newSupName)
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
