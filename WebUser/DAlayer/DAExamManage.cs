﻿using System;
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
                                                 Score = li.Field<decimal>("Score"),
                                                 Question = li.Field<string>("Question"),
                                                 NoofAnswer = li.Field<int>("NoofAnswer"),
                                                 Explanation = li.Field<string>("Explanation"),
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
    }
}