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
    public partial class AdminMerchantManageEdit : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOMerchantManage _bommng = new BOMerchantManage();
        private BAMerchantManage _bammng = new BAMerchantManage();
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
                        if (Request.QueryString["mID"] != "")
                        {
                            ViewState["querystring"] = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["mID"]));
                            FillMerchantDetail(Convert.ToInt32(ViewState["querystring"]));
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
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        private void FillMerchantDetail(int mid)
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bammng.SelectMerchantManage("GETWITHID", mid);
            if (_datatable1.Rows.Count > 0)
            {
                txtMerchantName.Text = _datatable1.Rows[0]["MerchantName"].ToString();
                txtUserName.Text = _datatable1.Rows[0]["UserName"].ToString();
                txtTelephone.Text = _datatable1.Rows[0]["Telephone"].ToString();
                txtMerchantLevel.Text = _datatable1.Rows[0]["MerchantLevel"].ToString();
                DateTime startdate = Convert.ToDateTime(_datatable1.Rows[0]["StartDate"]);
                txtStartDate.Text = startdate.ToString("yyyy-MM-dd");
                DateTime enddate = Convert.ToDateTime(_datatable1.Rows[0]["EndDate"]);
                txtEndDate.Text = enddate.ToString("yyyy-MM-dd");
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {
                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                _bommng.MerchantId = Convert.ToInt32(ViewState["querystring"]);
                _bommng.EndDate = Convert.ToDateTime(txtEndDate.Text);
                _bommng.UpdatedBy = adminId;
                _bommng.UpdatedDate = DateTime.UtcNow;
                _bommng.Event = "Update";
                int result = _bammng.Update(_bommng);
                if (result == 2)
                {
                    ShowMessage("End date updated successfully", MessageType.Success);
                }
            }
            else
            {
            }
        }
    }
}