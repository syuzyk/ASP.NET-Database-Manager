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
        public static List<string> GetSuppliers(string prodName)
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
    }
}
