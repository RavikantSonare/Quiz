using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebUser.BOLayer;

namespace WebUser.DAlayer
{
    public class DAAssignExamUser
    {
        private SqlCommand _sqlcommond;
        internal int IUD(BOAssignExamUser _boaeu)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDAssignExamUser";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@ExamId", _boaeu.ExamId);
                _sqlcommond.Parameters.AddWithValue("@UserId", _boaeu.UserId);
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _boaeu.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _boaeu.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@TestOnce", _boaeu.TestOnce);
                _sqlcommond.Parameters.AddWithValue("@Event", _boaeu.Event);
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