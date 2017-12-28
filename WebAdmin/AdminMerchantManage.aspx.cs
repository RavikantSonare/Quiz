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
    public partial class AdminMerchantManage : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOMerchantManage _bommng = new BOMerchantManage();
        private BAMerchantManage _bammng = new BAMerchantManage();
        public enum MessageType { Success, Error, Info, Warning };
        DataTable _dtlvl = new DataTable();

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
                        FillgridViewMerchantManage();
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
            FillgridViewMerchantManage();
        }

        private void FillgridViewMerchantManage()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bammng.SelectExamManage("GETALL");
            gvMerchantManage.DataSource = _datatable1;
            gvMerchantManage.DataBind();
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
                    int mid = Convert.ToInt32(gvMerchantManage.DataKeys[gvrow.RowIndex].Value.ToString());
                    LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnactive");
                    bool isactive = Convert.ToBoolean(ID.CommandArgument);
                    if (isactive == true)
                    {
                        _bommng.ActiveStatus = false;
                    }
                    else
                    {
                        _bommng.ActiveStatus = true;
                    }
                    _bommng.MerchantId = mid;
                    _bommng.UpdatedBy = adminId;
                    _bommng.UpdatedDate = DateTime.UtcNow;
                    _bommng.Event = "UpdateStatus";
                    _bammng.UpdateStatus(_bommng);
                    FillgridViewMerchantManage();
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

        protected void gvMerchantManage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtAction = (LinkButton)e.Row.FindControl("lnkbtnactive");
                    HiddenField lblStatus = (HiddenField)e.Row.FindControl("hdactive");
                    bool active = Convert.ToBoolean(lblStatus.Value);
                    lbtAction.Text = active ? "Active" : "Inactive";
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void gvMerchantManage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMerchantManage.PageIndex = e.NewPageIndex;
            FillgridViewMerchantManage();
        }

        protected void btnmodify_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    //Button lnkbtn = sender as Button;
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int mid = Convert.ToInt32(gvMerchantManage.DataKeys[gvrow.RowIndex].Value.ToString());
                    if (mid > 0)
                    {
                        string qid = HttpUtility.UrlEncode(Common.Encrypt(Convert.ToString(mid)));
                        Response.Redirect("AdminMerchantManageEdit.aspx?mid=" + qid, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }
    }
}