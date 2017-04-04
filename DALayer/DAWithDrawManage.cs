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
    public class DAWithDrawManage
    {
        public List<BOWithDrawManage> SelectWithDrawManageList(BOWithDrawManage _bowdwmng)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqldataadpater;

            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetWithDrawOrder";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _bowdwmng.Event);
                DataTable _datatable = new DataTable();
                _sqldataadpater = new SqlDataAdapter(_sqlcommand);
                _sqldataadpater.Fill(_datatable);

                List<BOWithDrawManage> _bowdrmng = (from li in _datatable.AsEnumerable()
                                                    select new BOWithDrawManage
                                                    {
                                                        WithDrawOrderId = li.Field<int>("WithDrawOrderId"),
                                                        WithDrawOrderNo = li.Field<string>("WithDrawOrderNo"),
                                                        Amount = li.Field<decimal>("Amount"),
                                                        MerchantName = li.Field<String>("MerchantName"),
                                                        OrderStatus = li.Field<bool>("OrderStatus")
                                                    }).ToList();
                return _bowdrmng;

            }
        }

        public int IUDWithDrawManage(BOWithDrawManage _bowdwmng)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDWithDrawOrderManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;
                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@WithDrawOrderId", _bowdwmng.WithDrawOrderId);
                _sqlcommand.Parameters.AddWithValue("@OrderStatus", _bowdwmng.OrderStatus);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bowdwmng.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _bowdwmng.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bowdwmng.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnvalue = 100;
                }
                finally
                {
                    _sqlcon.Close();
                    _sqlcommand.Dispose();
                }

            }
            return returnvalue;
        }
    }
}
