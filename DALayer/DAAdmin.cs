using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BOLayer;

namespace DALayer
{
    public class DAAdmin
    {
        public BOAdmin SelectLoginUsers(string Event, string username, string password)
        {
            BOAdmin _boadmin = new BOAdmin();
            SqlCommand _sqlcommond;
            SqlDataAdapter _sqldataadapter;

            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_AdminLogin";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@username", username);
                _sqlcommond.Parameters.AddWithValue("@password", password);
                _sqlcommond.Parameters.AddWithValue("@Event", Event);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();
                _boadmin = (from list in _datatable.AsEnumerable()
                            select new BOAdmin
                            {
                                AdminId = list.Field<int>("AdminId"),
                                UserName = list.Field<string>("UserName"),
                                Password = list.Field<string>("Password")
                            }).FirstOrDefault();
                return _boadmin;
            }

        }
    }
}
