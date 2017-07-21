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
    public class DAPaymentOption
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable PaymentOptionList(string v)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetPaymentOption";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }
    }
}