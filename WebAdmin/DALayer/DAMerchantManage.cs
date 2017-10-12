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
    public class DAMerchantManage
    {
        public DataTable SelectMerchantManage(string eventtxt)
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
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _con.Close();
                return _dataTable;
            }
        }

        public DataTable SelectMerchantManageWithId(string eventtxt, int merchantid)
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
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", merchantid);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _con.Close();
                return _dataTable;
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
                _sqlcommnd.Parameters.AddWithValue("@MerchantName", _bomermng.MerchantName);
                _sqlcommnd.Parameters.AddWithValue("@Telephone", _bomermng.Telephone);
                _sqlcommnd.Parameters.AddWithValue("@EmailId", _bomermng.EmailId);
                _sqlcommnd.Parameters.AddWithValue("@Password", _bomermng.Password);
                _sqlcommnd.Parameters.AddWithValue("@MerchantLevelId", _bomermng.MerchantLevelId);
                _sqlcommnd.Parameters.AddWithValue("@ActiveStatus", _bomermng.ActiveStatus);
                _sqlcommnd.Parameters.AddWithValue("@StartDate", _bomermng.StartDate);
                _sqlcommnd.Parameters.AddWithValue("@EndDate", _bomermng.EndDate);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", _bomermng.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", _bomermng.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bomermng.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch (Exception ex)
                {
                    Common.LogError(ex);
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnValue;
        }

        public int UpdateStatus(BOMerchantManage _bomermng)
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
                catch (Exception ex)
                {
                    Common.LogError(ex);
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnValue;
        }

        public int UpdateMerchantLevel(BOMerchantManage _bomermng)
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
                _sqlcommnd.Parameters.AddWithValue("@MerchantLevelId", _bomermng.MerchantLevelId);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", _bomermng.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", _bomermng.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bomermng.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch (Exception ex)
                {
                    Common.LogError(ex);
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