using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BOLayer;

namespace DALayer
{
    public class DAExamManage
    {
        public List<BOExamManage> SelectExamManageList(BOExamManage _boexmmng)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqldataadapter;
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetExamManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;
                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@Event", _boexmmng.Event);
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                List<BOExamManage> _boexmmnglist = (from li in _datatable.AsEnumerable()
                                                    select new BOExamManage
                                                    {
                                                        ExamCodeId = li.Field<int>("ExamCodeId"),
                                                        ExamCode = li.Field<string>("ExamCode"),
                                                        SecondCategory = li.Field<string>("SecondCategoryName"),
                                                        MerchantName = li.Field<string>("MerchantName"),
                                                        Level = li.Field<string>("MerchantLevel"),
                                                        IsActive = li.Field<bool>("IsActive")
                                                    }).ToList();
                return _boexmmnglist;
            }
        }

        public int IUD_ExamManage(BOExamManage _boexmmng)
        {
            int returnValue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDExamManage";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@ExamCodeId", _boexmmng.ExamCodeId);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", _boexmmng.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", _boexmmng.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", _boexmmng.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", _boexmmng.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnValue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnValue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnValue;
        }
    }
}
