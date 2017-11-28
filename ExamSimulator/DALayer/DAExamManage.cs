using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ExamSimulator.BOLayer;
using ExamSimulator.BALayer;


namespace ExamSimulator.DALayer
{
    class DAExamManage
    {
        private SqlCommand _sqlcommond;
        private SqlDataAdapter _sqldataadapter;
        private DataTable _datatable;

        internal List<BOExamManage> SelectExamDetail(string v, int uid)
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

                List<BOExamManage> _boexmmnglist = (from li in _datatable.AsEnumerable()
                                                    select new BOExamManage
                                                    {
                                                        ExamCodeId = li.Field<int>("ExamCodeId"),
                                                        ExamCode = li.Field<string>("ExamCode"),
                                                        SecondCategoryId = li.Field<int>("SecondCategoryId"),
                                                        SecondCategory = li.Field<string>("SecondCategoryName")
                                                    }).ToList();
                _sqlcon.Close();
                return _boexmmnglist;
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
                                                 Resource = "http://quizmerchant.mobi96.org/resource/" + li.Field<string>("Resource"),
                                                 Exhibit = "http://quizmerchant.mobi96.org/resource/" + li.Field<string>("Exhibit"),
                                                 Topology = "http://quizmerchant.mobi96.org/resource/" + li.Field<string>("Topology"),
                                                 Scenario = "http://quizmerchant.mobi96.org/resource/" + li.Field<string>("Scenario"),
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
                                               RightAnswer = li.Field<bool>("RightAnswer"),
                                               QuestionId = quid
                                           })
                                            .ToList();
            return _answerlist;
        }
    }
}
