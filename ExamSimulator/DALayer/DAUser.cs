using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ExamSimulator.BOLayer;

namespace ExamSimulator.DALayer
{
    class DAUser
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
                              // SecondCategory = list.Field<int>("SecondCategory"),
                              ExamId = list.Field<string>("ExamId"),
                              ExamCode = list.Field<string>("ExamCode"),
                              ValidTime = list.Field<DateTime>("ValidTime"),
                              AccessOption = list.Field<string>("AccessPassword"),
                              IsActive = list.Field<bool>("IsActive"),
                              IsDelete = list.Field<bool>("IsDelete"),
                              EmailId = list.Field<string>("EmailId"),
                              GroupId = list.Field<int>("GroupId"),
                              GroupStatus = list.Field<bool>("GroupStatus")
                          }).FirstOrDefault();
                return _bousr;
            }
        }
    }
}
