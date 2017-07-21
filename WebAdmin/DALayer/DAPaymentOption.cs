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
    public class DAPaymentOption
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        public int IUDPaymentOption(BOPaymentOption _bopopt)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.CommandText = "SP_IUDPaymentOption";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@PaymentOptionId", _bopopt.PaymentOptionId);
                _sqlcommand.Parameters.AddWithValue("@PaymentOption", _bopopt.PaymentOption);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bopopt.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bopopt.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bopopt.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bopopt.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdateBy", _bopopt.UpdateBy);
                _sqlcommand.Parameters.AddWithValue("@UpdateDate", _bopopt.UpdateDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bopopt.Event);
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
                    _sqlconnection.Close();
                    _sqlcommand.Dispose();
                }
            }
            return returnvalue;
        }

        public DataTable SelectPaymentOption(string txtevent)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetPaymentOption";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", txtevent);
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable1 = new DataTable();
                _sqldataadapter.Fill(_datatable1);
                _sqlconnection.Close();
                return _datatable1;
            }
        }

        internal DataTable SelectPaymentOptionWithID(string v, int poptId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetPaymentOption";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@PaymentOptionId", poptId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable2 = new DataTable();
                _sqldataadapter.Fill(_datatable2);
                _sqlconnection.Close();
                return _datatable2;
            }
        }
    }
}