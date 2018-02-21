using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminPasswordChange : System.Web.UI.Page
    {
        private int adminId = default(int);
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["AdminDetail"] != null)
                    {
                        BOAdminLogin _boadmin = (BOAdminLogin)Session["AdminDetail"];
                        ViewState["adminid"] = _boadmin.AdminId;
                        txtUserName.Text = _boadmin.UserName;
                        txtPassword.Text = txtConfirmPwd.Text = _boadmin.Password;

                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
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
        }

        protected void lnkbtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (validateForm())
                    {
                        BOAdminLogin _boadminobj = new BOAdminLogin();
                        BAAdminLogin _baadmin = new BAAdminLogin();
                        _boadminobj.AdminId = Convert.ToInt32(ViewState["adminid"]);
                        _boadminobj.UserName = txtUserName.Text;
                        _boadminobj.Password = Common.EncryptPassword(txtConfirmPwd.Text);
                        int returnvalue = _baadmin.ChangePassowrd("ChangePwd", _boadminobj);
                        if (returnvalue == 2)
                        {
                            ShowMessage("Password change successful", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage("Some technical error", MessageType.Info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                lblerror.InnerText = "Server not respond";
                lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private bool validateForm()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter username";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtUserName.Focus();
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter password";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtPassword.Focus();
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtConfirmPwd.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter confirm password";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtConfirmPwd.Focus();
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (txtPassword.Text.Equals(txtConfirmPwd.Text))
            {
                lblerror.InnerText = "";
            }
            else
            {
                ret = false;
                lblerror.InnerText = "Password and confirm password not match";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtConfirmPwd.Focus();
                return false;
            }
            return ret;
        }
    }
}