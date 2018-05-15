﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebUser.BOLayer;

namespace WebUser.DAlayer
{
    public class DAUser
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        DataTable _datatable;
        internal BOUser SelectUserDetail(string v1, string text, string v2)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMyUser";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@EmailId", text);
                _sqlcommand.Parameters.AddWithValue("@AccessPassword", v2);
                _sqlcommand.Parameters.AddWithValue("@Event", v1);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                BOUser _bousr = new BOUser();
                _bousr = (from list in _datatable.AsEnumerable()
                          select new BOUser
                          {
                              UserId = list.Field<int>("UserId"),
                              UserName = list.Field<string>("UserName"),
                              AccessPassword = list.Field<string>("AccessPassword"),
                              MerchantId = list.Field<int>("MerchantId"),
                              //SecondCategory = list.Field<int>("SecondCategory"),
                              ExamId = list.Field<string>("ExamId"),
                              ExamCode = list.Field<string>("ExamCode"),
                              ValidTime = list.Field<DateTime>("ValidTime"),
                              AccessOption = list.Field<string>("AccessOption"),
                              IsActive = list.Field<bool>("IsActive"),
                              IsDelete = list.Field<bool>("IsDelete"),
                              EmailId = list.Field<string>("EmailId"),
                              GroupId = list.Field<int>("GroupId"),
                              GroupStatus = list.Field<bool>("GroupStatus"),
                              UGExamId = list.Field<string>("UGExamId"),
                              UGAccessOption = list.Field<string>("UGAccessOption"),
                              ValidTimeTo = list.Field<DateTime>("ValidTimeTo"),
                              StartDate = list.Field<DateTime>("StartDate"),
                              EndDate = list.Field<DateTime>("EndDate")

                          }).FirstOrDefault();
                return _bousr;
            }
        }
    }
}