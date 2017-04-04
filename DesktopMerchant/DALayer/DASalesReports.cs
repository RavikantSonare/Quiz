using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BALayer;
using DesktopMerchant.BOLayer;

namespace DesktopMerchant.DALayer
{
    class DASalesReports
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        internal List<BOSalesReports> SelectSalesReportsWithId(string v, int mrid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSalesReports";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", mrid);
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                List<BOSalesReports> _boslsrptlist = (from li in _datatable.AsEnumerable()
                                                      select new BOSalesReports
                                                      {
                                                          OrderId = li.Field<int>("OrderId"),
                                                          OrderNo = li.Field<string>("OrderNo"),
                                                          OrderDate=li.Field<DateTime>("OrderDate"),
                                                          ExamCode = li.Field<string>("ExamCode"),
                                                          SecondCategory = li.Field<string>("SecondCategoryName"),
                                                          Price = li.Field<decimal>("Price"),
                                                          FeeRate = li.Field<int>("MerchantFeeRate"),
                                                          NetAmount = li.Field<decimal>("NetAmount"),
                                                          OrderStatus = li.Field<bool>("OrderStatus")
                                                      }).ToList();
                return _boslsrptlist;

            }
        }
    }
}
