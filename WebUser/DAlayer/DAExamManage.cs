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
    public class DAExamManage
    {
        private SqlCommand _sqlcommond;
        private SqlDataAdapter _sqldataadapter;
        private DataTable _datatable;

        internal DataTable SelectExamDetail(string v, int uid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@UserId", uid);
                _sqlcommond.Parameters.AddWithValue("@Event", v);

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

        internal BOExamManage SelectExamQestionAnswer(string txtevent, int examid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamQuestionAnswer";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@ExamCodeId", examid);
                _sqlcommond.Parameters.AddWithValue("@Event", txtevent);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                BOExamManage _boexmmnglist = (from li in _datatable.AsEnumerable()
                                              select new BOExamManage
                                              {
                                                  ExamCodeId = li.Field<int>("ExamCodeId"),
                                                  ExamCode = li.Field<string>("ExamCode"),
                                                  ExamTitle = li.Field<string>("ExamTitle"),
                                                  PassingPercentage = li.Field<decimal>("PassingPercentage"),
                                                  TestTime = li.Field<int>("TestTime"),
                                                  QuestionList = GetQuestionList()
                                              }).FirstOrDefault();
                _sqlcon.Close();
                return _boexmmnglist;
            }
        }

        private List<BOQAManage> GetQuestionList()
        {
            List<BOQAManage> _qustionlist = (from li in _datatable.AsEnumerable()
                                             select new BOQAManage
                                             {
                                                 QAId = li.Field<int>("QAId"),
                                                 QuestionTypeId = li.Field<int>("QuestionTypeId"),
                                                 QuestionType = li.Field<string>("QuestionType"),
                                                 Score = li.Field<decimal>("Score"),
                                                 Question = li.Field<string>("Question"),
                                                 NoofAnswer = li.Field<int>("NoofAnswer"),
                                                 Explanation = li.Field<string>("Explanation"),
                                                 Resource = li.Field<string>("Resource"),
                                                 Exhibit = li.Field<string>("Exhibit"),
                                                 Topology = li.Field<string>("Topology"),
                                                 Scenario = li.Field<string>("Scenario"),
                                                 AnswerList = GetAnswerList(li.Field<int>("QAId"))
                                             }).GroupBy(ques => ques.QAId)
                                              .Select(group => group.First()).ToList();
            return _qustionlist;
        }

        private List<BOQAnswer> GetAnswerList(int quid)
        {
            List<BOQAnswer> _answerlist = (from li in _datatable.AsEnumerable()
                                           .Where(p => p.Field<int>("QAId") == quid)
                                           select new BOQAnswer
                                           {
                                               AnswerId = li.Field<int>("AnswerId"),
                                               Answer = li.Field<string>("Answer"),
                                               RightAnswer = li.Field<string>("RightAnswer")
                                           })
                                            .ToList();
            return _answerlist;
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
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _boexmmng.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _boexmmng.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@OnlyTestOnce", _boexmmng.OnlyTestOnce);
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