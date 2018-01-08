using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class Default : System.Web.UI.Page
    {
        private BAMerchantManage _bamermng = new BAMerchantManage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Merchantid"] != null)
                {
                    Response.Redirect("MerchantLogin.aspx", false);
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
                if (!string.IsNullOrEmpty(txtEmailId.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    BOMerchantManage _bomerchantDetail = _bamermng.SelectMerchantLogin("MerchantLogin", txtEmailId.Text, Common.Encryptdata(txtPassword.Text));
                    if (_bomerchantDetail != null)
                    {

                        if (txtPassword.Text == Common.Decryptdata(_bomerchantDetail.Password))
                        {
                            if (_bomerchantDetail.EndDate > DateTime.Now)
                            {
                                if (_bomerchantDetail.ActiveStatus)
                                {
                                    Session["Merchantid"] = _bomerchantDetail.MerchantId;
                                    Session["merchantDetail"] = _bomerchantDetail;
                                    if (Session["Merchantid"] != null)
                                        Response.Redirect("MerchantLogin.aspx", false);
                                }
                                else
                                {
                                    lblerror.InnerText = "Your account is currently not active. Contact your administrator to activate it.";
                                    lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                                }
                            }
                            else
                            {
                                lblerror.InnerText = "Your account is expired. contact to administrator";
                                lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                            }
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
                        lblerror.InnerText = "Email id or Password invalid";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                        txtEmailId.Focus();
                    }
                }
                else
                {
                    lblerror.InnerText = "Please Enter Correct Email id/Password";
                    lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                    txtEmailId.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                lblerror.InnerText = "Server not respond";
                lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
            }
        }
    }
}