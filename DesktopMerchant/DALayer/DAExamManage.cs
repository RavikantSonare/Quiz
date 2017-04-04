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
    class DAExamManage
    {
        BOExamManage _bomermng = new BOExamManage();
        SqlCommand _sqlcommond;
        SqlDataAdapter _sqldataadapter;

        public List<BOExamManage> SelectMerchantExam(BOExamManage _boexmmng)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetExamManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@MerchantId", _boexmmng.MerchantId);
                _sqlcommond.Parameters.AddWithValue("@Event", _boexmmng.Event);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();
                List<BOExamManage> _merfr = (from cu in _datatable.AsEnumerable()
                                             select new BOExamManage
                                             {
                                                 ExamCodeId = cu.Field<int>("ExamCodeId"),
                                                 ExamCode = cu.Field<string>("ExamCode"),
                                                 SecondCategory = cu.Field<string>("SecondCategoryName"),
                                                 TestTime = cu.Field<int>("TestTime"),
                                                 ValidDate = cu.Field<DateTime>("ValidDate")
                                             }).ToList();

                return _merfr;
            }
        }
    }
}
