using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ExamSimulator
{
    class ConnectionInfo
    {
        public static SqlConnection GetConnection()
        {
            try
            {
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
