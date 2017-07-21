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
    public class DATemplate
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable SelectTemplatelist(string v, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTemplate";
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

        internal DataTable SelectTemplateWithTid(string v, int exmrptId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTemplate";
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandType = CommandType.StoredProcedure;

                _sqlcommand.Parameters.AddWithValue("@TemplateId", exmrptId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }

        internal int IUDTemplate(BOTemplate _botmplt)
        {
            int returnValue = default(int);

            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDTemplate";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@TemplateId", _botmplt.TemplateId);
                _sqlcommand.Parameters.AddWithValue("@CertificateTitle", _botmplt.CertificateTitle);
                _sqlcommand.Parameters.AddWithValue("@SampleUserName", _botmplt.SampleUserName);
                _sqlcommand.Parameters.AddWithValue("@TemplatePicture", _botmplt.TemplatePicture);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _botmplt.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _botmplt.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _botmplt.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _botmplt.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _botmplt.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _botmplt.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _botmplt.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _botmplt.Event);
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