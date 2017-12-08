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
            }
            if (!IsPostBack)
            {
                if (Session["Merchantid"] != null)
                {
                    Response.Redirect("MerchantLogin.aspx", false);
                }
                else
                {
                    FilldrpMerchantlevel();
                    FilldrpCountry();
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

        private void FilldrpMerchantlevel()
        {
            BAMerchantLevel _bamlvl = new BALayer.BAMerchantLevel();
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bamlvl.GetMerchantLevelList("GETALL");
            drpMerchantLevel.DataTextField = "MerchantLevel";
            drpMerchantLevel.DataValueField = "MerchantLevelId";
            drpMerchantLevel.DataSource = _datatable2;
            drpMerchantLevel.DataBind();
            ViewState["leveltable"] = _datatable2;
            txtAnnualFee.Text = FilltxtAnnualFee(drpMerchantLevel.SelectedValue, _datatable2).ToString();
        }

        private double FilltxtAnnualFee(string levelid, DataTable _dtabel)
        {
            double amount = 0;
            DataRow[] result = _dtabel.Select("MerchantLevelId ='" + levelid + "'");
            foreach (DataRow row in result)
            {
                amount = Convert.ToDouble(row["AnnualFee"]);
            }
            return amount;
        }

        private void FilldrpCountry()
        {
            BAMasterCountry _bamstcountry = new BAMasterCountry();
            DataTable _datatable3 = new DataTable();
            _datatable3 = _bamstcountry.GetCountryList("GETALL");
            drpCountry.DataTextField = "Country";
            drpCountry.DataValueField = "CountryId";
            drpCountry.DataSource = _datatable3;
            drpCountry.DataBind();
            FilldrpState(drpCountry.SelectedValue);
        }

        private void FilldrpState(string countryid)
        {
            BAMasterState _bamststate = new BAMasterState();
            DataTable _datatable4 = new DataTable();
            _datatable4 = _bamststate.GetStateList("GETStateWithCouid", countryid);
            drpState.DataTextField = "State";
            drpState.DataValueField = "StateId";
            drpState.DataSource = _datatable4;
            drpState.DataBind();
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateForm())
                {
                    _bomermng.MerchantName = txtMerchantName.Text;
                    _bomermng.UserName = txtUserName.Text;
                    _bomermng.Password = Encryptdata(txtPassword.Text);
                    _bomermng.StateId = Convert.ToInt32(drpState.SelectedItem.Value);
                    _bomermng.EmailId = txtEmailId.Text;
                    _bomermng.Telephone = txtTelephone.Text;
                    _bomermng.MerchantLevelId = Convert.ToInt32(drpMerchantLevel.SelectedItem.Value);
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
                        case -2:
                            lblerror.InnerText = "Sorry, your username is already in use.";
                            lblerror.Attributes.Add("Style", "display: block;color: Red;");
                            break;
                        default:
                            Session["registationid"] = returnvalue;
                            SendHTMLMail(txtMerchantName.Text, txtEmailId.Text, txtUserName.Text, txtTelephone.Text, drpMerchantLevel.SelectedItem.Text, txtPassword.Text, Convert.ToString(FilltxtAnnualFee(drpMerchantLevel.SelectedValue, ViewState["leveltable"] as DataTable)));
                            if (FilltxtAnnualFee(drpMerchantLevel.SelectedValue, ViewState["leveltable"] as DataTable) > 0)
                            {
                                Checkout();
                            }
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
            if (string.IsNullOrEmpty(txtMerchantName.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter merchant name";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter username";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtEmailId.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter email id";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
            }
            else
            {
                lblerror.InnerText = "";
            }
            //if (string.IsNullOrEmpty(txtTelephone.Text))
            //{
            //    ret = false;
            //    lblerror.InnerText = "Enter telephone number";
            //    lblerror.Attributes.Add("Style", "display: block;color: Red;");
            //}
            //else
            //{
            //    lblerror.InnerText = "";
            //}
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter password";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
            }
            else
            {
                lblerror.InnerText = "";
            }
            return ret;
        }

        private void Checkout()
        {
            Response.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("<div id=\"loading\" style=\" text-align:center; top:100px;\"><p> Please wait ... Do not refresh or back this page!</p><br/><img src=\"../images/processing.gif\" \"width:400px\"></div>");
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://sandbox.2checkout.com/checkout/purchase");
            sb.AppendFormat("<input type='hidden' name='sid' value='{0}'>", "901350981");
            sb.AppendFormat("<input type='hidden' name='mode' value='{0}'>", "2CO");
            sb.AppendFormat("<input type='hidden' name='li_0_type' value='{0}'>", "Membership");
            sb.AppendFormat("<input type='hidden' name='li_0_name' value='{0}'>", drpMerchantLevel.SelectedItem.Text);
            sb.AppendFormat("<input type='hidden' name='li_0_price' value='{0}'>", FilltxtAnnualFee(drpMerchantLevel.SelectedValue, ViewState["leveltable"] as DataTable));
            sb.AppendFormat("<input type='hidden' name='card_holder_name' value='{0}'>", txtMerchantName.Text);
            sb.AppendFormat("<input type='hidden' name='street_address' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='street_address2' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='city' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='state' value='{0}'>", drpState.SelectedItem.Text);
            sb.AppendFormat("<input type='hidden' name='zip' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='country' value='{0}'>", drpCountry.SelectedItem.Text);
            sb.AppendFormat("<input type='hidden' name='email' value='{0}'>", txtEmailId.Text);
            sb.AppendFormat("<input type='hidden' name='phone' value='{0}'>", txtTelephone.Text);
            sb.AppendFormat("<input type='hidden' name='merchant_order_id' value='{0}'>", DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"));
            sb.AppendFormat("<input type='hidden' name='x_receipt_link_url' value='{0}'>", "http://quizmerchant.mobi96.org/MerchantRegistration.aspx");
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(sb.ToString());
            // HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            //Response.Write(sb.ToString());

            //Response.End();
        }

        public void SendHTMLMail(string merchantname, string email, string UserName, string Telephone, string Plan, string Password, string amount)
        {
            StreamReader reader = new StreamReader(Server.MapPath("~/MerchantRegsitrationEmail.html"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            myString = readFile;
            myString = myString.Replace("$$MerchantName$$", merchantname);
            myString = myString.Replace("$$UserName$$", UserName);
            myString = myString.Replace("$$Telephone$$", Telephone);
            myString = myString.Replace("$$Password$$", Password);
            myString = myString.Replace("$$Plan$$", Plan);
            myString = myString.Replace("$$Amount$$", amount);

            SmtpClient smtpClient = new SmtpClient("relay-hosting.secureserver.net");
            MailMessage message = new MailMessage();

            MailAddress fromAddress = new MailAddress("info@mobi96.org", "info@mobi96.org");
            MailAddress toAddress = new MailAddress(HttpUtility.HtmlEncode(email));

            message.From = fromAddress;
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

        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FilldrpState(drpCountry.SelectedValue);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
            }
        }

        protected void drpMerchantLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnnualFee.Text = Convert.ToString(FilltxtAnnualFee(drpMerchantLevel.SelectedValue, ViewState["leveltable"] as DataTable));
        }

    }
}