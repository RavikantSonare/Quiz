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
    public class DAExamReports
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable SelectExamReport(string v, int uid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetExamReport";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@UserId", uid);

                DataTable _datatable = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable);

                return _datatable;
            }
        }
    }
}