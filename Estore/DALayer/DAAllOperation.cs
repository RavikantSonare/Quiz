using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Estore.BOLayer;
using Estore.BALayer;

namespace Estore.DALayer
{
    public class DAAllOperation
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        DataTable _datatable;
        DataSet _dset;

        public BOAllCount AllCount()
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetAllCount";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                BOAllCount _boallcnt = (from list in _datatable.AsEnumerable()
                                        select new BOAllCount
                                        {
                                            TotalMerchant = list.Field<int>("TotalMerchant"),
                                            TotalUser = list.Field<int>("TotalUser"),
                                            TotalExams = list.Field<int>("TotalExams"),
                                            TotalQuestion = list.Field<int>("TotalQuestion")
                                        }).FirstOrDefault();
                return _boallcnt;
            }
        }

        public DataSet ListAllCategory()
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetAllCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _dset = new DataSet();
                _sqldataadapter.Fill(_dset);
                _sqlconnection.Close();

                return _dset;
            }
        }
    }
}