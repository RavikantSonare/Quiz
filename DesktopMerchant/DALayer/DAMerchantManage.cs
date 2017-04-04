using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopMerchant.BOLayer;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DesktopMerchant.DALayer
{
    class DAMerchantManage
    {
        BOMerchantManage _bomermng = new BOMerchantManage();
        SqlCommand _sqlcommond;
        SqlDataAdapter _sqldataadapter;

        public BOMerchantManage SelectLoginUsers(string Event, string username, string password)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetMerchantManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@username", username);
                _sqlcommond.Parameters.AddWithValue("@password", password);
                _sqlcommond.Parameters.AddWithValue("@Event", Event);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();
                _bomermng = (from list in _datatable.AsEnumerable()
                             select new BOMerchantManage
                             {
                                 MerchantId = list.Field<int>("MerchantId"),
                                 UserName = list.Field<string>("UserName"),
                                 Password = list.Field<string>("Password")
                             }).FirstOrDefault();
                return _bomermng;
            }

        }

        internal DateTime SelectValiddate(string Event, int merchantId)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetMerchantManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@MerchantId", merchantId);
                _sqlcommond.Parameters.AddWithValue("@Event", Event);

                _sqlcon.Open();
                DateTime vdate = Convert.ToDateTime(_sqlcommond.ExecuteScalar());

                return vdate;
            }
        }

        public List<BOMerchantManage> SelectMerchantDetail(int loginid, BOMerchantManage _bomm)
        {

            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommond = new SqlCommand();
                _sqlcommond.CommandText = "SP_GetMerchantManage";
                _sqlcommond.Connection = _sqlcon;
                _sqlcommond.CommandType = CommandType.StoredProcedure;

                _sqlcommond.Parameters.AddWithValue("@MerchantId", loginid);
                _sqlcommond.Parameters.AddWithValue("@Event", _bomm.Event);

                _sqlcon.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommond);

                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlcon.Close();
                List<BOMerchantManage> _merfr = (from cu in _datatable.AsEnumerable()
                                                 select new BOMerchantManage
                                                 {
                                                     MerchantId = cu.Field<int>("MerchantId"),
                                                     EndDate = cu.Field<DateTime>("EndDate"),
                                                     MerchantName = cu.Field<string>("MerchantName"),
                                                     UserName = cu.Field<string>("UserName"),
                                                     MerchantLevel = cu.Field<string>("MerchantLevel")

                                                 }).ToList();

                return _merfr;
            }
        }
    }
}
