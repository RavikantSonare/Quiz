using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin.DALayer
{
    public class DAAdminLogin
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        DataTable _datatable;
        internal BOAdminLogin SelectAdminDetail(string eventtxt, string username, string password)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_AdminLogin";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@UserName", username);
                _sqlcommand.Parameters.AddWithValue("@Password", password);
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                BOAdminLogin _boAdmin = new BOAdminLogin();
                _boAdmin = (from list in _datatable.AsEnumerable()
                            select new BOAdminLogin
                            {
                                AdminId = list.Field<int>("AdminId"),
                                UserName = list.Field<string>("UserName"),
                                Password = list.Field<string>("Password")
                            }).FirstOrDefault();
                return _boAdmin;
            }
        }
    }
}