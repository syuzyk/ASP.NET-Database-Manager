using System.Data.SqlClient;

namespace TravelExpertsData
{
    //All code here written by Ricky.
    
    /// <summary>
    /// Establishes Connection to SQL server.
    /// </summary>
    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";

            return new SqlConnection(connectionString);
        }
    }
}
