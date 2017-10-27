using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Estore.BOLayer;
using Estore.BALayer;

namespace Estore
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        private BAMerchantManage _bamermng = new BAMerchantManage();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMerchantLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMerchantemailLogin.Text) && !string.IsNullOrEmpty(txtMerchantpwdLogin.Text))
                {
                    BOMerchantManage _bomerchantDetail = _bamermng.SelectMerchantLogin("MerchantLogin", txtMerchantemailLogin.Text, Encryptdata(txtMerchantpwdLogin.Text));
                    if (_bomerchantDetail != null)
                    {

                        if (txtMerchantpwdLogin.Text == Decryptdata(_bomerchantDetail.Password))
                        {
                            if (_bomerchantDetail.ActiveStatus)
                            {
                                Session["Merchantid"] = _bomerchantDetail.MerchantId;
                                Session["merchantDetail"] = _bomerchantDetail;
                                if (Session["Merchantid"] != null)
                                    Response.Redirect("http://localhost:60956/MerchantLogin.aspx", false);
                            }
                            else
                            {
                                lblerror.InnerText = "Your account is currently not active. Contact your administrator to activate it.";
                                lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                            }
                        }
                        else
                        {
                            lblerror.InnerText = "Password invalid";
                            lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                            txtMerchantpwdLogin.Focus();
                        }

                    }
                    else
                    {
                        lblerror.InnerText = "Username or Password invalid";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                        txtMerchantemailLogin.Focus();
                    }
                }
                else
                {
                    lblerror.InnerText = "Please Enter Correct UserName/Password";
                    lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                    txtMerchantemailLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                lblerror.InnerText = "Server not respond";
                lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
            }
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}