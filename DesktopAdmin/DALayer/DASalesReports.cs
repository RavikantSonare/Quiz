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
    public class DASalesReports
    {
        public List<BOSalesReports> SelectSalesReportsList(BOSalesReports _boslsrpt)
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
                _sqlcmd.Parameters.AddWithValue("@Event", _boslsrpt.Event);
                _sqldataadapter = new SqlDataAdapter(_sqlcmd);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                List<BOSalesReports> _boslsrptlist = (from li in _datatable.AsEnumerable()
                                                      select new BOSalesReports
                                                      {
                                                          OrderId = li.Field<int>("OrderId"),
                                                          OrderNo = li.Field<string>("OrderNo"),
                                                          ExamCode = li.Field<string>("ExamCode"),
                                                          SecondCategory = li.Field<string>("SecondCategoryName"),
                                                          MerchantName = li.Field<string>("MerchantName"),
                                                          Price = li.Field<decimal>("Price"),
                                                          FeeRate = li.Field<int>("MerchantFeeRate"),
                                                          NetAmount = li.Field<decimal>("NetAmount"),
                                                          OrderStatus = li.Field<bool>("OrderStatus")
                                                      }).ToList();
                _sqlcon.Close();
                return _boslsrptlist;
            }
        }

        public int IUDSalesReports(BOSalesReports _boslsrpt)
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
