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
    public partial class AdminAddThirdCategory : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOThirdCategory _bothirdcat = new BOThirdCategory();
        private BAThirdCategory _bathirdcat = new BAThirdCategory();
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
                        FillgridViewThirdCategory();
                        FillddlSecondCategory();
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

        private void FillgridViewThirdCategory()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bathirdcat.SelectThirdCatgorywithSearch("GETALL", txtSearch.Text);
            gvThirdCategory.DataSource = _datatable1;
            gvThirdCategory.DataBind();
        }

        private void FillddlSecondCategory()
        {
            BASecondCategory _bascat = new BALayer.BASecondCategory();
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bascat.SelectSecondCatgoryList("GETALL");
            if (_datatable2.Rows.Count > 0)
            {
                ddlSecondCategory.DataTextField = "SecondCategoryName";
                ddlSecondCategory.DataValueField = "SecondCategoryId";
                ddlSecondCategory.DataSource = _datatable2;
                ddlSecondCategory.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (validateForm())
                    {
                        _bothirdcat.ThirdCategoryName = txtThirdCategory.Text;
                        _bothirdcat.SecondCategoryId = Convert.ToInt32(ddlSecondCategory.SelectedValue);
                        _bothirdcat.IsActive = true;
                        _bothirdcat.IsDelete = false;
                        _bothirdcat.CreatedBy = adminId;
                        _bothirdcat.CreatedDate = DateTime.UtcNow;
                        _bothirdcat.UpdatedBy = adminId;
                        _bothirdcat.UpdatedDate = DateTime.UtcNow;
                        if (ViewState["ThirdcatId"] != null)
                        {
                            _bothirdcat.ThirdCategoryId = Convert.ToInt32(ViewState["ThirdcatId"]);
                            _bothirdcat.Event = "Update";
                            if (_bathirdcat.Update(_bothirdcat) == 2)
                            {
                                ShowMessage("Category updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _bothirdcat.ThirdCategoryId = 0;
                            _bothirdcat.Event = "Insert";
                            if (_bathirdcat.Insert(_bothirdcat) == 1)
                            {
                                ShowMessage("Category added successfully", MessageType.Success);
                            }
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

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int ThirdcatId = Convert.ToInt32(gvThirdCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable3 = new DataTable();
                _datatable3 = _bathirdcat.SelectThirdCategoryWithID("GetWithThirdCatId", ThirdcatId);
                if (_datatable3.Rows.Count > 0)
                {
                    ViewState["ThirdcatId"] = _datatable3.Rows[0][0].ToString();
                    txtThirdCategory.Text = _datatable3.Rows[0][1].ToString();
                    ddlSecondCategory.SelectedValue = _datatable3.Rows[0][2].ToString();
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
                    int thirdcatid = Convert.ToInt32(gvThirdCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bothirdcat.ThirdCategoryId = thirdcatid;
                    _bothirdcat.IsDelete = true;
                    _bothirdcat.CreatedBy = adminId;
                    _bothirdcat.CreatedDate = DateTime.UtcNow;
                    _bothirdcat.UpdatedBy = adminId;
                    _bothirdcat.UpdatedDate = DateTime.UtcNow;
                    _bothirdcat.Event = "Delete";
                    int rtnvalue = _bathirdcat.Delete(_bothirdcat);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Category deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete category because used in another entity", MessageType.Info);
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
            FillgridViewThirdCategory();
            ViewState["ThirdcatId"] = "";
            ViewState["ThirdcatId"] = null;
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            txtThirdCategory.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable _datatable4 = new DataTable();
            _datatable4 = _bathirdcat.SelectThirdCatgorywithSearch("GETALL", txtSearch.Text);
            gvThirdCategory.DataSource = _datatable4;
            gvThirdCategory.DataBind();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvThirdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvThirdCategory.PageIndex = e.NewPageIndex;
            FillgridViewThirdCategory();
        }

        private bool validateForm()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtThirdCategory.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter third category";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtThirdCategory.Focus();
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (ddlSecondCategory.Items.Count == 0)
            {
                ret = false;
                lblerror.InnerText = "Select second category";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                ddlSecondCategory.Focus();
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            return ret;
        }
    }
}