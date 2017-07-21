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
    public class DASalesReports
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;
        internal DataTable SelectSalesReport(string v, int mid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSalesReports";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                return _datatable;
            }
        }
    }
}