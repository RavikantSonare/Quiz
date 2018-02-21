using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamSimulator
{
    class ConnectionInfo
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
