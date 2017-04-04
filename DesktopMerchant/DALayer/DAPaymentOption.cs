using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BOLayer;

namespace DesktopMerchant.DALayer
{
    class DAPaymentOption
    {
        public List<BOPaymentOption> SelectPaymentOption(BOPaymentOption _bopopt)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqldataadapter;
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetPaymentOption";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;
                _sqlcon.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _bopopt.Event);
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                List<BOPaymentOption> _bopoptlist = (from li in _datatable.AsEnumerable()
                                                     select new BOPaymentOption
                                                     {
                                                         PaymentOptionId = li.Field<int>("PaymentOptionId"),
                                                         PaymentOption = li.Field<string>("PaymentOption")
                                                     }).ToList();
                return _bopoptlist;
            }
        }
    }
}
