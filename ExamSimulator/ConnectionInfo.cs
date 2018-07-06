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
                SqlConnection _con = new SqlConnection("Data Source = 204.44.96.22, 1433; Initial Catalog = xexam; User ID = xcert; Password = xcert123;");
                // SqlConnection _con = new SqlConnection("Data Source=MWM43\\SQLEXPRESS;Initial Catalog=xexam;Integrated Security=True");
                return _con;
            }
            catch
            {
                throw;
            }
        }
    }
}
