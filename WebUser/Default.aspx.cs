using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WebUser.BOLayer;
using WebUser.BALayer;

namespace WebUser
{
    public partial class Default : System.Web.UI.Page
    {
        private BAUser _bausr = new BAUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Userid"] != null)
                {
                    Response.Redirect("UserLogin.aspx", false);
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
                    BOUser _bousr = _bausr.SelectUserDetail("GetUserDetail", txtEmailId.Text, Encryptdata(txtPassword.Text));
                    if (_bousr != null)
                    {
                        if (txtPassword.Text == Decryptdata(_bousr.AccessPassword))
                        {
                            Session["Userid"] = _bousr.UserId;
                            Session["UserDetail"] = _bousr;
                            if (Session["Userid"] != null)
                                Response.Redirect("UserLogin.aspx", false);
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
                        lblerror.InnerText = "Email Id or Password invalid";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
                        txtEmailId.Focus();
                    }
                }
                else
                {
                    lblerror.InnerText = "Please Enter Correct Email Id/Password";
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