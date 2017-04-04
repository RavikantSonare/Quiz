using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BOLayer;

namespace DALayer
{
    public class DATopCategory
    {
        public int IUDTopCategory(BOTopCategory btcat)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDTopCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", btcat.TopCategoryId);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryName", btcat.TopCategoryName);
                _sqlcommand.Parameters.AddWithValue("@IsActive", btcat.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", btcat.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", btcat.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", btcat.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", btcat.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", btcat.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", btcat.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnvalue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommand.Dispose();
                }
            }
            return returnvalue;
        }

        public List<BOTopCategory> SelectTopCategoryList(BOTopCategory btcat)
        {
            DataTable _dtable = new DataTable();
            _dtable = SelectTopCategory(btcat);
            List<BOTopCategory> TopCateList = (from cu in _dtable.AsEnumerable()
                                               select new BOTopCategory
                                               {
                                                   TopCategoryName = cu.Field<string>("TopCategoryName"),
                                                   TopCategoryId = cu.Field<int>("TopCategoryId")
                                               }).ToList();

            return TopCateList;
        }

        public DataTable SelectTopCategory(BOTopCategory btcat)
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
                _sqlcommand.Parameters.AddWithValue("@Event", btcat.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                return _dataTable;
            }
        }
    }
}
