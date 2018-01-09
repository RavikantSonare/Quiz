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
    public class DAQuestionType
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataSet SelectQuestionTypelist(string v,int levelid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetQuestionType";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@MerchantLevelId", levelid);

                DataSet _datatable2 = new DataSet();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable2);

                _sqlconnection.Close();

                return _datatable2;
            }
        }
    }
}