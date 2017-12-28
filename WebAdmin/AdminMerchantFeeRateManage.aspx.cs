using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminMerchantFeeRateManage : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOMerchantFeeRate _bofrate = new BOMerchantFeeRate();
        private BAMerchantFeeRate _bafrate = new BAMerchantFeeRate();
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
                        FillgridViewMerchantFeeRate();
                        FillddlMerchantLevel();
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

        private void FillgridViewMerchantFeeRate()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bafrate.GetMerchantLevelList("GETALL");
            gvMerchantFeeRate.DataSource = _datatable1;
            gvMerchantFeeRate.DataBind();
        }

        private void FillddlMerchantLevel()
        {
            BAMerchantLevel _bamlvl = new BALayer.BAMerchantLevel();
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bamlvl.GetMerchantLevelList("GETALL");
            if (_datatable2.Rows.Count > 0)
            {
                ddlMerchantLevel.DataTextField = "MerchantLevel";
                ddlMerchantLevel.DataValueField = "MerchantLevelId";
                ddlMerchantLevel.DataSource = _datatable2;
                ddlMerchantLevel.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (!string.IsNullOrEmpty(txtMerchantFeeRate.Text) && ddlMerchantLevel.SelectedIndex != -1)
                    {
                        _bofrate.MerchantFeeRate = Convert.ToInt32(txtMerchantFeeRate.Text);
                        _bofrate.MerchantLevelId = Convert.ToInt32(ddlMerchantLevel.SelectedValue);
                        _bofrate.IsActive = true;
                        _bofrate.IsDelete = false;
                        _bofrate.CreatedBy = adminId;
                        _bofrate.CreatedDate = DateTime.UtcNow;
                        _bofrate.UpdatedBy = adminId;
                        _bofrate.UpdatedDate = DateTime.UtcNow;
                        if (ViewState["frateId"] != null)
                        {
                            _bofrate.MerchantFeeRateId = Convert.ToInt32(ViewState["frateId"]);
                            _bofrate.Event = "Update";
                            if (_bafrate.Update(_bofrate) == 2)
                            {
                                ShowMessage("Fee rate updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _bofrate.MerchantFeeRateId = 0;
                            _bofrate.Event = "Insert";
                            if (_bafrate.Insert(_bofrate) == 1)
                            {
                                ShowMessage("Fee rate added successfully", MessageType.Success);
                            }
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Please enter fee rate value";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
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

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int frateId = Convert.ToInt32(gvMerchantFeeRate.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable3 = new DataTable();
                _datatable3 = _bafrate.SelectFeeRateWithID("GetWithFeeRateId", frateId);
                if (_datatable3.Rows.Count > 0)
                {
                    ViewState["frateId"] = _datatable3.Rows[0][0].ToString();
                    txtMerchantFeeRate.Text = _datatable3.Rows[0][1].ToString();
                    ddlMerchantLevel.SelectedValue = _datatable3.Rows[0][2].ToString();
                    lnkbtnAdd.Text = "Update";
                    lnkbtnAdd.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int frateId = Convert.ToInt32(gvMerchantFeeRate.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bofrate.MerchantFeeRateId = frateId;
                    _bofrate.IsDelete = true;
                    _bofrate.CreatedBy = adminId;
                    _bofrate.CreatedDate = DateTime.UtcNow;
                    _bofrate.UpdatedBy = adminId;
                    _bofrate.UpdatedDate = DateTime.UtcNow;
                    _bofrate.Event = "Delete";
                    int rtnvalue = _bafrate.Delete(_bofrate);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Fee rate deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete fee rate because used in another entity", MessageType.Info);
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
            FillgridViewMerchantFeeRate();
            ViewState["frateId"] = "";
            ViewState["frateId"] = null;
            txtMerchantFeeRate.Text = "";
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            Common.ClearControl(Panel1);
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvMerchantFeeRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMerchantFeeRate.PageIndex = e.NewPageIndex;
            FillgridViewMerchantFeeRate();
        }
    }
}