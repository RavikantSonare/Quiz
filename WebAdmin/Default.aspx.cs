using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class Default : System.Web.UI.Page
    {
        private BAAdminLogin _baadminlogin = new BAAdminLogin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Adminid"] != null)
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateForm())
                {
                    BOAdminLogin _boadminlogin = _baadminlogin.SelectAdminloginDetail("GETALL", txtUserName.Text, Common.EncryptPassword(txtPassword.Text));
                    if (_boadminlogin != null)
                    {
                        if (txtPassword.Text == Common.DecryptPassword(_boadminlogin.Password))
                        {
                            Session["Adminid"] = _boadminlogin.AdminId;
                            Session["AdminDetail"] = _boadminlogin;
                            if (Session["Adminid"] != null)
                                Response.Redirect("AdminLogin.aspx", false);
                        }
                        else
                        {
                            lblerror.InnerText = "Password invalid";
                            lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Username or Password invalid";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                        txtUserName.Focus();
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

        private bool validateForm()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter username";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtUserName.Focus();
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
            }
            else
            {
                lblerror.InnerText = "";
            }
            return ret;
        }
    }
}