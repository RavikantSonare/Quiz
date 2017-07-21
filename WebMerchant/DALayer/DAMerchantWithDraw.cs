using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;
using WebMerchant.DALayer;

namespace WebMerchant.DALayer
{
    public class DAMerchantWithDraw
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;

        internal DataTable SelectwithDrawDetail(string v, int mid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetWithDrawOrder";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                return _datatable;
            }
        }

        internal int Gerordreno(string v)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetWithDrawOrder";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;
                _sqlcon.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                try
                {
                    returnvalue = Convert.ToInt32(_sqlcommand.ExecuteScalar());
                }
                catch (SqlException sqlex)
                {
                    Common.LogError(sqlex);
                }
                catch (StackOverflowException stackex)
                {
                    Common.LogError(stackex);
                }
                catch (Exception ex)
                {
                    Common.LogError(ex);
                }
                finally
                {
                    _sqlcon.Close();
                    _sqlcommand.Dispose();
                }

            }
            return returnvalue;
        }

        internal int IUD_BoWithDrawManage(BOMerchantWithDraw _bowmng)
        {
            int returnValue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDWithDrawOrderManage";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@WithDrawOrderNo", _bowmng.WithDrawOrderNo);
                _sqlcommnd.Parameters.AddWithValue("@Amount", _bowmng.Amount);
                _sqlcommnd.Parameters.AddWithValue("@MerchantId", _bowmng.MerchantId);
                _sqlcommnd.Parameters.AddWithValue("@OrderStatus", _bowmng.OrderStatus);
                _sqlcommnd.Parameters.AddWithValue("@OrderDate", _bowmng.OrderDate);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", _bowmng.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@IsDelete", _bowmng.IsDelete);
                _sqlcommnd.Parameters.AddWithValue("@CreatedBy", _bowmng.CreatedBy);
                _sqlcommnd.Parameters.AddWithValue("@CreatedDate", _bowmng.CreatedDate);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", _bowmng.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", _bowmng.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bowmng.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch (SqlException sqlex)
                {
                    Common.LogError(sqlex);
                }
                catch (StackOverflowException stackex)
                {
                    Common.LogError(stackex);
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