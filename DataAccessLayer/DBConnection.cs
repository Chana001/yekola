using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBConnection
    {
        internal static SqlConnection GetConnection()
        {
            var connString = @"Data Source=localhost;Initial Catalog=yekolaDB;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
