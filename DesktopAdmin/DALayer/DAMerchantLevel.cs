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
    public class DAMerchantLevel
    {
        public int IUDMerchantLevel(BOMerchantLevel _bomerlvl)
        {
            int returnValue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDMerchantLevel";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@MerchantLevelId", _bomerlvl.MerchantLevelId);
                _sqlcommnd.Parameters.AddWithValue("@MerchantLevel", _bomerlvl.MerchantLevel);
                _sqlcommnd.Parameters.AddWithValue("@AnnualFee", _bomerlvl.AnnualFee);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", _bomerlvl.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@IsDelete", _bomerlvl.IsDelete);
                _sqlcommnd.Parameters.AddWithValue("@CreatedBy", _bomerlvl.CreatedBy);
                _sqlcommnd.Parameters.AddWithValue("@CreatedDate", _bomerlvl.CreatedDate);
                _sqlcommnd.Parameters.AddWithValue("@UpdateBy", _bomerlvl.UpdateBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdateDate", _bomerlvl.UpdateDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bomerlvl.Event);
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

        public List<BOMerchantLevel> SelectMerchantLevelList(BOMerchantLevel _bomerlvl)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantLevel";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _bomerlvl.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOMerchantLevel> _merlvl = (from cu in _dataTable.AsEnumerable()
                                                 select new BOMerchantLevel
                                                 {
                                                     MerchantLevelId = cu.Field<int>("MerchantLevelId"),
                                                     MerchantLevel = cu.Field<string>("MerchantLevel"),
                                                     AnnualFee = cu.Field<decimal>("AnnualFee")
                                                 }).ToList();

                _con.Close();
                return _merlvl;
            }
        }
    }
}
