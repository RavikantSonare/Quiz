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
    public partial class UserLogin : System.Web.UI.Page
    {
        private DataTable _datatable;
        private int userId = default(int);
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetail"] != null)
                {
                    BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                    userId = _bouserDetail.UserId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgirdViewExamDetail(_bouserDetail.UserId);
                        FillgridViewExamReport(_bouserDetail.UserId);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void FillgirdViewExamDetail(int uid)
        {
            BAExamManage _baexmmng = new BAExamManage();
            _datatable = new DataTable();
            _datatable = _baexmmng.SelectExamDetail("GetExWithUid", uid);
            gvExamDetail.DataSource = _datatable;
            gvExamDetail.DataBind();
        }

        private void FillgridViewExamReport(int uid)
        {
            BAExamReports _baexmrpt = new BALayer.BAExamReports();
            _datatable = new DataTable();
            _datatable = _baexmrpt.SelectExamReport("GetExRptWithUid", uid);
            gvExamReport.DataSource = _datatable;
            gvExamReport.DataBind();
        }

        protected void btnTestMode_Click(object sender, EventArgs e)
        {
            string fileName = "Quiz.txt";// Replace Your Filename with your required filename

            Response.ContentType = "application/octet-stream";

            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);

            Response.TransmitFile(Server.MapPath("~/ExamSimulator/" + fileName));//Place "YourFolder" your server folder Here

            Response.End();
        }
    }
}