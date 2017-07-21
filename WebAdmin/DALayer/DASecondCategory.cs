using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin.DALayer
{
    public class DASecondCategory
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;
        public int IUDSecondCategory(BOSecondCategory secat)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDSecondCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@SecondCategoryId", secat.SecondCategoryId);
                _sqlcommand.Parameters.AddWithValue("@SecondCategoryName", secat.SecondCategoryName);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", secat.TopCategoryId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", secat.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", secat.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", secat.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", secat.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", secat.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", secat.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", secat.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch (Exception ex)
                {
                    Common.LogError(ex);
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommand.Dispose();
                }
            }
            return returnvalue;
        }

        public DataTable SelectSecondCategory(string eventtxt)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable1 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable1);
                _sqlconnection.Close();
                return _dataTable1;
            }
        }

        internal DataTable SelectSecodCategoryWithID(string v, int scatId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@SecondCategoryId", scatId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable2 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable2);
                _sqlconnection.Close();
                return _dataTable2;
            }
        }

        internal DataTable SelectSecondCatgorywithSearch(string v, string text)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@Searchtext", text);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable2 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable2);
                _sqlconnection.Close();
                return _dataTable2;
            }
        }
    }
}