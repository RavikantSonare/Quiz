using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebMerchant.DALayer
{
    public class DAUserAccess
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;

        internal DataTable SelectUserAccess(string eventtxt)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetUserAccess";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                _sqlconnection.Close();
                return _dataTable;
            }
        }
    }
}