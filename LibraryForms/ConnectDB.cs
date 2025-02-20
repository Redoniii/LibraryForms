using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace LibraryForms
{
    internal class ConnectDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
