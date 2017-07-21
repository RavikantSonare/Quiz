using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private int Adminid = default(int);
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminDetail"] != null)
                {
                    BOAdminLogin _boadminlogin = (BOAdminLogin)Session["AdminDetail"];
                    Adminid = _boadminlogin.AdminId;
                    if (!IsPostBack)
                    {
                        FillgridViewExamDetail();
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

        private void FillgridViewExamDetail()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baexmmng.SelectExamManageList("GETALL");
            gvExamDetail.DataSource = _datatable1;
            gvExamDetail.DataBind();
        }

        protected void lnkbtnactive_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int examcodeid = Convert.ToInt32(gvExamDetail.DataKeys[gvrow.RowIndex].Value.ToString());
                LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnactive");
                bool isactive = Convert.ToBoolean(ID.CommandArgument);
                if (isactive == true)
                {
                    _boexmmng.IsActive = false;
                }
                else
                {
                    _boexmmng.IsActive = true;
                }
                _boexmmng.ExamCodeId = examcodeid;
                _boexmmng.UpdatedBy = Adminid;
                _boexmmng.UpdatedDate = DateTime.UtcNow;
                _boexmmng.Event = "UpdateActive";
                _baexmmng.Update(_boexmmng);
                FillgridViewExamDetail();
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

        protected void gvExamDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExamDetail.PageIndex = e.NewPageIndex;
            FillgridViewExamDetail();
        }
    }
}