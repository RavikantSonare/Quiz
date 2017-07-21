using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;
using System.Data;
using System.Data.SqlClient;

namespace WebMerchant.DALayer
{
    public class DATopCategory
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;
        private DataTable _datatable;

        internal DataTable SelectTopCategory(string eventtxt)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTopCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

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