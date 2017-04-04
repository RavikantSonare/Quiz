using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BOLayer;

namespace DALayer
{
    public class DAMerchantFeeRate
    {
        public int IUDMerchantLevel(BOMerchantFeeRate _bomerfr)
        {
            int returnValue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDMerchantFeeRate";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@MerchantFeeRateId", _bomerfr.MerchantFeeRateId);
                _sqlcommnd.Parameters.AddWithValue("@MerchantFeeRate", _bomerfr.MerchantFeeRate);
                _sqlcommnd.Parameters.AddWithValue("@MerchantLevelId", _bomerfr.MerchantLevelId);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", _bomerfr.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@IsDelete", _bomerfr.IsDelete);
                _sqlcommnd.Parameters.AddWithValue("@CreatedBy", _bomerfr.CreatedBy);
                _sqlcommnd.Parameters.AddWithValue("@CreatedDate", _bomerfr.CreatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Updateby", _bomerfr.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdateDate", _bomerfr.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bomerfr.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnValue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnValue;
        }

        public List<BOMerchantFeeRate> SelectMerchantLevelList(BOMerchantFeeRate _bomerfr)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantFeeRate";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _bomerfr.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOMerchantFeeRate> _merfr = (from cu in _dataTable.AsEnumerable()
                                                  select new BOMerchantFeeRate
                                                  {
                                                      MerchantFeeRateId = cu.Field<int>("MerchantFeeRateId"),
                                                      MerchantFeeRate = cu.Field<int>("MerchantFeeRate"),
                                                      MerchantLevelId = cu.Field<int>("MerchantLevelId"),
                                                      MerchantLevel = cu.Field<string>("MerchantLevel")
                                                  }).ToList();

                _con.Close();
                return _merfr;
            }
        }
    }
}
