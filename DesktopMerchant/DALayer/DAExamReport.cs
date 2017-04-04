using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DesktopMerchant.BOLayer;
using DesktopMerchant.BALayer;

namespace DesktopMerchant.DALayer
{
    class DAExamReport
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;

        internal List<BOExamReport> SelectExamreportList(string v, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetExamReport";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@Event", v);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);

                DataTable _datatable = new DataTable();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                _sqldataadapter.Fill(_datatable);

                List<BOExamReport> _boexmrptl = (from li in _datatable.AsEnumerable()
                                                 select new BOExamReport
                                                 {
                                                     ExamReportId = li.Field<int>("ExamReportId"),
                                                     UserId = li.Field<int>("UserId"),
                                                     UserName = li.Field<string>("UserName"),
                                                     ExamCode = li.Field<string>("ExamCode"),
                                                     CategoryId = li.Field<int>("CategoryId"),
                                                     CategoryName = li.Field<string>("SecondCategoryName"),
                                                     Result = li.Field<bool>("Result"),
                                                     Score = li.Field<decimal>("Score"),
                                                     AllowPrint = li.Field<bool>("AllowPrint"),
                                                     DigitalCertificateId = li.Field<int>("DigitalCertificateId"),
                                                     CertificationNo = li.Field<int>("CertificationNo"),
                                                     //MerchantId = li.Field<int>("MerchantId"),

                                                 }
                                          ).ToList();

                return _boexmrptl;

            }
        }
    }
}
