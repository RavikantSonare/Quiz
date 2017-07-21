using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant.DALayer
{
    public class DAMerchantAllowSales
    {
        private SqlCommand _sqlcommond;
        private SqlDataAdapter _sqldataadapter;
        private DataTable _datatable;

        internal DataTable SelectAllowsales(string v, int examid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetAllowSales";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@ExamId", examid);
                _sqlcommond.Parameters.AddWithValue("@Event", v);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();

                return _datatable;
            }
        }

        internal int IUDAllowSales(BOMerchantAllowSales _bomallsales)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDAllowSales";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@Id", _bomallsales.Id);
                _sqlcommond.Parameters.AddWithValue("@ExamId", _bomallsales.ExamId);
                _sqlcommond.Parameters.AddWithValue("@NoofQuestion", _bomallsales.NoofQuestion);
                _sqlcommond.Parameters.AddWithValue("@Price", _bomallsales.Price);
                _sqlcommond.Parameters.AddWithValue("@SelfDescription", _bomallsales.SelfDescription);
                _sqlcommond.Parameters.AddWithValue("@IsActive", _bomallsales.IsActive);
                _sqlcommond.Parameters.AddWithValue("@IsDelete", _bomallsales.IsDelete);
                _sqlcommond.Parameters.AddWithValue("@CreatedBy", _bomallsales.CreatedBy);
                _sqlcommond.Parameters.AddWithValue("@CreatedDate", _bomallsales.CreatedDate);
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _bomallsales.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _bomallsales.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@Event", _bomallsales.Event);
                _sqlcommond.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommond.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommond.Parameters["@returnValue"].Value);
                }
                catch (SqlException sqlex)
                {
                    Common.LogError(sqlex);
                }
                catch (StackOverflowException stackex)
                {
                    Common.LogError(stackex);
                }
                catch (Exception ex)
                {
                    Common.LogError(ex);
                }
                finally
                {
                    _sqlcon.Close();
                    _sqlcommond.Dispose();
                }
            }
            return returnvalue;
        }
    }
}