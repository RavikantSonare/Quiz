using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BOLayer;

namespace DALayer
{
    public class DAQuestionType
    {
        public int IUDQuestionType(BOQuestionType bqtype)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDQuestionType";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@QuestionTypeId", bqtype.QuestionTypeId);
                _sqlcommand.Parameters.AddWithValue("@QuestionType", bqtype.QuestionType);
                _sqlcommand.Parameters.AddWithValue("@IsActive", bqtype.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", bqtype.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", bqtype.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", bqtype.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdateBy", bqtype.UpdateBy);
                _sqlcommand.Parameters.AddWithValue("@UpdateDate", bqtype.UpdateDate);
                _sqlcommand.Parameters.AddWithValue("@Event", bqtype.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnvalue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommand.Dispose();
                }
            }

            return returnvalue;
        }

        public DataTable SelectQuestionType(BOQuestionType bqtype)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetQuestionType";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", bqtype.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                return _dataTable;
            }
        }
    }
}
