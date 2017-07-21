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
    public class DASalesReport
    {
        public DataTable SelectSalesReportsList(string eventxt)
        {
            SqlCommand _sqlcmd;
            SqlDataAdapter _sqldataadapter;
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcmd = new SqlCommand();
                _sqlcmd.CommandText = "SP_GetSalesReports";
                _sqlcmd.CommandType = CommandType.StoredProcedure;
                _sqlcmd.Connection = _sqlcon;

                _sqlcon.Open();
                _sqlcmd.Parameters.AddWithValue("@Event", eventxt);
                _sqldataadapter = new SqlDataAdapter(_sqlcmd);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                _sqlcon.Close();
                return _datatable;
            }
        }

        public int IUDSalesReports(BOSalesReport _boslsrpt)
        {
            int returnvalue = default(int);

            SqlCommand _sqlcommand;
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDSalesReports";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;
                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@OrderId", _boslsrpt.OrderId);
                _sqlcommand.Parameters.AddWithValue("@OrderStatus", _boslsrpt.OrderStatus);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boslsrpt.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boslsrpt.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _boslsrpt.Event);
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