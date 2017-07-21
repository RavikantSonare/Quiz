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
    }
}