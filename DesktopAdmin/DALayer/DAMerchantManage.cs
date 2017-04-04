using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BOLayer;


namespace DALayer
{
    public class DAMerchantManage
    {
        public List<BOMerchantManage> SelectMerchantManage(BOMerchantManage _bomermng)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantManage";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _bomermng.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOMerchantManage> _merfr = (from cu in _dataTable.AsEnumerable()
                                                 select new BOMerchantManage
                                                 {
                                                     MerchantId = cu.Field<int>("MerchantId"),
                                                     MerchantName = cu.Field<string>("MerchantName"),
                                                     Country = cu.Field<string>("Country"),
                                                     State = cu.Field<string>("State"),
                                                     Telephone = cu.Field<string>("Telephone"),
                                                     MerchantLevel = cu.Field<string>("MerchantLevel"),
                                                     StartDate = cu.Field<DateTime>("StartDate"),
                                                     EndDate = cu.Field<DateTime>("EndDate"),
                                                     ActiveStatus = cu.Field<bool>("ActiveStatus"),
                                                     IsActive = cu.Field<bool>("IsActive")

                                                 }).ToList();
                _con.Close();
                return _merfr;
            }
        }

        public int IUDMerchantManage(BOMerchantManage _bomermng)
        {
            int returnValue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDMerchantManage";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@MerchantId", _bomermng.MerchantId);
                _sqlcommnd.Parameters.AddWithValue("@ActiveStatus", _bomermng.ActiveStatus);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", _bomermng.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", _bomermng.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bomermng.Event);
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
    }
}
