using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;
using System.Web.Script.Serialization;

namespace WebMerchant
{
    public partial class MerchantRegistration : System.Web.UI.Page
    {
        private BOMerchantManage _bomermng = new BOMerchantManage();
        private BAMerchantManage _bamermng = new BAMerchantManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["order_number"] != null && Session["registationid"] != null)
            {
                string url = HttpContext.Current.Request.Url.Query;
                var dict = HttpUtility.ParseQueryString(url);
                var json = new JavaScriptSerializer().Serialize(
                                    dict.AllKeys.ToDictionary(k => k, k => dict[k])
                           );
                InsertPaymentDetail(Session["registationid"].ToString(), Request.QueryString["merchant_order_id"], Request.QueryString["sid"], Request.QueryString["key"], Request.QueryString["order_number"], Request.QueryString["currency_code"], Request.QueryString["invoice_id"], Request.QueryString["total"], Request.QueryString["credit_card_processed"], Request.QueryString["pay_method"], json);
                lblerror.InnerText = "Payment Success";
                lblerror.Attributes.Add("Style", "display: block;color: Green;");
            }
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

        private void InsertPaymentDetail(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10, string json)
        {
            BOMerchantPayment _bomerpmt = new BOLayer.BOMerchantPayment();
            BAMerchantPayment _bamerpmt = new BALayer.BAMerchantPayment();
            _bomerpmt.MerchantId = Convert.ToInt32(v1);
            _bomerpmt.MerchantOrderNo = v2;
            _bomerpmt.SId = v3;
            _bomerpmt.Key = v4;
            _bomerpmt.Order_Number = v5;
            _bomerpmt.CurrencyCode = v6;
            _bomerpmt.InvoiceId = v7;
            _bomerpmt.TotalAmount = Convert.ToDecimal(v8);
            _bomerpmt.CCProcess = v9;
            _bomerpmt.PayMethod = v10;
            _bomerpmt.Date = DateTime.UtcNow;
            _bomerpmt.PaymentData = json;
            _bomerpmt.IsActive = true;
            _bomerpmt.IsDelete = false;
            _bomerpmt.Event = "Insert";
            _bamerpmt.IUDPaymentDetail(_bomerpmt);
            lblerror.InnerText = "Registration Success";
            lblerror.Attributes.Add("Style", "display: block;color: Green;");
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateForm())
                {
                    _bomermng.Password = Encryptdata(txtPassword.Text);
                    _bomermng.EmailId = txtEmailId.Text;
                    _bomermng.StartDate = DateTime.UtcNow;
                    _bomermng.EndDate = DateTime.UtcNow.AddYears(1);
                    _bomermng.ActiveStatus = false;
                    _bomermng.IsActive = true;
                    _bomermng.IsDelete = false;
                    _bomermng.CreatedBy = 0;
                    _bomermng.CreatedDate = DateTime.UtcNow;
                    _bomermng.UpdatedBy = 0;
                    _bomermng.UpdatedDate = DateTime.UtcNow;
                    _bomermng.MerchantId = 0;
                    _bomermng.Event = "Insert";
                    int returnvalue = _bamermng.Insert(_bomermng);
                    switch (returnvalue)
                    {
                        case -1:
                            lblerror.InnerText = "Sorry, your email address is already in use.";
                            lblerror.Attributes.Add("Style", "display: block;color: Red;");
                            break;
                        default:
                            Session["registationid"] = returnvalue;
                            lblerror.InnerText = "Registration Success";
                            lblerror.Attributes.Add("Style", "display: block;color: Green;");
                            //SendHTMLMail(txtEmailId.Text, txtPassword.Text);
                            Response.AppendHeader("Refresh", "1;url=MerchantCheckoutLevel.aspx?emid=" + Common.Encryptdata(txtEmailId.Text) + "&mid=" + Common.Encryptdata(returnvalue.ToString()));
                            break;
                    }
                }
                else
                {
                    lblerror.InnerText = "Please enter red mark field";
                    lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
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
            if (string.IsNullOrEmpty(txtEmailId.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter email id";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
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
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            return ret;
        }

        public void SendHTMLMail(string email, string Password)
        {
            StreamReader reader = new StreamReader(Server.MapPath("~/MerchantRegsitrationEmail.html"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            myString = readFile;
            myString = myString.Replace("$$MerchantEmail$$", email);
            myString = myString.Replace("$$Password$$", Password);

            SmtpClient smtpClient = new SmtpClient("relay-hosting.secureserver.net");
            MailMessage message = new MailMessage();

            // MailAddress fromAddress = new MailAddress("info@mymail.org");
            MailAddress toAddress = new MailAddress(HttpUtility.HtmlEncode(email));

            // message.From = fromAddress;
            message.To.Add(toAddress);

            message.Subject = "Registration Detail";
            message.IsBodyHtml = true;
            message.Body = myString.ToString();
            smtpClient.Port = 25;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Send(message);
            reader.Dispose();
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

    }
}