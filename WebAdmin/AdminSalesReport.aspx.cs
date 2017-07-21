using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Net;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminSalesReport : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOSalesReport _boslsrpt = new BOSalesReport();
        private BASalesReport _baslsrpt = new BASalesReport();
        public enum MessageType { Success, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminDetail"] != null)
                {
                    BOAdminLogin _boadmin = (BOAdminLogin)Session["AdminDetail"];
                    adminId = _boadmin.AdminId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgirdViewSalesReport();
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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
            FillgirdViewSalesReport();
        }

        private void FillgirdViewSalesReport()
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _baslsrpt.SelectSalesReportsList("GETALL");
            List<BOSalesReport> _bosalestreport = (from li in _datatable2.AsEnumerable()
                                                   select new BOSalesReport
                                                   {
                                                       OrderId = li.Field<int>("OrderId"),
                                                       OrderNo = li.Field<string>("OrderNo"),
                                                       ExamCode = li.Field<string>("ExamCode"),
                                                       SecondCategoryName = li.Field<string>("SecondCategoryName"),
                                                       MerchantName = li.Field<string>("MerchantName"),
                                                       Price = li.Field<decimal>("Price"),
                                                       MerchantFeeRate = li.Field<int>("MerchantFeeRate"),
                                                       NetAmount = li.Field<decimal>("NetAmount"),
                                                       OrderStatus = li.Field<bool>("OrderStatus"),
                                                       Emailid = li.Field<string>("EmailId")
                                                   }).ToList();
            if (!string.IsNullOrEmpty(txtmerchantName.Text))
            {
                _bosalestreport = _bosalestreport.Where(mername => mername.MerchantName.ToUpper().Contains(txtmerchantName.Text.ToUpper())).ToList();
            }
            decimal sum = _bosalestreport.AsEnumerable().Where(row => row.OrderStatus == true).Sum(row => row.NetAmount);
            lblconfirmedamount.Text = Convert.ToString(sum);
            gvSalesReport.DataSource = _bosalestreport;
            gvSalesReport.DataBind();

            //DataTable _datatable1 = new DataTable();
            //_datatable1 = _baslsrpt.SelectSalesReportsList("GETALL");
            //if (_datatable1.Rows.Count > 0)
            //{
            //    decimal sum = _datatable1.AsEnumerable().Where(row => row.Field<bool>("OrderStatus") == true).Sum(row => row.Field<decimal>("NetAmount"));
            //    lblconfirmedamount.Text = Convert.ToString(sum);
            //}
            //gvSalesReport.DataSource = _datatable1;
            //gvSalesReport.DataBind();
        }

        protected void lnkbtnOrderconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int slsrptid = Convert.ToInt32(gvSalesReport.DataKeys[gvrow.RowIndex].Value.ToString());
                    LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnOrderconfirm");
                    bool isactive = Convert.ToBoolean(ID.CommandArgument);
                    if (isactive == true)
                    {
                        ShowMessage("Order already confirmed", MessageType.Info);
                    }
                    else
                    {
                        _boslsrpt.OrderStatus = true;
                        _boslsrpt.OrderId = slsrptid;
                        _boslsrpt.UpdatedBy = adminId;
                        _boslsrpt.UpdatedDate = DateTime.UtcNow;
                        _boslsrpt.Event = "UpdateStatus";
                        _baslsrpt.Update(_boslsrpt);
                        ShowMessage("Order confirmed", MessageType.Success);
                        FillgirdViewSalesReport();
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    Button btn = (Button)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    string status;
                    if (Convert.ToBoolean(row.Cells[7].Text))
                    {
                        status = "Confirmed";
                    }
                    else
                    { status = "Processing"; }
                    SendHTMLMail(row.Cells[3].Text, row.Cells[0].Text, row.Cells[6].Text, status, row.Cells[8].Text);
                    ShowMessage("Mail send successfully", MessageType.Success);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable _datatable2 = new DataTable();
                _datatable2 = _baslsrpt.SelectSalesReportsList("GETALL");
                List<BOSalesReport> _bosalestreport = (from li in _datatable2.AsEnumerable()
                                                       select new BOSalesReport
                                                       {
                                                           OrderId = li.Field<int>("OrderId"),
                                                           OrderNo = li.Field<string>("OrderNo"),
                                                           ExamCode = li.Field<string>("ExamCode"),
                                                           SecondCategoryName = li.Field<string>("SecondCategoryName"),
                                                           MerchantName = li.Field<string>("MerchantName"),
                                                           Price = li.Field<decimal>("Price"),
                                                           MerchantFeeRate = li.Field<int>("MerchantFeeRate"),
                                                           NetAmount = li.Field<decimal>("NetAmount"),
                                                           OrderStatus = li.Field<bool>("OrderStatus"),
                                                           Emailid = li.Field<string>("EmailId")
                                                       }).ToList();
                if (!string.IsNullOrEmpty(txtmerchantName.Text))
                {
                    _bosalestreport = _bosalestreport.Where(mername => mername.MerchantName.ToUpper().Contains(txtmerchantName.Text.ToUpper())).ToList();
                }
                decimal sum = _bosalestreport.AsEnumerable().Where(row => row.OrderStatus == true).Sum(row => row.NetAmount);
                lblconfirmedamount.Text = Convert.ToString(sum);
                gvSalesReport.DataSource = _bosalestreport;
                gvSalesReport.DataBind();
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

        public void SendHTMLMail(string merchantname, string orderno, string amount, string status, string Emailid)
        {
            StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.html"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            myString = readFile;
            myString = myString.Replace("$$MerchantName$$", merchantname);
            myString = myString.Replace("$$WithDrawOrderNo$$", orderno);
            myString = myString.Replace("$$Amount$$", amount);
            myString = myString.Replace("$$OrderStatus$$", status);

            SmtpClient smtpClient = new SmtpClient("relay-hosting.secureserver.net");
            MailMessage message = new MailMessage();

            MailAddress fromAddress = new MailAddress("info@mobi96.org", "info@mobi96.org");
            MailAddress toAddress = new MailAddress(HttpUtility.HtmlEncode(Emailid));

            message.From = fromAddress;
            message.To.Add(toAddress);

            message.Subject = "Quiz sales reports";
            message.IsBodyHtml = true;
            message.Body = myString.ToString();
            smtpClient.Port = 25;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Send(message);
            reader.Dispose();
        }

        protected void gvSalesReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesReport.PageIndex = e.NewPageIndex;
            FillgirdViewSalesReport();
        }
    }
}