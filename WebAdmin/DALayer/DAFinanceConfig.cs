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
    public class DAFinanceConfig
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable SelectfinanceconfigDetail(string v, int mId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetFinanceConfig";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", mId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                return _datatable;
            }
        }
    }
}