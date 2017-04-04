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
    public class DAPaymentOption
    {
        public int IUDPaymentOption(BOPaymentOption _bopopt)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;

                _sqlcommnd.CommandText = "SP_IUDPaymentOption";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@PaymentOptionId", _bopopt.PaymentOptionId);
                _sqlcommnd.Parameters.AddWithValue("@PaymentOption", _bopopt.PaymentOption);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", _bopopt.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@IsDelete", _bopopt.IsDelete);
                _sqlcommnd.Parameters.AddWithValue("@CreatedBy", _bopopt.CreatedBy);
                _sqlcommnd.Parameters.AddWithValue("@CreatedDate", _bopopt.CreatedDate);
                _sqlcommnd.Parameters.AddWithValue("@UpdateBy", _bopopt.UpdateBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdateDate", _bopopt.UpdateDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _bopopt.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnvalue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnvalue;
        }

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
                                                         PaymentOption = li.Field<string>("PaymentOption"),
                                                         IsActive = li.Field<bool>("IsActive"),
                                                         IsDelete = li.Field<bool>("IsDelete")
                                                     }).ToList();
                return _bopoptlist;
            }
        }
    }
}
