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
    public class DAQAnswer
    {
        private SqlCommand _sqlcommand;

        internal int IUDAnswer(BOQAnswer _boqans)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDAnswer";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@AnswerId", _boqans.AnswerId);
                _sqlcommand.Parameters.AddWithValue("@Answer", _boqans.Answer);
                _sqlcommand.Parameters.AddWithValue("@QuestionId", _boqans.QuestionId);
                _sqlcommand.Parameters.AddWithValue("@RightAnswer", _boqans.RightAnswer);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _boqans.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _boqans.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _boqans.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _boqans.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _boqans.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _boqans.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _boqans.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
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
            return returnvalue;
        }
    }
}