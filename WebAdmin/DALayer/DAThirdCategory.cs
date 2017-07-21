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
    public class DAThirdCategory
    {
        private SqlCommand _sqlcommand;
        private SqlDataAdapter _sqlDataAdapter;
        public int IUDThirdCategory(BOThirdCategory thirdcat)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDThirdCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@ThirdCategoryId", thirdcat.ThirdCategoryId);
                _sqlcommand.Parameters.AddWithValue("@ThirdCategoryName", thirdcat.ThirdCategoryName);
                _sqlcommand.Parameters.AddWithValue("@SecondCategoryId", thirdcat.SecondCategoryId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", thirdcat.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", thirdcat.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", thirdcat.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", thirdcat.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", thirdcat.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", thirdcat.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", thirdcat.Event);
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

        public DataTable SelectThirdCategory(string eventtxt)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetThirdCategory";
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

        internal DataTable SelectThirdCategoryWithID(string v, int ThirdcatId)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetThirdCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;
                _sqlconnection.Open();
                _sqlcommand.Parameters.AddWithValue("@ThirdCategoryId", ThirdcatId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable2 = new DataTable();
                _sqlDataAdapter.Fill(_dataTable2);
                _sqlconnection.Close();
                return _dataTable2;
            }
        }

        internal DataTable SelectThirdCatgorywithSearch(string v, string text)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetThirdCategory";
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