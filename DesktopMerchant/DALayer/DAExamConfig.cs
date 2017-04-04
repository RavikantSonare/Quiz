using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BOLayer;

namespace DesktopMerchant.DALayer
{
    class DAExamConfig
    {
        SqlCommand _sqlcommond;
        SqlDataAdapter _sqldataadapter;

        internal List<BOExamConfig> SelectExamconfglist(BOExamConfig _boexmcnfg)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@MerchantId", _boexmcnfg.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@Event", _boexmcnfg.Event);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();
                List<BOExamConfig> _merfr = (from cu in _datatable.AsEnumerable()
                                             select new BOExamConfig
                                             {
                                                 ExamCodeId = cu.Field<int>("ExamCodeId"),
                                                 ExamCode = cu.Field<string>("ExamCode"),
                                                 ExamTitle = cu.Field<string>("ExamTitle"),
                                                 Category = cu.Field<string>("TopCategoryName") + "/" + cu.Field<string>("SecondCategoryName"),
                                                 TopCategory = cu.Field<string>("TopCategoryName"),
                                                 SecondCategory = cu.Field<string>("SecondCategoryName"),
                                                 PassingPercentage = cu.Field<decimal>("PassingPercentage"),
                                                 TestTime = cu.Field<int>("TestTime"),
                                                 TestOption = cu.Field<string>("TestOption"),
                                                 ValidDate = cu.Field<DateTime>("ValidDate")
                                             }).ToList();

                return _merfr;
            }
        }

        public int IUDExamConfig(BOExamConfig _boexmcnfg)
        {
            int returnvalue = default(int);
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_IUDExamManage";
                _sqlcommond.CommandType = CommandType.StoredProcedure;
                _sqlcommond.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommond.Parameters.AddWithValue("@ExamCodeId", _boexmcnfg.ExamCodeId);
                _sqlcommond.Parameters.AddWithValue("@ExamCode", _boexmcnfg.ExamCode);
                _sqlcommond.Parameters.AddWithValue("@ExamTitle", _boexmcnfg.ExamTitle);
                _sqlcommond.Parameters.AddWithValue("@TopCategoryId", _boexmcnfg.TopCategoryId);
                _sqlcommond.Parameters.AddWithValue("@SecondCategoryId", _boexmcnfg.SecondCategoryId);
                _sqlcommond.Parameters.AddWithValue("@PassingPercentage", _boexmcnfg.PassingPercentage);
                _sqlcommond.Parameters.AddWithValue("@TestTime", _boexmcnfg.TestTime);
                _sqlcommond.Parameters.AddWithValue("@TestOption", _boexmcnfg.TestOption);
                _sqlcommond.Parameters.AddWithValue("@ValidDate", _boexmcnfg.ValidDate);
                _sqlcommond.Parameters.AddWithValue("@MerchantId", _boexmcnfg.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@IsActive", _boexmcnfg.IsActive);
                _sqlcommond.Parameters.AddWithValue("@IsDelete", _boexmcnfg.IsDelete);
                _sqlcommond.Parameters.AddWithValue("@CreatedBy", _boexmcnfg.CreatedBy);
                _sqlcommond.Parameters.AddWithValue("@CreatedDate", _boexmcnfg.CreatedDate);
                _sqlcommond.Parameters.AddWithValue("@UpdatedBy", _boexmcnfg.UpdatedBy);
                _sqlcommond.Parameters.AddWithValue("@UpdatedDate", _boexmcnfg.UpdatedDate);
                _sqlcommond.Parameters.AddWithValue("@Event", _boexmcnfg.Event);
                _sqlcommond.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommond.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommond.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnvalue = 100;
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
