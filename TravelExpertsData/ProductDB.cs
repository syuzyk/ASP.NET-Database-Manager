using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductDB
    {
        public static List<string> GetProducts()
        {
            List<string> productsList = new List<string>();

            productsList.Add("");

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string query = "SELECT ProdName " +
                               "FROM Products " + 
                               "ORDER BY ProdName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            string prodName = (string)dr["ProdName"];

                            productsList.Add(prodName);
                        }
                    }
                }
            }

            return productsList;
        }
    }
}
