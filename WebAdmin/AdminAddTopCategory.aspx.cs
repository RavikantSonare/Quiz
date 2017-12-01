using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminAddTopCategory : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOTopCategory _botcat = new BOTopCategory();
        private BATopCategory _batcat = new BATopCategory();
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
                        FillgridViewTopCategory();
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

        private void FillgridViewTopCategory()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _batcat.SelectTopCategorywithSearch("GETALL", txtSearch.Text);
            gvTopCategory.DataSource = _datatable1;
            gvTopCategory.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (!string.IsNullOrEmpty(txtCategoryName.Text))
                    {
                        _botcat.TopCategoryName = txtCategoryName.Text;
                        _botcat.IsActive = true;
                        _botcat.IsDelete = false;
                        _botcat.CreatedBy = adminId;
                        _botcat.CreatedDate = DateTime.UtcNow;
                        _botcat.UpdatedBy = adminId;
                        _botcat.UpdatedDate = DateTime.UtcNow;
                        if (ViewState["tcatId"] != null)
                        {
                            _botcat.TopCategoryId = Convert.ToInt32(ViewState["tcatId"]);
                            _botcat.Event = "Update";
                            if (_batcat.Update(_botcat) == 2)
                            {
                                ShowMessage("Category updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _botcat.TopCategoryId = 0;
                            _botcat.Event = "Insert";
                            if (_batcat.Insert(_botcat) == 1)
                            {
                                ShowMessage("Category added successfully", MessageType.Success);
                            }
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Please enter Top category";
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
                int tidId = Convert.ToInt32(gvTopCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable2 = new DataTable();
                _datatable2 = _batcat.SelectTopCategoryWithID("GetCatwithId", tidId);
                if (_datatable2.Rows.Count > 0)
                {
                    ViewState["tcatId"] = _datatable2.Rows[0][0].ToString();
                    txtCategoryName.Text = _datatable2.Rows[0][1].ToString();
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
                    int topid = Convert.ToInt32(gvTopCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                    _botcat.TopCategoryId = topid;
                    _botcat.IsDelete = true;
                    _botcat.CreatedBy = adminId;
                    _botcat.CreatedDate = DateTime.UtcNow;
                    _botcat.UpdatedBy = adminId;
                    _botcat.UpdatedDate = DateTime.UtcNow;
                    _botcat.Event = "Delete";
                    int rtnvalue = _batcat.Delete(_botcat);
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
            btnAdd.Text = "Add";
            ViewState["tcatId"] = "";
            ViewState["tcatId"] = null;
            FillgridViewTopCategory();
            Common.ClearControl(Panel1);
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            DataTable _datatable3 = new DataTable();
            _datatable3 = _batcat.SelectTopCategorywithSearch("GETALL", txtSearch.Text);
            gvTopCategory.DataSource = _datatable3;
            gvTopCategory.DataBind();

        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvTopCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTopCategory.PageIndex = e.NewPageIndex;
            FillgridViewTopCategory();
        }
    }
}