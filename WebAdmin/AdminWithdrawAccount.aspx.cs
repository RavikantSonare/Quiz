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
    public partial class AdminWithdrawAccount : System.Web.UI.Page
    {
        private BAFinanceConfig _bafcng = new BAFinanceConfig();
        private int adminId = default(int);
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
                        if (Request.QueryString["mID"] != "")
                        {
                            ViewState["querystring"] = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["mID"]));
                            FillgridViewWithDrawAccountDetail(Convert.ToInt32(ViewState["querystring"]));
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

        private void FillgridViewWithDrawAccountDetail(int mid)
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bafcng.SelectFinanceConfigDetail("GetAllWithMId", mid);
            gvWithdrawAccont.DataSource = _datatable1;
            gvWithdrawAccont.DataBind();
            if (_datatable1.Rows[0]["PaymentOptionId"].ToString() == "1")
            {
                gvWithdrawAccont.Columns[3].Visible = false;
                gvWithdrawAccont.Columns[4].Visible = false;
                gvWithdrawAccont.Columns[5].Visible = false;
                gvWithdrawAccont.Columns[6].Visible = false;
                gvWithdrawAccont.Columns[7].Visible = false;
                gvWithdrawAccont.Columns[8].Visible = false;
            }
            else if (_datatable1.Rows[0]["PaymentOptionId"].ToString() == "2")
            {
                gvWithdrawAccont.Columns[2].Visible = false;
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}