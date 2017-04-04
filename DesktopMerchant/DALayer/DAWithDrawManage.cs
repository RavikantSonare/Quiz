using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BOLayer;
using DesktopMerchant.BALayer;

namespace DesktopMerchant.DALayer
{
    class DAWithDrawManage
    {
        internal int Getorderno(string v)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
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
                catch
                {

                }
                finally
                {
                    _sqlcon.Close();
                    _sqlcommand.Dispose();
                }

            }
            return returnvalue;
        }

        internal List<BOWithDrawManage> SelectWithdrawRecord(string v, int merchantID)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqldataadapter;

            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetWithDrawOrder";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", merchantID);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                List<BOWithDrawManage> _bowmngt = (from li in _datatable.AsEnumerable()
                                                   select new BOWithDrawManage
                                                   {
                                                       WithDrawOrderId = li.Field<int>("WithDrawOrderId"),
                                                       WithDrawOrderNo = li.Field<string>("WithDrawOrderNo"),
                                                       Amount = li.Field<decimal>("Amount"),
                                                       OrderDate = li.Field<DateTime>("OrderDate"),
                                                       OrderStatus = li.Field<bool>("OrderStatus")
                                                   }).ToList();
                return _bowmngt;
            }
        }

        internal int IUD_BoWithDrawManage(BOWithDrawManage _bowmng)
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
                catch (Exception ex)
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
