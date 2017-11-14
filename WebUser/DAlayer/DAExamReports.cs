using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebUser.BOLayer;
using WebUser.BALayer;

namespace WebUser.DAlayer
{
    public class DAExamReports
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable SelectExamReport(string v, int uid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetExamReport";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@UserId", uid);

                DataTable _datatable = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable);

                return _datatable;
            }
        }

        internal int IUDReports(BOExamReports _boexrport)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDReports";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@UserId", _boexrport.UserId);
                _sqlcommand.Parameters.AddWithValue("@CategoryId", _boexrport.CategoryId);
                _sqlcommand.Parameters.AddWithValue("@ExamId", _boexrport.ExamId);
                _sqlcommand.Parameters.AddWithValue("@Result", _boexrport.Result);
                _sqlcommand.Parameters.AddWithValue("@Score", _boexrport.Score);
                _sqlcommand.Parameters.AddWithValue("@OutofScore", _boexrport.OutofScore);
                _sqlcommand.Parameters.AddWithValue("@AllowPrint", _boexrport.AllowPrint);
                _sqlcommand.Parameters.AddWithValue("@DigitalCertificateId", _boexrport.DigitalCertificateId);
                _sqlcommand.Parameters.AddWithValue("@CertificationNo", _boexrport.CertificationNo);
                _sqlcommand.Parameters.AddWithValue("@ExamGivenDate", _boexrport.ExamGivenDate);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _boexrport.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _boexrport.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _boexrport.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _boexrport.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _boexrport.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boexrport.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boexrport.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _boexrport.Event);
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
    }
}