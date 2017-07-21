using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebAdmin.BOLayer;
using WebAdmin.DALayer;

namespace WebAdmin.DALayer
{
    public class DAMerchantFeeRate
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;
        public int IUDMerchantLevel(BOMerchantFeeRate _bomerfr)
        {
            int returnValue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDMerchantFeeRate";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantFeeRateId", _bomerfr.MerchantFeeRateId);
                _sqlcommand.Parameters.AddWithValue("@MerchantFeeRate", _bomerfr.MerchantFeeRate);
                _sqlcommand.Parameters.AddWithValue("@MerchantLevelId", _bomerfr.MerchantLevelId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bomerfr.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bomerfr.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bomerfr.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bomerfr.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@Updateby", _bomerfr.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdateDate", _bomerfr.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bomerfr.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
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
            return returnValue;
        }

        public DataTable SelectMerchantLevelList(string txtevent)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantFeeRate";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", txtevent);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable1 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable1);
                _sqlconnection.Close();
                return _dataTable1;
            }
        }

        internal DataTable SelectFeeRateWithID(string v, int frateId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantFeeRate";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@MerchantFeeRateId", frateId);
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