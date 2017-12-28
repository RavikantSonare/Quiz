using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebMerchant.BOLayer;

namespace WebMerchant.DALayer
{
    public class DAMerchantEstoreConfig
    {
        private SqlCommand _sqlcommond;

        internal int IUDEstoreConfig(BOMerchantEstoreConfig _bomecnfg)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDEstoreConfig";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@EstroeConfigId", _bomecnfg.EstroeConfigId);
                _sqlcommond.Parameters.AddWithValue("@QuestionNumber", _bomecnfg.QuestionNumber);
                _sqlcommond.Parameters.AddWithValue("@Price", _bomecnfg.Price);
                _sqlcommond.Parameters.AddWithValue("@ExamPicture", _bomecnfg.ExamPicture);
                _sqlcommond.Parameters.AddWithValue("@ExamDescription", _bomecnfg.ExamDescription);
                _sqlcommond.Parameters.AddWithValue("@ExamId", _bomecnfg.ExamId);
                _sqlcommond.Parameters.AddWithValue("@MerchantId", _bomecnfg.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@IsActive", _bomecnfg.IsActive);
                _sqlcommond.Parameters.AddWithValue("@IsDelete", _bomecnfg.IsDelete);
                _sqlcommond.Parameters.AddWithValue("@CreatedBy", _bomecnfg.Createdby);
                _sqlcommond.Parameters.AddWithValue("@CreatedDate", _bomecnfg.CreatedDate);
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _bomecnfg.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _bomecnfg.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@Event", _bomecnfg.Event);
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