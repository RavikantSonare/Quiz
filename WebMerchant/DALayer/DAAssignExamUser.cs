using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;

namespace WebMerchant.DALayer
{
    public class DAAssignExamUser
    {
        private SqlCommand _sqlcommand;

        internal int IUDAssignExamUser(BOAssignExamUser _boaeu)
        {
            int returnValue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDAssignExamUser";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@UserId", _boaeu.UserId);
                _sqlcommand.Parameters.AddWithValue("@ExamId", _boaeu.ExamId);
                _sqlcommand.Parameters.AddWithValue("@SecondCatId", _boaeu.SecondCatId);
                _sqlcommand.Parameters.AddWithValue("@TestOnce", _boaeu.TestOnce);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _boaeu.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _boaeu.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _boaeu.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _boaeu.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boaeu.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boaeu.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _boaeu.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch (SqlException sqlex)
                { Common.LogError(sqlex); }
                catch (StackOverflowException stackex)
                { Common.LogError(stackex); }
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
            return returnValue;
        }

        internal int IUD(BOAssignExamUser _boaeu)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDAssignExamUser";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@ExamId", _boaeu.ExamId);
                _sqlcommand.Parameters.AddWithValue("@UserId", _boaeu.UserId);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boaeu.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boaeu.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@TestOnce", _boaeu.TestOnce);
                _sqlcommand.Parameters.AddWithValue("@Event", _boaeu.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
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
                    _sqlcommand.Dispose();
                }
            }
            return returnvalue;
        }
    }
}