using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BALayer;
using WebMerchant.BOLayer;

namespace WebMerchant.DALayer
{
    public class DASecondCategory
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter sqldataadapter;
        private DataTable _datatable;

        internal DataTable SelectSecondCategory(string strevent, string topcatid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@Event", strevent);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", topcatid);

                _sqlconnection.Open();
                sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }

        internal int IUD(BOSecondCategory _boscat)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDSecondCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@SecondCategoryId", _boscat.SecondCategoryId);
                _sqlcommand.Parameters.AddWithValue("@SecondCategoryName", _boscat.SecondCategoryName);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", _boscat.TopCategoryId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _boscat.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _boscat.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _boscat.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _boscat.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boscat.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boscat.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _boscat.Event);
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

        internal DataTable SelectAllSecondCategory(string v)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqlconnection.Open();
                sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }
    }
}