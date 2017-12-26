using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant.DALayer
{
    public class DAUserGroup
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;

        internal DataTable SelectGroupDetail(string eventtxt, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetGroup";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _sqlconnection.Close();

                return _dataTable;
            }
        }

        internal DataTable SelectGroupDetailWithGroupID(string v, int groupId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetGroup";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@GroupId", groupId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _sqlconnection.Close();

                return _dataTable;
            }
        }

        internal int IUDGroupDetail(BOUserGroup _bousrgroup)
        {
            int returnValue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDGroup";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@GroupId", _bousrgroup.GroupId);
                _sqlcommand.Parameters.AddWithValue("@GroupName", _bousrgroup.GroupName);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bousrgroup.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@ExamId", _bousrgroup.ExamId);
                _sqlcommand.Parameters.AddWithValue("@AccessOption", _bousrgroup.AccessOption);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bousrgroup.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bousrgroup.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bousrgroup.Createdby);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bousrgroup.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bousrgroup.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _bousrgroup.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bousrgroup.Event);
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