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
    class DAMerchantBalance
    {
        SqlCommand _sqlcommand;
        internal decimal SelectMerchantBalance(string eventtxt, int mid)
        {
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetMerchantBalance";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlcommand.Connection = _sqlconnection;

                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@Event", eventtxt);
                _sqlcommand.Parameters.AddWithValue("@MerchantId", mid);

                decimal _blnc = 0;

                try
                {
                    _blnc = Convert.ToDecimal(_sqlcommand.ExecuteScalar());
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _sqlcommand.Dispose();
                    _sqlconnection.Close();
                }

                return _blnc;
            }
        }
    }
}
