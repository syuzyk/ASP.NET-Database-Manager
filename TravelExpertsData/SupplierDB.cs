using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class SupplierDB
    {
        /// <summary>
        /// Generates custom list of Supplier Names.
        /// Begins with names of suppliers that provide a given product.
        /// Then proceeds with names of suppliers that do NOT provide that product.
        /// </summary>
        /// <param name="prodName"></param>
        /// <returns>List of supplier names.</returns>
        public static List<string> GetSuppliersForPPS(string prodName)
        {
            List<string> supplierList = new List<string>();

            supplierList.Add("");

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT Suppliers.SupName " +
                               "FROM Products_Suppliers " +
                               "JOIN Suppliers ON Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                               "JOIN Products ON Products_Suppliers.ProductId = Products.ProductId " +
                               "WHERE ProdName = '" + prodName + "' " + 
                               "ORDER BY Suppliers.SupName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            string supName = (string)dr["SupName"];

                            supplierList.Add(supName);
                        }
                    }
                }
            }

            supplierList.Add("");
            supplierList.Add("----------");
            supplierList.Add("");

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT Suppliers.SupName " +
                               "FROM Suppliers " +
                               "WHERE SupName NOT IN (" +
                                    "SELECT Suppliers.SupName " +
                                    "FROM Products_Suppliers " +
                                        "JOIN Suppliers ON Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                                        "JOIN Products ON Products_Suppliers.ProductId = Products.ProductId " +
                                        "WHERE ProdName = '" + prodName + "') " +
                               "ORDER BY Suppliers.SupName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            string supName = (string)dr["SupName"];

                            supplierList.Add(supName);
                        }
                    }
                }
            }

            return supplierList;
        }

        /// <summary>
        /// Generates a list of supplier names.
        /// </summary>
        /// <returns>List of supplier names.</returns>
        public static List<string> GetAllSuppliers()
        {
            List<string> suppliersList = new List<string>();

            suppliersList.Add("");

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT SupName " +
                               "FROM Suppliers " +
                               "ORDER BY SupName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            string supplierName = (string)dr["SupName"];

                            suppliersList.Add(supplierName);
                        }
                    }
                }
            }

            return suppliersList;
        }
    }
}
