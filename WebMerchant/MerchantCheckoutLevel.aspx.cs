﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WebMerchant
{
    public partial class MerchantCheckoutLevel : System.Web.UI.Page
    {
        private BOMerchantLevel _bomlvl = new BOMerchantLevel();
        private BAMerchantLevel _bamlvl = new BAMerchantLevel();
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                if (Request.QueryString["emid"] != null)
                {
                    ViewState["emid"] = Request.QueryString["emid"];
                    FillgridViewMerchantLevel();
                }
                else
                {
                    ShowMessage("technical error", MessageType.Error);
                }
            }
        }

        private void FillgridViewMerchantLevel()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bamlvl.GetMerchantLevelList("GETALL");
            dlpricetable.DataSource = _datatable1;
            dlpricetable.DataBind();
        }

        private void Checkout(string amount, string levle, JObject obj)
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
            sb.AppendFormat("<input type='hidden' name='li_0_name' value='{0}'>", levle);
            sb.AppendFormat("<input type='hidden' name='li_0_price' value='{0}'>", amount);
            sb.AppendFormat("<input type='hidden' name='card_holder_name' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='street_address' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='street_address2' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='city' value='{0}'>", (string)obj["city"]);
            sb.AppendFormat("<input type='hidden' name='state' value='{0}'>", (string)obj["region_name"]);
            sb.AppendFormat("<input type='hidden' name='zip' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='country' value='{0}'>", (string)obj["country_name"]);
            sb.AppendFormat("<input type='hidden' name='email' value='{0}'>", Common.Decryptdata(ViewState["emid"].ToString()));
            sb.AppendFormat("<input type='hidden' name='phone' value='{0}'>", "");
            sb.AppendFormat("<input type='hidden' name='merchant_order_id' value='{0}'>", DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"));
            sb.AppendFormat("<input type='hidden' name='x_receipt_link_url' value='{0}'>", "http://quizmerchant.mobi96.org/MerchantRegistration.aspx");
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            Response.Write(sb.ToString());

            Response.End();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btncheckout_Click(object sender, EventArgs e)
        {
            Button btncheck = sender as Button;
            Checkout(btncheck.CommandArgument, btncheck.ToolTip, GetCountryName());
        }

        protected static JObject GetCountryName()
        {
            var url = "http://freegeoip.net/json/";
            var request = System.Net.WebRequest.Create(url);

            using (WebResponse wrs = request.GetResponse())
            using (Stream stream = wrs.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                return JObject.Parse(json);
                // var City = (string)obj["city"];
                // return (string)obj["country_name"];
            }
        }
    }
}