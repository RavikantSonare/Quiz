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
    public partial class AdminMerchantLevelManage : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOMerchantLevel _bomlvl = new BOMerchantLevel();
        private BAMerchantLevel _bamlvl = new BAMerchantLevel();
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
                        FillgridViewMerchantLevel();
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

        private void FillgridViewMerchantLevel()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bamlvl.GetMerchantLevelList("GETALL");
            gvMerchantLevel.DataSource = _datatable1;
            gvMerchantLevel.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (!string.IsNullOrEmpty(txtMerchantLevel.Text) && !string.IsNullOrEmpty(txtAnnualFee.Text))
                    {
                        _bomlvl.MerchantLevel = txtMerchantLevel.Text;
                        _bomlvl.AnnualFee = Convert.ToDecimal(txtAnnualFee.Text);
                        _bomlvl.IsActive = true;
                        _bomlvl.IsDelete = false;
                        _bomlvl.CreatedBy = adminId;
                        _bomlvl.CreatedDate = DateTime.UtcNow;
                        _bomlvl.UpdateBy = adminId;
                        _bomlvl.UpdateDate = DateTime.UtcNow;
                        if (ViewState["mlvlId"] != null)
                        {
                            _bomlvl.MerchantLevelId = Convert.ToInt32(ViewState["mlvlId"]);
                            _bomlvl.Event = "Update";
                            if (_bamlvl.Update(_bomlvl) == 2)
                            {
                                ShowMessage("Merchant level updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _bomlvl.MerchantLevelId = 0;
                            _bomlvl.Event = "Insert";
                            if (_bamlvl.Insert(_bomlvl) == 1)
                            {
                                ShowMessage("Merchant level added successfully", MessageType.Success);
                            }
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Please enter top Merchant level and annual fee";
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
                int mlvlId = Convert.ToInt32(gvMerchantLevel.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable2 = new DataTable();
                _datatable2 = _bamlvl.SelectMerchantLevelWithID("GetMLevelwithId", mlvlId);
                if (_datatable2.Rows.Count > 0)
                {
                    ViewState["mlvlId"] = _datatable2.Rows[0][0].ToString();
                    txtMerchantLevel.Text = _datatable2.Rows[0][1].ToString();
                    txtAnnualFee.Text = _datatable2.Rows[0][2].ToString();
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
                    int mlvlId = Convert.ToInt32(gvMerchantLevel.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bomlvl.MerchantLevelId = mlvlId;
                    _bomlvl.IsDelete = true;
                    _bomlvl.CreatedBy = adminId;
                    _bomlvl.CreatedDate = DateTime.UtcNow;
                    _bomlvl.UpdateBy = adminId;
                    _bomlvl.UpdateDate = DateTime.UtcNow;
                    _bomlvl.Event = "Delete";
                    int rtnvalue = _bamlvl.Delete(_bomlvl);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Merchant level deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete Merchant level because used in another entity", MessageType.Info);
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
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            ViewState["mlvlId"] = "";
            ViewState["mlvlId"] = null;
            FillgridViewMerchantLevel();
            Common.ClearControl(Panel1);
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvMerchantLevel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMerchantLevel.PageIndex = e.NewPageIndex;
            FillgridViewMerchantLevel();
        }
    }
}