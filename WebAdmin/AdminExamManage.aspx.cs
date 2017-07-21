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
    public partial class AdminExamManage : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOExamManage _boexmng = new BOExamManage();
        private BAExamManage _baexmng = new BAExamManage();
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminDetail"] != null)
                {
                    BOAdminLogin _boadmin = (BOAdminLogin)Session["AdminDetail"];
                    adminId = _boadmin.AdminId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgridViewExamManage();
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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
            FillgridViewExamManage();
        }

        private void FillgridViewExamManage()
        {
            List<BOExamManage> predict = _baexmng.SelectExamManageListSearch("GETALL");
            if (!string.IsNullOrEmpty(txtExamCode.Text))
            {
                predict = predict.Where(exmmng => exmmng.ExamCode.ToUpper().Contains(txtExamCode.Text.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(txtSecondCategoryName.Text))
                predict = predict.Where(exmmng => exmmng.SecondCategoryName.ToUpper().Contains(txtSecondCategoryName.Text.ToUpper())).ToList();
            if (!string.IsNullOrEmpty(txtMerchantName.Text))
                predict = predict.Where(exmmng => exmmng.MerchantName.ToUpper().Contains(txtMerchantName.Text.ToUpper())).ToList();
            if (!string.IsNullOrEmpty(txtLevel.Text))
                predict = predict.Where(exmmng => exmmng.MerchantLevel.ToUpper().Contains(txtLevel.Text.ToUpper())).ToList();

            gvExamManage.DataSource = predict;
            gvExamManage.DataBind();

            //DataTable _datatable1 = new DataTable();
            //_datatable1 = _baexmng.SelectExamManageList("GETALL");
            //gvExamManage.DataSource = _datatable1;
            //gvExamManage.DataBind();
        }

        protected void lnkbtnactive_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int examcodeid = Convert.ToInt32(gvExamManage.DataKeys[gvrow.RowIndex].Value.ToString());
                    LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnactive");
                    bool isactive = Convert.ToBoolean(ID.CommandArgument);
                    if (isactive == true)
                    {
                        _boexmng.IsActive = false;
                    }
                    else
                    {
                        _boexmng.IsActive = true;
                    }
                    _boexmng.ExamCodeId = examcodeid;
                    _boexmng.UpdatedBy = adminId;
                    _boexmng.UpdatedDate = DateTime.UtcNow;
                    _boexmng.Event = "UpdateActive";
                    _baexmng.Update(_boexmng);
                    FillgridViewExamManage();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<BOExamManage> predict = _baexmng.SelectExamManageListSearch("GETALL");
                if (!string.IsNullOrEmpty(txtExamCode.Text))
                {
                    predict = predict.Where(exmmng => exmmng.ExamCode.ToUpper().Contains(txtExamCode.Text.ToUpper())).ToList();
                }
                if (!string.IsNullOrEmpty(txtSecondCategoryName.Text))
                    predict = predict.Where(exmmng => exmmng.SecondCategoryName.ToUpper().Contains(txtSecondCategoryName.Text.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(txtMerchantName.Text))
                    predict = predict.Where(exmmng => exmmng.MerchantName.ToUpper().Contains(txtMerchantName.Text.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(txtLevel.Text))
                    predict = predict.Where(exmmng => exmmng.MerchantLevel.ToUpper().Contains(txtLevel.Text.ToUpper())).ToList();

                gvExamManage.DataSource = predict;
                gvExamManage.DataBind();
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

        protected void gvExamManage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExamManage.PageIndex = e.NewPageIndex;
            FillgridViewExamManage();
        }
    }
}