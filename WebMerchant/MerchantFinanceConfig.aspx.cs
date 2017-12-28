using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantFinanceConfig : System.Web.UI.Page
    {
        private BOFinanceConfig _bofncfg = new BOFinanceConfig();
        private BAFinanceConfig _bafncfg = new BAFinanceConfig();
        private int MerchantID = default(int);
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    MerchantID = +_bomerchantDetail.MerchantId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgridViewShowFinancConfigDetail(MerchantID);
                        FilldropDownPaymentOption();
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
        }

        private void FillgridViewShowFinancConfigDetail(int mId)
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bafncfg.SelectFinanceConfigDetail("GetAllWithMId", mId);
            gvPaymentDetail.DataSource = _datatable2;
            gvPaymentDetail.DataBind();
        }

        private void FilldropDownPaymentOption()
        {
            BAPaymentOption _bapmntopt = new BALayer.BAPaymentOption();
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bapmntopt.SelectPaymentOptionList("GETMerchantOption");
            if (_datatable1.Rows.Count > 0)
            {
                drpPaymentOption.DataTextField = "PaymentOption";
                drpPaymentOption.DataValueField = "PaymentOptionId";
                drpPaymentOption.DataSource = _datatable1;
                drpPaymentOption.DataBind();
                if (drpPaymentOption.SelectedItem.Text.Equals("Paypal"))
                {
                    pnlPaypal.Visible = true;
                    pnlWireTransfer.Visible = false;
                }
                else if (drpPaymentOption.SelectedItem.Text.Equals("Wire Transfer"))
                {
                    pnlWireTransfer.Visible = true;
                    pnlPaypal.Visible = false;
                }
            }
        }

        protected void drpPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpPaymentOption.SelectedItem.Text.Equals("Paypal"))
                {
                    pnlPaypal.Visible = true;
                    pnlWireTransfer.Visible = false;
                    Common.ClearControl(pnlWireTransfer);
                }
                else if (drpPaymentOption.SelectedItem.Text.Equals("Wire Transfer"))
                {
                    pnlWireTransfer.Visible = true;
                    pnlPaypal.Visible = false;
                    Common.ClearControl(pnlPaypal);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _bofncfg.PaymentOptionId = Convert.ToInt32(drpPaymentOption.SelectedItem.Value);
                    _bofncfg.MerchantId = MerchantID;
                    _bofncfg.AccountEmail = txtAccountEmail.Text;
                    _bofncfg.FirstName = txtFirstName.Text;
                    _bofncfg.LastName = txtLastName.Text;
                    _bofncfg.Country = txtCountry.Text;
                    _bofncfg.City = txtCity.Text;
                    _bofncfg.BankOfName = txtBankName.Text;
                    _bofncfg.SwiftCode = txtSwiftCode.Text;
                    _bofncfg.IsActive = true;
                    _bofncfg.IsDelete = false;
                    _bofncfg.CreatedBy = MerchantID;
                    _bofncfg.CreatedDate = DateTime.UtcNow;
                    _bofncfg.UpdatedBy = MerchantID;
                    _bofncfg.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["fcId"] != null)
                    {
                        _bofncfg.FinanceConfigId = Convert.ToInt32(ViewState["fcId"]);
                        _bofncfg.Event = "Update";
                        if (_bafncfg.Update(_bofncfg) == 2)
                        {
                            ShowMessage("Account detail updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _bofncfg.FinanceConfigId = 0;
                        _bofncfg.Event = "Insert";
                        if (_bafncfg.Insert(_bofncfg) == 1)
                        {
                            ShowMessage("Account detail added successfully", MessageType.Success);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            ClearControl();
        }
        private void ClearControl()
        {
            Common.ClearControl(pnlWireTransfer);
            Common.ClearControl(pnlPaypal);
            FillgridViewShowFinancConfigDetail(MerchantID);
            ViewState["fcId"] = null;
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                int fcid = Convert.ToInt32(btn.CommandArgument);
                if (fcid > 0)
                {
                    DataTable _datatable3 = new DataTable();
                    _datatable3 = _bafncfg.SelectFCDetailFID("GetAllWithFCId", fcid);
                    if (_datatable3.Rows.Count > 0)
                    {
                        ViewState["fcId"] = _datatable3.Rows[0]["FinanceConfigId"].ToString();
                        drpPaymentOption.SelectedValue = _datatable3.Rows[0]["PaymentOptionId"].ToString();
                        if (drpPaymentOption.SelectedItem.Text.Equals("Paypal"))
                        {
                            pnlPaypal.Visible = true;
                            pnlWireTransfer.Visible = false;
                        }
                        else if (drpPaymentOption.SelectedItem.Text.Equals("Wire Transfer"))
                        {
                            pnlWireTransfer.Visible = true;
                            pnlPaypal.Visible = false;
                        }
                        txtAccountEmail.Text = _datatable3.Rows[0]["AccountEmail"].ToString();
                        txtFirstName.Text = _datatable3.Rows[0]["FirstName"].ToString();
                        txtLastName.Text = _datatable3.Rows[0]["LastName"].ToString();
                        txtCountry.Text = _datatable3.Rows[0]["Country"].ToString();
                        txtCity.Text = _datatable3.Rows[0]["City"].ToString();
                        txtBankName.Text = _datatable3.Rows[0]["BankOfName"].ToString();
                        txtSwiftCode.Text = _datatable3.Rows[0]["SwiftCode"].ToString();
                        lnkbtnAdd.Text = "Update";
                        lnkbtnAdd.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
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

        protected void gvPaymentDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentDetail.PageIndex = e.NewPageIndex;
            FillgridViewShowFinancConfigDetail(MerchantID);
        }
    }
}