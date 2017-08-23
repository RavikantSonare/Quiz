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
    }
}
