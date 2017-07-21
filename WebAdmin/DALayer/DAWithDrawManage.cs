using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebAdmin.BOLayer;

namespace WebAdmin.DALayer
{
    public class DAWithDrawManage
    {
        public DataTable SelectWithDrawManageList(string txtevent)
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
                _sqlcommand.Parameters.AddWithValue("@Event", txtevent);
                DataTable _datatable = new DataTable();
                _sqldataadpater = new SqlDataAdapter(_sqlcommand);
                _sqldataadpater.Fill(_datatable);
                _sqlcon.Close();
                return _datatable;
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
    }
}