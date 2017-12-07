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
    public class DAMyUsers
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;

        internal DataTable SelectUserList(string v, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMyUser";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _sqlconnection.Close();

                return _dataTable;
            }
        }

        internal DataTable SelectUserListWithUID(string v, int userId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMyUser";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@UserId", userId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _sqlconnection.Close();

                return _dataTable;
            }
        }

        internal int IUDUserDetail(BOMyUsers _bomyuser)
        {
            int returnValue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDMyUser";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@UserId", _bomyuser.UserId);
                _sqlcommand.Parameters.AddWithValue("@UserName", _bomyuser.UserName);
                _sqlcommand.Parameters.AddWithValue("@AccessPassword", _bomyuser.AccessPassword);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bomyuser.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@ExamId", _bomyuser.ExamId);
                _sqlcommand.Parameters.AddWithValue("@ExamCode", _bomyuser.ExamCode);
                _sqlcommand.Parameters.AddWithValue("@ValidTime", _bomyuser.ValidTime);
                _sqlcommand.Parameters.AddWithValue("@AccessOption", _bomyuser.AccessOption);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bomyuser.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bomyuser.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bomyuser.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bomyuser.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bomyuser.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _bomyuser.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@ValidTimeTo", _bomyuser.ValidTimeTo);
                _sqlcommand.Parameters.AddWithValue("@Event", _bomyuser.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch (SqlException sqlex)
                { Common.LogError(sqlex); }
                catch (StackOverflowException stackex)
                { Common.LogError(stackex); }
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
    }
}