
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace finnit
{
    public static class MyConnection
    {
        public static string DefaultConnection { get; set; }
    }
    public static class APIMaster
    {
        public static string RootPath { get; set; }
    }
    public static class SmsMaster
    {
        public static string Url { get; set; }
    }

    public class EmailMaster
    {
        public static string HostServer { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static bool EnableSsl { get; set; }
        public static int Port { get; set; }
    }

    public class ORMConnection
    {
        private static SqlConnection con;
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection(MyConnection.DefaultConnection);
            return con;
        }
    }
}
