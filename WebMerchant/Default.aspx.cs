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

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    BOMerchantManage _bomerchantDetail = _bamermng.SelectMerchantLogin("MerchantLogin", txtUserName.Text, Encryptdata(txtPassword.Text));
                    if (_bomerchantDetail != null)
                    {
                        if (txtPassword.Text == Decryptdata(_bomerchantDetail.Password))
                        {
                            Session["Merchantid"] = _bomerchantDetail.MerchantId;
                            Session["merchantDetail"] = _bomerchantDetail;
                            if (Session["Merchantid"] != null)
                                Response.Redirect("Merchant-Login.aspx");
                        }
                        else
                        {
                            Response.Write(@"<script language='javascript'>alert('Password invalid')</script>");
                        }
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Username or Password invalid')</script>");
                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Please Enter Correct UserName/Password')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex + "')</script>");
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