using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebMerchant
{
    public partial class MerchantImageMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = ConnectionInfo.GetConnection())
            {
                if (Request.QueryString["answerId"] != null)
                {
                    SqlDataAdapter _da = new SqlDataAdapter("Select * from tbl_QAnswer Where AnswerId='" + Request.QueryString["answerId"].ToString() + "'", sqlcon);
                    DataTable _datatable3 = new DataTable();
                    _da.Fill(_datatable3);
                    Label1.Text = _datatable3.Rows[0]["Answer"].ToString();
                }
            }
        }

    }
}