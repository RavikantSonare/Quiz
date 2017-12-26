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
    public class DAMerchantPayment
    {
        private SqlCommand _sqlcommond;

        internal int IUD(BOMerchantPayment _bomerpmt)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDMerchantPayment";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@PaymentId", _bomerpmt.PaymentId);
                _sqlcommond.Parameters.AddWithValue("@MerchantId", _bomerpmt.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@MerchantOrderNo", _bomerpmt.MerchantOrderNo);
                _sqlcommond.Parameters.AddWithValue("@SId", _bomerpmt.SId);
                _sqlcommond.Parameters.AddWithValue("@Key", _bomerpmt.Key);
                _sqlcommond.Parameters.AddWithValue("@Order_Number", _bomerpmt.Order_Number);
                _sqlcommond.Parameters.AddWithValue("@CurrencyCode", _bomerpmt.CurrencyCode);
                _sqlcommond.Parameters.AddWithValue("@InvoiceId", _bomerpmt.InvoiceId);
                _sqlcommond.Parameters.AddWithValue("@TotalAmount", _bomerpmt.TotalAmount);
                _sqlcommond.Parameters.AddWithValue("@CCProcess", _bomerpmt.CCProcess);
                _sqlcommond.Parameters.AddWithValue("@PayMethod", _bomerpmt.PayMethod);
                _sqlcommond.Parameters.AddWithValue("@Date", _bomerpmt.Date);
                _sqlcommond.Parameters.AddWithValue("@PaymentData", _bomerpmt.PaymentData);
                _sqlcommond.Parameters.AddWithValue("@IsActive", _bomerpmt.IsActive);
                _sqlcommond.Parameters.AddWithValue("@IsDelete", _bomerpmt.IsDelete);
                _sqlcommond.Parameters.AddWithValue("@Event", _bomerpmt.Event);
                _sqlcommond.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommond.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommond.Parameters["@returnValue"].Value);
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
                    _sqlcon.Close();
                    _sqlcommond.Dispose();
                }
            }
            return returnvalue;
        }
    }
}