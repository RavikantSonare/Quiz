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
    public class DAMasterState
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;
        internal DataTable GetStatelist(string v, string countryid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetState";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@CountryId", countryid);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable1 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable1);
                _sqlconnection.Close();
                return _dataTable1;
            }
        }
    }
}