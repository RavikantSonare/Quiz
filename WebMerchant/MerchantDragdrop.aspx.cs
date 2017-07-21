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
    public partial class MerchantDragdrop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = ConnectionInfo.GetConnection())
            {
                if (Request.QueryString["quid"] != null)
                {
                    SqlDataAdapter _da = new SqlDataAdapter(@"SELECT tbl_QAManage.Question,tbl_QAnswer.Answer, 
                        tbl_QAnswer.RightAnswer,tbl_QAnswer.AnswerId FROM tbl_QAManage INNER JOIN tbl_QAnswer ON 
                        tbl_QAManage.QAId = tbl_QAnswer.QuestionId
                        WHERE tbl_QAManage.QAId = '" + Request.QueryString["quid"].ToString() + "'", sqlcon);
                    DataTable _datatable3 = new DataTable();
                    _da.Fill(_datatable3);
                    if (_datatable3.Rows.Count > 0)
                    {
                        lblquestion.Text = _datatable3.Rows[0]["Question"].ToString();
                        Repeater1.DataSource = _datatable3;
                        Repeater1.DataBind();
                        Repeater2.DataSource = _datatable3;
                        Repeater2.DataBind();
                    }
                }
            }

        }
    }
}