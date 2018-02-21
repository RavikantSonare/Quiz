using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAdmin
{
    public class ConnectionInfo
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["quizconnection"].ConnectionString);
                return _con;
            }
            catch
            {
                throw;
            }
        }
    }
}