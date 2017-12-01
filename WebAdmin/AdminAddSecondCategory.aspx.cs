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
    public partial class AdminAddSecondCategory : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOSecondCategory _boscat = new BOSecondCategory();
        private BASecondCategory _bascat = new BASecondCategory();
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
                        FillgridViewSecondCategory();
                        FillddlTopCategory();
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

        private void FillgridViewSecondCategory()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bascat.SelectSecondCatgorywithSearch("GETALL", txtSearch.Text);
            gvSecondCategory.DataSource = _datatable1;
            gvSecondCategory.DataBind();
        }

        private void FillddlTopCategory()
        {
            BATopCategory _batcat = new BALayer.BATopCategory();
            DataTable _datatable2 = new DataTable();
            _datatable2 = _batcat.SelectTopCategoryList("GETALL");
            if (_datatable2.Rows.Count > 0)
            {
                ddlTopCategory.DataTextField = "TopCategoryName";
                ddlTopCategory.DataValueField = "TopCategoryId";
                ddlTopCategory.DataSource = _datatable2;
                ddlTopCategory.DataBind();
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
                        _boscat.SecondCategoryName = txtSecondCategory.Text;
                        _boscat.TopCategoryId = Convert.ToInt32(ddlTopCategory.SelectedValue);
                        _boscat.IsActive = true;
                        _boscat.IsDelete = false;
                        _boscat.CreatedBy = adminId;
                        _boscat.CreatedDate = DateTime.UtcNow;
                        _boscat.UpdatedBy = adminId;
                        _boscat.UpdatedDate = DateTime.UtcNow;
                        if (ViewState["scatId"] != null)
                        {
                            _boscat.SecondCategoryId = Convert.ToInt32(ViewState["scatId"]);
                            _boscat.Event = "Update";
                            if (_bascat.Update(_boscat) == 2)
                            {
                                ShowMessage("Category updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _boscat.SecondCategoryId = 0;
                            _boscat.Event = "Insert";
                            if (_bascat.Insert(_boscat) == 1)
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
                int scatId = Convert.ToInt32(gvSecondCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable3 = new DataTable();
                _datatable3 = _bascat.SelectSecodCategoryWithID("GetWithSecCatId", scatId);
                if (_datatable3.Rows.Count > 0)
                {
                    ViewState["scatId"] = _datatable3.Rows[0][0].ToString();
                    txtSecondCategory.Text = _datatable3.Rows[0][1].ToString();
                    ddlTopCategory.SelectedValue = _datatable3.Rows[0][2].ToString();
                    btnAdd.Text = "Update";
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
                    int secid = Convert.ToInt32(gvSecondCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                    _boscat.SecondCategoryId = secid;
                    _boscat.IsDelete = true;
                    _boscat.CreatedBy = adminId;
                    _boscat.CreatedDate = DateTime.UtcNow;
                    _boscat.UpdatedBy = adminId;
                    _boscat.UpdatedDate = DateTime.UtcNow;
                    _boscat.Event = "Delete";
                    int rtnvalue = _bascat.Delete(_boscat);
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
            FillgridViewSecondCategory();
            ViewState["scatId"] = "";
            ViewState["scatId"] = null;
            btnAdd.Text = "Add";
            txtSecondCategory.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable _datatable4 = new DataTable();
            _datatable4 = _bascat.SelectSecondCatgorywithSearch("GETALL", txtSearch.Text);
            gvSecondCategory.DataSource = _datatable4;
            gvSecondCategory.DataBind();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvSecondCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSecondCategory.PageIndex = e.NewPageIndex;
            FillgridViewSecondCategory();
        }

        private bool validateForm()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtSecondCategory.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter second category";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                txtSecondCategory.Focus();
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (ddlTopCategory.Items.Count == 0)
            {
                ret = false;
                lblerror.InnerText = "Select top category";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                ddlTopCategory.Focus();
            }
            else
            {
                lblerror.InnerText = "";
            }
            return ret;
        }
    }
}