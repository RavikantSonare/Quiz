using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using System.Data;
using System.Data.SqlClient;

namespace DesktopMerchant.DALayer
{
    class DASecondCategory
    {
        public List<BOSecondCategory> selectSecondCatelist(BOSecondCategory _boseccat)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _boseccat.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOSecondCategory> _merfr = (from cu in _dataTable.AsEnumerable()
                                                 select new BOSecondCategory
                                                 {
                                                     SecondCategoryId = cu.Field<int>("SecondCategoryId"),
                                                     SecondCategoryName = cu.Field<string>("SecondCategoryName")
                                                 }).ToList();

                return _merfr;
            }
        }

        internal List<BOSecondCategory> selectSecondCatelistWithTop(string eventtxt, int topcatid)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", topcatid);
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOSecondCategory> _merfr = (from cu in _dataTable.AsEnumerable()
                                                 select new BOSecondCategory
                                                 {
                                                     SecondCategoryId = cu.Field<int>("SecondCategoryId"),
                                                     SecondCategoryName = cu.Field<string>("SecondCategoryName")
                                                 }).ToList();

                return _merfr;
            }
        }
    }
}
