using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BOLayer;

namespace DesktopMerchant.DALayer
{
    class DAMyUser
    {
        public int IUDMyUser(BOMyUser _bomyuser)
        {
            int returnValue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDMyUser";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@UserId", _bomyuser.UserId);
                _sqlcommnd.Parameters.AddWithValue("@UserName", _bomyuser.UserName);
                _sqlcommnd.Parameters.AddWithValue("@AccessPassword", _bomyuser.AccessPassword);
                _sqlcommnd.Parameters.AddWithValue("@MerchantId", _bomyuser.MerchantId);
                _sqlcommnd.Parameters.AddWithValue("@SecondCategoryId", _bomyuser.SecondCategoryId);
                _sqlcommnd.Parameters.AddWithValue("@ExamId", _bomyuser.ExamId);
                _sqlcommnd.Parameters.AddWithValue("@ExamCode", _bomyuser.ExamCode);
                _sqlcommnd.Parameters.AddWithValue("@ValidTime", _bomyuser.ValidTime);
                _sqlcommnd.Parameters.AddWithValue("@AccessOption", _bomyuser.AccessOption);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", _bomyuser.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@IsDelete", _bomyuser.IsDelete);
                _sqlcommnd.Parameters.AddWithValue("@CreatedBy", _bomyuser.CreatedBy);
                _sqlcommnd.Parameters.AddWithValue("@CreatedDate", _bomyuser.CreatedDate);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", _bomyuser.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", _bomyuser.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bomyuser.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch (Exception ex)
                {
                    // returnValue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnValue;
        }

        internal List<BOMyUser> SelectUserDetail(BOMyUser _bomyuser)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMyUser";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bomyuser.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@Event", _bomyuser.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOMyUser> _merfr = (from cu in _dataTable.AsEnumerable()
                                         select new BOMyUser
                                         {
                                             UserId = cu.Field<int>("UserId"),
                                             UserName = cu.Field<string>("UserName"),
                                             AccessPassword = cu.Field<string>("AccessPassword"),
                                             SecondCategory = cu.Field<string>("SecondCategoryName"),
                                             ExamCode = cu.Field<string>("ExamCode"),
                                             ValidTime = cu.Field<int>("ValidTime"),
                                             AccessOption = cu.Field<string>("AccessOption")
                                         }).ToList();

                return _merfr;
            }
        }
    }
}
