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
    public partial class MerchantWithDraw : System.Web.UI.Page
    {
        private BOMerchantWithDraw _bomerwidrw = new BOMerchantWithDraw();
        private BAMerchantWithDraw _bamerwidrw = new BAMerchantWithDraw();
        private int MerchantId = default(int);
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    MerchantId = _bomerchantDetail.MerchantId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillgridViewWithDraw(MerchantId);
                        lblcurrbal.Text = Convert.ToString(SelectbalanceAmount(MerchantId));
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
            //FillgridViewWithDraw(MerchantId);
            lblcurrbal.Text = Convert.ToString(SelectbalanceAmount(MerchantId));
        }

        private decimal SelectbalanceAmount(int mid)
        {
            decimal blnc = default(decimal);
            BAMerchantBalance _bamrblnc = new BALayer.BAMerchantBalance();
            blnc = _bamrblnc.SelectMerbalance("GetBalanceWithMId", mid);
            return blnc;
        }

        private void FillgridViewWithDraw(int mid)
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bamerwidrw.SelectWithDrawDetail("GetWithDrawRecordWithMId", mid);
            gvWithDraw.DataSource = _datatable1;
            gvWithDraw.DataBind();
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (Convert.ToDecimal(lblcurrbal.Text) > Convert.ToDecimal(txtWithDraw.Text))
                    {
                        _bomerwidrw.WithDrawOrderNo = GetOrderNo();
                        _bomerwidrw.Amount = Convert.ToDecimal(txtWithDraw.Text);
                        _bomerwidrw.MerchantId = MerchantId;
                        _bomerwidrw.OrderStatus = false;
                        _bomerwidrw.OrderDate = DateTime.UtcNow;
                        _bomerwidrw.IsActive = true;
                        _bomerwidrw.IsDelete = false;
                        _bomerwidrw.CreatedBy = MerchantId;
                        _bomerwidrw.CreatedDate = DateTime.UtcNow;
                        _bomerwidrw.UpdatedBy = MerchantId;
                        _bomerwidrw.UpdatedDate = DateTime.UtcNow;
                        _bomerwidrw.Event = "Insert";
                        if (_bamerwidrw.Insert(_bomerwidrw) == 1)
                        {
                            ShowMessage("Request send successfully", MessageType.Success);
                        }
                        ClearControl();
                    }
                    else
                    {
                        ShowMessage("Your Balance is low", MessageType.Success);
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

        private string GetOrderNo()
        {
            int ordno = default(int);
            ordno = _bamerwidrw.Getordrno("Getorderno");
            return Convert.ToString("ORD" + (ordno + 1));
        }

        private void ClearControl()
        {
            txtWithDraw.Text = "";
            FillgridViewWithDraw(MerchantId);
            lblcurrbal.Text = Convert.ToString(SelectbalanceAmount(MerchantId));
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

        protected void gvWithDraw_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvWithDraw.PageIndex = e.NewPageIndex;
            FillgridViewWithDraw(MerchantId);
        }
    }
}