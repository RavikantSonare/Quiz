using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebMerchant
{
    public class ConnectionInfo
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                //SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["quizconnection"].ConnectionString);
                SqlConnection _con = new SqlConnection("Data Source = 148.72.232.168, 1433; Initial Catalog = mobi96_Quizproject; User ID = QuizprojectUser123; Password = Quizproject@123");
                return _con;
            }
            catch
            {
                throw;
            }
        }
    }
}