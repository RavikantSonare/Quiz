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
    public class DAMerchantManage
    {
        SqlCommand _sqlcommand;
        SqlDataAdapter _sqldataadapter;
        DataTable _datatable;

        internal BOMerchantManage SelectmerchantLogin(string Event, string emailid, string password)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@emailid", emailid);
                _sqlcommand.Parameters.AddWithValue("@password", password);
                _sqlcommand.Parameters.AddWithValue("@Event", Event);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();
                BOMerchantManage _bomermng = new BOMerchantManage();
                _bomermng = (from list in _datatable.AsEnumerable()
                             select new BOMerchantManage
                             {
                                 MerchantId = list.Field<int>("MerchantId"),
                                 MerchantName = list.Field<string>("MerchantName"),
                                 EmailId = list.Field<string>("EmailId"),
                                 UserName = list.Field<string>("UserName"),
                                 Password = list.Field<string>("Password"),
                                 MerchantLevelId = list.Field<int>("MerchantLevelId"),
                                 MerchantLevel = list.Field<string>("MerchantLevel"),
                                 ActiveStatus = list.Field<bool>("ActiveStatus"),
                                 EndDate = list.Field<DateTime>("EndDate"),
                                 StateId = list.Field<int>("StateId"),
                                 CountryId = list.Field<int>("CountryId"),
                                 Telephone = list.Field<string>("Telephone"),
                                 Brand = list.Field<string>("Brand"),
                                 Picture = list.Field<string>("Picture"),
                                 About = list.Field<string>("About")
                             }).FirstOrDefault();
                return _bomermng;
            }
        }

        internal DateTime ValidDate(string v, int merchantId)
        {
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantManage";
                _sqlcommand.Connection = _sqlcon;
                _sqlcommand.CommandType = CommandType.StoredProcedure;

                _sqlcommand.Parameters.AddWithValue("@MerchantId", merchantId);
                _sqlcommand.Parameters.AddWithValue("@Event", v);

                _sqlcon.Open();
                DateTime vdate = Convert.ToDateTime(_sqlcommand.ExecuteScalar());

                return vdate;
            }
        }

        internal DataTable SelectMerchantDetail(string eventtxt, int merchantid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlcommand.Parameters.AddWithValue("@MerchantId", merchantid);
                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);

                _sqlconnection.Open();
                _sqldataadapter = new SqlDataAdapter(_sqlcommand);

                _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);
                _sqlconnection.Close();

                return _datatable;
            }
        }

        public int IUDMerchantManage(BOMerchantManage _bomermng)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDMerchantManage";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bomermng.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@MerchantName", _bomermng.MerchantName);
                _sqlcommand.Parameters.AddWithValue("@UserName", _bomermng.UserName);
                _sqlcommand.Parameters.AddWithValue("@Password", _bomermng.Password);
                _sqlcommand.Parameters.AddWithValue("@StateId", _bomermng.StateId);
                _sqlcommand.Parameters.AddWithValue("@Telephone", _bomermng.Telephone);
                _sqlcommand.Parameters.AddWithValue("@MerchantLevelId", _bomermng.MerchantLevelId);
                _sqlcommand.Parameters.AddWithValue("@StartDate", _bomermng.StartDate);
                _sqlcommand.Parameters.AddWithValue("@EndDate", _bomermng.EndDate);
                _sqlcommand.Parameters.AddWithValue("@ActiveStatus", _bomermng.ActiveStatus);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bomermng.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bomermng.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bomermng.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bomermng.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bomermng.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", _bomermng.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@EmailId", _bomermng.EmailId);
                _sqlcommand.Parameters.AddWithValue("@Brand", _bomermng.Brand);
                _sqlcommand.Parameters.AddWithValue("@Picture", _bomermng.Picture);
                _sqlcommand.Parameters.AddWithValue("@About", _bomermng.About);
                _sqlcommand.Parameters.AddWithValue("@Event", _bomermng.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommand.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommand.Parameters["@returnValue"].Value);
                }
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