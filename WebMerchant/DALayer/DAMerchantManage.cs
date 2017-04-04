using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant.DALayer
{
    public class DAMerchantManage
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        DataTable _datatable;
        internal BOMerchantManage SelectmerchantLogin(string Event, string username, string password)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@username", username);
                _sqlcommand.Parameters.AddWithValue("@password", password);
                _sqlcommand.Parameters.AddWithValue("@Event", Event);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                BOMerchantManage _bomermng = new BOMerchantManage();
                _bomermng = (from list in _datatable.AsEnumerable()
                             select new BOMerchantManage
                             {
                                 MerchantId = list.Field<int>("MerchantId"),
                                 UserName = list.Field<string>("UserName"),
                                 Password = list.Field<string>("Password")
                             }).FirstOrDefault();
                return _bomermng;
            }
        }

        internal DataTable SelectMerchantDetail(string eventtxt, int merchantid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@MerchantId", merchantid);
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }
    }
}