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
    public class DAExamManage
    {
        private SqlCommand _sqlcommond;
        private SqlDataAdapter _sqldataadapter;
        private DataTable _datatable;

        internal DataTable SelectExamDetail(string eventtext, int merchantid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@MerchantId", merchantid);
                _sqlcommond.Parameters.AddWithValue("@Event", eventtext);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();

                return _datatable;
            }
        }

        internal DataTable SelectExamDetailWithID(string txtevent, int examid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@ExamCodeId", examid);
                _sqlcommond.Parameters.AddWithValue("@Event", txtevent);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();

                return _datatable;
            }
        }

        internal int IUD(BOExamManage _boexmmng)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDExamManage";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@ExamCodeId", _boexmmng.ExamCodeId);
                _sqlcommond.Parameters.AddWithValue("@ExamCode", _boexmmng.ExamCode);
                _sqlcommond.Parameters.AddWithValue("@ExamTitle", _boexmmng.ExamTitle);
                _sqlcommond.Parameters.AddWithValue("@TopCategoryId", _boexmmng.TopCategoryId);
                _sqlcommond.Parameters.AddWithValue("@SecondCategoryId", _boexmmng.SecondCategoryId);
                _sqlcommond.Parameters.AddWithValue("@PassingPercentage", _boexmmng.PassingPercentage);
                _sqlcommond.Parameters.AddWithValue("@TestTime", _boexmmng.TestTime);
                _sqlcommond.Parameters.AddWithValue("@TestOption", _boexmmng.TestOption);
                _sqlcommond.Parameters.AddWithValue("@ValidDate", _boexmmng.ValidDate);
                _sqlcommond.Parameters.AddWithValue("@MerchantId", _boexmmng.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@IsActive", _boexmmng.IsActive);
                _sqlcommond.Parameters.AddWithValue("@IsDelete", _boexmmng.IsDelete);
                _sqlcommond.Parameters.AddWithValue("@CreatedBy", _boexmmng.CreatedBy);
                _sqlcommond.Parameters.AddWithValue("@CreatedDate", _boexmmng.CreatedDate);
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _boexmmng.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _boexmmng.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@OnlyTestOnce", _boexmmng.OnlyTestOnce);
                _sqlcommond.Parameters.AddWithValue("@AllowPrint", _boexmmng.AllowPrint);
                _sqlcommond.Parameters.AddWithValue("@AllowSales", _boexmmng.AllowSales);
                _sqlcommond.Parameters.AddWithValue("@Event", _boexmmng.Event);
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