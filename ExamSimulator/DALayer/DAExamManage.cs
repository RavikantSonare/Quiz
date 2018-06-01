using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;
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
                                                        ExamTitle = li.Field<string>("ExamTitle"),
                                                        SecondCategoryId = li.Field<int>("SecondCategoryId"),
                                                        SecondCategory = li.Field<string>("SecondCategoryName"),
                                                        TestTime = li.Field<int>("TestTime")
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
                _sqlcommond.CommandText = "SP_GetExamQuestionAnswerForOffLineSimultor";
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
                                                  SecondCategoryId = li.Field<int>("SecondCategoryId"),
                                                  SecondCategory = li.Field<string>("SecondCategoryName"),
                                                  TestOption = li.Field<string>("TestOption"),
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
                                                 Resource = !string.IsNullOrEmpty(li.Field<string>("Resource")) ? Common.FullyQualifiedApplicationPath + "/resource/" + li.Field<string>("Resource") : "",
                                                 Exhibit = !string.IsNullOrEmpty(li.Field<string>("Exhibit")) ? Common.FullyQualifiedApplicationPath + "/resource/" + li.Field<string>("Exhibit") : "",
                                                 Topology = !string.IsNullOrEmpty(li.Field<string>("Topology")) ? Common.FullyQualifiedApplicationPath + "/resource/" + li.Field<string>("Topology") : "",
                                                 Scenario = !string.IsNullOrEmpty(li.Field<string>("Scenario")) ? Common.FullyQualifiedApplicationPath + "/resource/" + li.Field<string>("Scenario") : "",
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

        internal BOExamManage SelectExamQestionAnswerbase64(string txtevent, int examid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamQuestionAnswerForOffLineSimultor";
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
                                                  QuestionList = GetQuestionListbase64()
                                              }).FirstOrDefault();
                _sqlcon.Close();
                return _boexmmnglist;
            }
        }

        private List<BOQAManage> GetQuestionListbase64()
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
                                                 Resource = !string.IsNullOrEmpty(li.Field<string>("Resource")) ? imagebase64(li.Field<string>("Resource")) : "",
                                                 Exhibit = !string.IsNullOrEmpty(li.Field<string>("Exhibit")) ? imagebase64(li.Field<string>("Exhibit")) : "",//imagebase64(li.Field<string>("Exhibit")),
                                                 Topology = !string.IsNullOrEmpty(li.Field<string>("Topology")) ? imagebase64(li.Field<string>("Topology")) : "",//imagebase64(li.Field<string>("Topology")),
                                                 Scenario = !string.IsNullOrEmpty(li.Field<string>("Scenario")) ? imagebase64(li.Field<string>("Scenario")) : "",//imagebase64(li.Field<string>("Scenario")),
                                                 AnswerList = GetAnswerList(li.Field<int>("QAId"))
                                             }).GroupBy(ques => ques.QAId)
                                              .Select(group => group.First()).ToList();
            return _qustionlist;
        }

        public static string tempvalue;
        public string imagebase64(string imagename)
        {
            if (tempvalue == imagename)
            {
                return "";
            }
            tempvalue = imagename;
            string base64String = string.Empty;
            if (imagename != null && imagename != "")
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(Common.FullyQualifiedApplicationPath + "/resource/" + imagename);
                    base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                }
                return base64String;
            }
            else return base64String;
        }
    }
}
