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

        internal int ChangePassowrd(string eventtxt, BOAdminLogin _boadmin)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_AdminLogin";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@AdminId", _boadmin.AdminId);
                _sqlcommand.Parameters.AddWithValue("@UserName", _boadmin.UserName);
                _sqlcommand.Parameters.AddWithValue("@Password", _boadmin.Password);
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch (Exception ex)
                {
                    Common.LogError(ex);
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommand.Dispose();
                }
            }
            return returnvalue;
        }
    }
}