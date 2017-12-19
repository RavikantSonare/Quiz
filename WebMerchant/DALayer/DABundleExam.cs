using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;

namespace WebMerchant.DALayer
{
    public class DABundleExam
    {
        private SqlCommand _sqlcommond;
        private SqlDataAdapter _sqldataadapter;
        private DataTable _datatable;
        internal int IUDBundle(BOBundleExam _bobndlexm)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDBundle";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@BundleId", _bobndlexm.BundleId);
                _sqlcommond.Parameters.AddWithValue("@BundleContent", _bobndlexm.BundleContent);
                _sqlcommond.Parameters.AddWithValue("@Price", _bobndlexm.Price);
                _sqlcommond.Parameters.AddWithValue("@FeaturedSelfsEstore", _bobndlexm.FeaturedSelfsEstore);
                _sqlcommond.Parameters.AddWithValue("@MerchantId", _bobndlexm.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@IsActive", _bobndlexm.IsActive);
                _sqlcommond.Parameters.AddWithValue("@IsDelete", _bobndlexm.IsDelete);
                _sqlcommond.Parameters.AddWithValue("@CreatedBy", _bobndlexm.CreatedBy);
                _sqlcommond.Parameters.AddWithValue("@CreatedDate", _bobndlexm.CreatedDate);
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _bobndlexm.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _bobndlexm.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@Event", _bobndlexm.Event);
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

        internal DataTable SelectBundleDetail(string eventtext, int merchantid)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetBundle";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@MerchantId", merchantid);
                _sqlcommond.Parameters.AddWithValue("@Event", eventtext);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();

                return _datatable;
            }
        }
    }
}