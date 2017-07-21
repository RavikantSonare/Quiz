using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin.DALayer
{
    public class DATopCategory
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqldataadapter;

        internal DataTable SelectTopCategory(string v)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTopCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@Event", v);

                DataTable _datatable1 = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable1);
                _sqlconnection.Close();
                return _datatable1;
            }
        }

        internal DataTable SelectTopCategorywithId(string v, int tidId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTopCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", tidId);

                DataTable _datatable2 = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable2);
                _sqlconnection.Close();
                return _datatable2;
            }
        }

        internal DataTable SelectTopCategorywithSearch(string v, string text)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetTopCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@SearchText", text);

                DataTable _datatable3 = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable3);
                _sqlconnection.Close();
                return _datatable3;
            }
        }

        internal int IUDTopCategory(BOTopCategory _botcat)
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

                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", _botcat.TopCategoryId);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryName", _botcat.TopCategoryName);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _botcat.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _botcat.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _botcat.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _botcat.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _botcat.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _botcat.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _botcat.Event);
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
    }
}