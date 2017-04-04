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
    public class DAThirdCategory
    {
        public int IUDThirdCategory(BOThirdCategory btcat)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommnd;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommnd = new SqlCommand();
                _sqlcommnd.Connection = _sqlconnection;
                _sqlcommnd.CommandText = "SP_IUDThirdCategory";
                _sqlcommnd.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommnd.Parameters.AddWithValue("@ThirdCategoryId", btcat.ThirdCategoryId);
                _sqlcommnd.Parameters.AddWithValue("@ThirdCategoryName", btcat.ThirdCategoryName);
                _sqlcommnd.Parameters.AddWithValue("@SecondCategoryId", btcat.SecondCategoryId);
                _sqlcommnd.Parameters.AddWithValue("@IsActive", btcat.IsActive);
                _sqlcommnd.Parameters.AddWithValue("@IsDelete", btcat.IsDelete);
                _sqlcommnd.Parameters.AddWithValue("@CreatedBy", btcat.CreatedBy);
                _sqlcommnd.Parameters.AddWithValue("@CreatedDate", btcat.CreatedDate);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedBy", btcat.UpdatedBy);
                _sqlcommnd.Parameters.AddWithValue("@UpdatedDate", btcat.UpdatedDate);
                _sqlcommnd.Parameters.AddWithValue("@Event", btcat.Event);
                _sqlcommnd.Parameters.AddWithValue("@returnValue", 0).Direction = System.Data.ParameterDirection.InputOutput;

                try
                {
                    _sqlcommnd.ExecuteNonQuery();
                    returnvalue = Convert.ToInt32(_sqlcommnd.Parameters["@returnValue"].Value);
                }
                catch
                {
                    returnvalue = 100;
                }
                finally
                {
                    _sqlconnection.Close();
                    _sqlcommnd.Dispose();
                }
            }
            return returnvalue;
        }

        public List<BOThirdCategory> SelectThirdCategoryList(BOThirdCategory btcat)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetThirdCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", btcat.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);

                List<BOThirdCategory> tcatList = (from cu in _dataTable.AsEnumerable()
                                                  select new BOThirdCategory
                                                  {
                                                      ThirdCategoryId = cu.Field<int>("ThirdCategoryId"),
                                                      ThirdCategoryName = cu.Field<string>("ThirdCategoryName"),
                                                      SecondCategoryId = cu.Field<int>("SecondCategoryId"),
                                                      SecondCategoryName = cu.Field<string>("SecondCategoryName")
                                                  }).ToList();

                return tcatList;
            }
        }
    }
}
