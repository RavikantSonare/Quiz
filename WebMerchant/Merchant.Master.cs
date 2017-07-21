using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMerchant.BOLayer;

namespace WebMerchant
{
    public partial class Merchant : System.Web.UI.MasterPage
    {
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    if (!IsPostBack)
                    {
                        if (_bomerchantDetail.MerchantLevel == "Free")
                        {
                            menu3.Visible = menu4.Visible = menu5.Visible = menu6.Visible = false;
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

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void lnkbtnlogout_Click(object sender, EventArgs e)
        {
            Session["Merchantid"] = "";
            Session["Merchantid"] = null;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}