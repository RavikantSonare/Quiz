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
    public class DAMerchantLevel
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;
        public int IUDMerchantLevel(BOMerchantLevel _bomerlvl)
        {
            int returnValue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDMerchantLevel";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantLevelId", _bomerlvl.MerchantLevelId);
                _sqlcommand.Parameters.AddWithValue("@MerchantLevel", _bomerlvl.MerchantLevel);
                _sqlcommand.Parameters.AddWithValue("@AnnualFee", _bomerlvl.AnnualFee);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bomerlvl.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bomerlvl.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bomerlvl.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bomerlvl.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdateBy", _bomerlvl.UpdateBy);
                _sqlcommand.Parameters.AddWithValue("@UpdateDate", _bomerlvl.UpdateDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bomerlvl.Event);
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
                _sqlcommand.CommandText = "SP_GetMerchantLevel";
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

        internal DataTable SelectMerchantLevelWithID(string v, int mlvlId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantLevel";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@MerchantLevelId", mlvlId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable2 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable2);
                _sqlconnection.Close();
                return _dataTable2;
            }
        }
    }
}