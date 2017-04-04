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
    public class DASecondCategory
    {
        public int IUDSecondCategory(BOSecondCategory secat)
        {
            int returnvalue = default(int);
            SqlCommand _sqlcommand;
            using (SqlConnection _sqlconnection = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();

                _sqlcommand.Connection = _sqlconnection;
                _sqlcommand.CommandText = "SP_IUDSecondCategory";
                _sqlcommand.CommandType = CommandType.StoredProcedure;
                _sqlconnection.Open();

                _sqlcommand.Parameters.AddWithValue("@SecondCategoryId", secat.SecondCategoryId);
                _sqlcommand.Parameters.AddWithValue("@SecondCategoryName", secat.SecondCategoryName);
                _sqlcommand.Parameters.AddWithValue("@TopCategoryId", secat.TopCategoryId);
                _sqlcommand.Parameters.AddWithValue("@IsActive", secat.IsActive);
                _sqlcommand.Parameters.AddWithValue("@IsDelete", secat.IsDelete);
                _sqlcommand.Parameters.AddWithValue("@CreatedBy", secat.CreatedBy);
                _sqlcommand.Parameters.AddWithValue("@CreatedDate", secat.CreatedDate);
                _sqlcommand.Parameters.AddWithValue("@UpdatedBy", secat.UpdatedBy);
                _sqlcommand.Parameters.AddWithValue("@UpdatedDate", secat.UpdatedDate);
                _sqlcommand.Parameters.AddWithValue("@Event", secat.Event);
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

        public List<BOSecondCategory> SelectSecondCategoryList(BOSecondCategory secat)
        {
            DataTable _ta = new DataTable();
            _ta = SelectSecondCategory(secat);
            List<BOSecondCategory> _scatlist = (from sc in _ta.AsEnumerable()
                                                select new BOSecondCategory
                                                {
                                                    SecondCategoryId = sc.Field<int>("SecondCategoryId"),
                                                    SecondCategoryName = sc.Field<string>("SecondCategoryName"),
                                                    TopCategoryId = sc.Field<int>("TopCategoryId"),
                                                    TopCategoryName = sc.Field<string>("TopCategoryName")
                                                }).ToList();
            return _scatlist;
        }

        public DataTable SelectSecondCategory(BOSecondCategory secat)
        {
            SqlCommand _sqlcommand;
            SqlDataAdapter _sqlDataAdapter;
            using (SqlConnection _con = ConnectionInfo.GetConnection())
            {
                _sqlcommand = new SqlCommand();
                _sqlcommand.CommandText = "SP_GetSecondCategory";
                _sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommand.Connection = _con;
                _con.Open();
                _sqlcommand.Parameters.AddWithValue("@Event", secat.Event);
                _sqlDataAdapter = new SqlDataAdapter(_sqlcommand);

                DataTable _dataTable = new DataTable();
                _sqlDataAdapter.Fill(_dataTable);
                _con.Close();
                return _dataTable;
            }
        }
    }
}
