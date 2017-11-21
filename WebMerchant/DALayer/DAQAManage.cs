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
    public class DAQAManage
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal int IUDQA(BOQAManage _boqamng)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDQA";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@QAId", _boqamng.QAId);
                _sqlcommand.Parameters.AddWithValue("@ExamCodeId", _boqamng.ExamCodeId);
                _sqlcommand.Parameters.AddWithValue("@ExamCode", _boqamng.ExamCode);
                _sqlcommand.Parameters.AddWithValue("@QuestionTypeId", _boqamng.QuestionTypeId);
                _sqlcommand.Parameters.AddWithValue("@Score", _boqamng.Score);
                _sqlcommand.Parameters.AddWithValue("@Question", _boqamng.Question);
                _sqlcommand.Parameters.AddWithValue("@NoofAnswer", _boqamng.NoofAnswer);
                _sqlcommand.Parameters.AddWithValue("@Explanation", _boqamng.Explanation);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _boqamng.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _boqamng.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _boqamng.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _boqamng.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _boqamng.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boqamng.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boqamng.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Resource", _boqamng.Resource);
                _sqlcommand.Parameters.AddWithValue("@Exhibit", _boqamng.Exhibit);
                _sqlcommand.Parameters.AddWithValue("@Topology", _boqamng.Topology);
                _sqlcommand.Parameters.AddWithValue("@Scenario", _boqamng.Scenario);
                _sqlcommand.Parameters.AddWithValue("@Event", _boqamng.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch (SqlException sqlex)
                { Common.LogError(sqlex); }
                catch (StackOverflowException stackex)
                { Common.LogError(stackex); }
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

        internal DataTable SelectQARecord(string eventxt, int qid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_GETQA";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@QAId", qid);
                _sqlcommand.Parameters.AddWithValue("@Event", eventxt);

                DataTable _datatable1 = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable1);
                _sqlconnection.Close();

                return _datatable1;
            }
        }

        internal DataTable SelectQAlist(string eventxt, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_GETQA";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);
                _sqlcommand.Parameters.AddWithValue("@Event", eventxt);

                DataTable _datatable2 = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable2);
                _sqlconnection.Close();

                return _datatable2;
            }
        }

        internal DataTable SelectQAmanageListwithSearch(string v, string text, int merchantId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_GETQA";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", merchantId);
                _sqlcommand.Parameters.AddWithValue("@Searchtext", text);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                DataTable _datatable3 = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable3);
                _sqlconnection.Close();

                return _datatable3;
            }
        }
    }
}