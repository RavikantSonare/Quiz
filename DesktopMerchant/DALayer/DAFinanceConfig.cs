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
    class DAFinanceConfig
    {
        internal int IUDFinanceConfig(BOFinanceConfig _bofcnfg)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_IUDFinanceConfig";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@FinanceConfigId", _bofcnfg.FinanceConfigId);
                _sqlcommand.Parameters.AddWithValue("@PaymentOptionId", _bofcnfg.PaymentOptionId);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bofcnfg.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@AccountEmail", _bofcnfg.AccountEmail);
                _sqlcommand.Parameters.AddWithValue("@FirstName", _bofcnfg.FirstName);
                _sqlcommand.Parameters.AddWithValue("@LastName", _bofcnfg.LastName);
                _sqlcommand.Parameters.AddWithValue("@Country", _bofcnfg.Country);
                _sqlcommand.Parameters.AddWithValue("@City", _bofcnfg.City);
                _sqlcommand.Parameters.AddWithValue("@BankOfName", _bofcnfg.BankOfName);
                _sqlcommand.Parameters.AddWithValue("@SwiftCode", _bofcnfg.SwiftCode);
                _sqlcommand.Parameters.AddWithValue("@IsActive", _bofcnfg.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", _bofcnfg.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", _bofcnfg.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", _bofcnfg.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", _bofcnfg.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("UpdatedDate", _bofcnfg.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", _bofcnfg.Event);
                _sqlcommand.Parameters.AddWithValue("@returnValue", 0).Direction = ParameterDirection.InputOutput;

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
                    _sqlcon.Close();
                    _sqlcommand.Dispose();
                }
            }
            return returnvalue;
        }

        internal List<BOFinanceConfig> SelectFinancConfigList(BOFinanceConfig _bofcnfg)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqldataadapter;

            using (SqlConnection _sqlcon = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetFinanceConfig";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlcon;

                _sqlcon.Open();

                _sqlcommand.Parameters.AddWithValue("@MerchantId", _bofcnfg.MerchantId);
                _sqlcommand.Parameters.AddWithValue("@Event", _bofcnfg.Event);

                _sqldataadapter = new SqlDataAdapter(_sqlcommand);
                DataTable _datatable = new DataTable();
                _sqldataadapter.Fill(_datatable);

                List<BOFinanceConfig> _bofincnfglist = (from li in _datatable.AsEnumerable()
                                                        select new BOFinanceConfig
                                                        {
                                                            FinanceConfigId = li.Field<int>("FinanceConfigId"),
                                                            PaymentOptionId = li.Field<int>("PaymentOptionId"),
                                                            PaymentOption = li.Field<string>("PaymentOption"),
                                                            MerchantId = li.Field<int>("MerchantId"),
                                                            AccountEmail = li.Field<string>("AccountEmail"),
                                                            FirstName = li.Field<string>("FirstName"),
                                                            LastName = li.Field<string>("LastName"),
                                                            Country = li.Field<string>("Country"),
                                                            City = li.Field<string>("City"),
                                                            BankOfName = li.Field<string>("BankOfName"),
                                                            SwiftCode = li.Field<string>("SwiftCode")
                                                        }).ToList();
                return _bofincnfglist;
            }
        }
    }
}
