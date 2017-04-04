using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BOLayer;

namespace DesktopMerchant.DALayer
{
    class DATopCategory
    {
        internal List<BOTopCategory> SelectTopCatList(BOTopCategory _botopcat)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTopCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", _botopcat.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOTopCategory> TopCateList = (from cu in _dataTable.AsEnumerable()
                                                   select new BOTopCategory
                                                   {
                                                       TopCategoryName = cu.Field<string>("TopCategoryName"),
                                                       TopCategoryId = cu.Field<int>("TopCategoryId")
                                                   }).ToList();

                return TopCateList;
            }
        }
    }
}
