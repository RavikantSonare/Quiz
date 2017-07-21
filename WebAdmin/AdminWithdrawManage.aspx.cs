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
    public partial class AdminWithdrawManage : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOWithDrawManage _bowdopt = new BOWithDrawManage();
        private BAWithDrawManage _bawdopt = new BAWithDrawManage();
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
                        FillgridViewWithDrawManage();
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
            FillgridViewWithDrawManage();
        }

        private void FillgridViewWithDrawManage()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bawdopt.SelectWithDrawManageList("GETALL");
            gvWithdrawManage.DataSource = _datatable1;
            gvWithdrawManage.DataBind();
        }

        protected void lnkbtnMerchantName_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                LinkButton mID = (LinkButton)gvrow.FindControl("lnkbtnMerchantName");
                if (mID.CommandArgument != "")
                {
                    string qid = HttpUtility.UrlEncode(Common.Encrypt(Convert.ToString(mID.CommandArgument)));
                    Response.Redirect("AdminWithdrawAccount.aspx?mID=" + qid, false);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
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
                    int wordid = Convert.ToInt32(gvWithdrawManage.DataKeys[gvrow.RowIndex].Value.ToString());
                    LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnOrderconfirm");
                    bool isactive = Convert.ToBoolean(ID.CommandArgument);
                    if (isactive == true)
                    {
                        ShowMessage("Order already confirmed", MessageType.Info);
                    }
                    else
                    {
                        _bowdopt.OrderStatus = true;
                        _bowdopt.WithDrawOrderId = wordid;
                        _bowdopt.UpdatedBy = adminId;
                        _bowdopt.UpdatedDate = DateTime.UtcNow;
                        _bowdopt.Event = "UpdateStatus";
                        _bawdopt.Update(_bowdopt);
                        ShowMessage("Order confirmed", MessageType.Success);
                        FillgridViewWithDrawManage();
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

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    Button btn = (Button)sender;
                    GridViewRow row = (GridViewRow)btn.NamingContainer;
                    string status;
                    if (Convert.ToBoolean(row.Cells[3].Text))
                    {
                        status = "Confirmed";
                    }
                    else
                    { status = "Pending"; }
                    SendHTMLMail(row.Cells[2].Text, row.Cells[0].Text, row.Cells[1].Text, status, row.Cells[4].Text);
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

            message.Subject = "Quiz Order Status";
            message.IsBodyHtml = true;
            message.Body = myString.ToString();
            smtpClient.Port = 25;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Send(message);
            reader.Dispose();
        }

        protected void gvWithdrawManage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvWithdrawManage.PageIndex = e.NewPageIndex;
            FillgridViewWithDrawManage();
        }
    }
}