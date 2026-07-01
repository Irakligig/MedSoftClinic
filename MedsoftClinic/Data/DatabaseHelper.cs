using Microsoft.Data.SqlClient;

namespace MedsoftClinic.Data
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString =
    @"Data Source=Irakli\SQLEXPRESS;Initial Catalog=MedsoftClinic;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}