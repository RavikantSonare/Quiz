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
    public class DAMerchantCertificate
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable SelectCertifcateList(string v, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetCertificate";
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandType = CommandType.StoredProcedure;

                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }

        internal DataTable SelectCertifcateWithTid(string v, int exmrptId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetCertificate";
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandType = CommandType.StoredProcedure;

                _sqlcommand.Parameters.AddWithValue("@CertificateId", exmrptId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }

        internal int IUDCertifcate(BOMerchantCertificate _bomercerfict)
        {
            int returnValue = default(int);

            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDCertificate";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@CertificateId", _bomercerfict.CertificateId);
                _sqlcommand.Parameters.AddWithValue("@CertificateTitle", _bomercerfict.CertificateTitle);
                _sqlcommand.Parameters.AddWithValue("@NameBox", _bomercerfict.NameBox);
                _sqlcommand.Parameters.AddWithValue("@DateBox", _bomercerfict.DateBox);
                _sqlcommand.Parameters.AddWithValue("@SampleUserName", _bomercerfict.SampleUserName);
                _sqlcommand.Parameters.AddWithValue("@CertificatePic", _bomercerfict.CertificatePic);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bomercerfict.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bomercerfict.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bomercerfict.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bomercerfict.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bomercerfict.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bomercerfict.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _bomercerfict.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bomercerfict.Event);
                _sqlcommand.Parameters.AddWithValue("@retrunValue", 0).Direction = ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommand.Parameters["@retrunValue"].Value);
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
                return returnValue;
            }
        }
    }
}