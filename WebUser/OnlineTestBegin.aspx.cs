using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebUser.BOLayer;
using WebUser.BALayer;

namespace WebUser
{
    public partial class OnlineTestBegin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetail"] != null)
                {
                    BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["exmid"] != null)
                        {
                            string examid = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["exmid"]));
                            GetExamDetail(examid);
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void GetExamDetail(string examid)
        {
            BAExamManage _baexmmng = new BAExamManage();
            DataTable _datatable = new DataTable();
            _datatable = _baexmmng.SelectExamDetailWithID("GetExamWithId", Convert.ToInt32(examid));
            if (_datatable.Rows.Count > 0)
            {
                dlexamdetail.DataSource = _datatable;
                dlexamdetail.DataBind();
                //lblExamName.Text = _datatable.Rows[0]["ExamCode"].ToString();
                //btnreadytobegin.CommandArgument = _datatable.Rows[0]["ExamCodeId"].ToString();
            }
        }

        protected void btnreadytobegin_Click(object sender, EventArgs e)
        {
            Button btntest = (Button)sender;
            string val = HttpUtility.UrlEncode(Common.Encrypt(btntest.CommandArgument.Trim()));
            Response.Redirect("~/OnlineTestStart.aspx?exmid=" + val + "");
        }
    }
}