using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant.DALayer
{
    public class DAFinanceConfig
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal int IUD(BOFinanceConfig _bofncfg)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDFinanceConfig";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@FinanceConfigId", _bofncfg.FinanceConfigId);
                _sqlcommand.Parameters.AddWithValue("@PaymentOptionId", _bofncfg.PaymentOptionId);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bofncfg.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@AccountEmail", _bofncfg.AccountEmail);
                _sqlcommand.Parameters.AddWithValue("@FirstName", _bofncfg.FirstName);
                _sqlcommand.Parameters.AddWithValue("@LastName", _bofncfg.LastName);
                _sqlcommand.Parameters.AddWithValue("@Country", _bofncfg.Country);
                _sqlcommand.Parameters.AddWithValue("@City", _bofncfg.City);
                _sqlcommand.Parameters.AddWithValue("@BankOfName", _bofncfg.BankOfName);
                _sqlcommand.Parameters.AddWithValue("@SwiftCode", _bofncfg.SwiftCode);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bofncfg.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bofncfg.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bofncfg.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bofncfg.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bofncfg.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("UpdatedDate", _bofncfg.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bofncfg.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
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
                    _sqlcommand.Dispose();
                }

            }
            return returnvalue;
        }

        internal DataTable SelectFCDetailFID(string v1, int v2)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetFinanceConfig";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@FinanceConfigId", v2);
                _sqlcommand.Parameters.AddWithValue("@Event", v1);

                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                return _datatable;
            }
        }

        internal DataTable SelectfinanceconfigDetail(string v, int mId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetFinanceConfig";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", mId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                return _datatable;
            }
        }
    }
}