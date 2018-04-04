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
    public partial class MerchantLogin : System.Web.UI.Page
    {
        private DataTable _datatable;
        private BAMerchantManage _bamermng = new BAMerchantManage();
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private int merchantId = default(int);
        public enum MessageType { Success, Error, Info, Warning };
        bool exists;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["merchantDetail"] != null)
                {
                    BOMerchantManage _bomerchantDetail = (BOMerchantManage)Session["merchantDetail"];
                    merchantId = _bomerchantDetail.MerchantId;
                    if (!IsPostBack)
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        GetExtraPermission(_bomerchantDetail.MerchantLevelId);
                        FilldropDowntopCategory();
                        FilgirdViewMerchantDetail("GETWITHID", _bomerchantDetail.MerchantId);
                        FillgridViewExamDetail("GetExamWithMId", _bomerchantDetail.MerchantId);
                        if (_bomerchantDetail.MerchantLevel == "Free")
                        {
                            gvExamDetail.Columns[0].Visible = gvExamDetail.Columns[6].Visible = gvExamDetail.Columns[7].Visible = gvExamDetail.Columns[8].Visible = gvExamDetail.Columns[9].Visible = gvExamDetail.Columns[10].Visible = gvExamDetail.Columns[11].Visible = false;
                        }
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

        private void GetExtraPermission(int levelid)
        {
            DataTable _datatable = new DataTable();
            BAQuestionType _baqtype = new BALayer.BAQuestionType();
            System.Data.DataSet _dataset = new System.Data.DataSet();
            _dataset = _baqtype.SelectQuestionTypeList("GetQTypeWithMLevel", levelid);
            _datatable = _dataset.Tables[1];
            exists = _datatable.Select().ToList().Exists(row => row["ExtraPermissionOptId"].ToString() == "4");
        }

        private void FilgirdViewMerchantDetail(string eventtxt, int merchantid)
        {
            _datatable = new DataTable();
            _datatable = _bamermng.SelectMerchantDetail(eventtxt, merchantid);
            gvMerchantDetail.DataSource = _datatable;
            gvMerchantDetail.DataBind();
        }

        private void FilldropDowntopCategory()
        {
            BATopCategory _batopcat = new BATopCategory();
            _datatable = new DataTable();
            _datatable = _batopcat.SelectTopCategoryList("GETALL");
            if (_datatable.Rows.Count > 0)
            {
                drpTopcategory.DataTextField = "TopCategoryName";
                drpTopcategory.DataValueField = "TopCategoryID";
                drpTopcategory.DataSource = _datatable;
                drpTopcategory.DataBind();
            }
        }

        private void FillgridViewExamDetail(string eventtext, int Merchantid)
        {
            _datatable = new DataTable();
            _datatable = _baexmmng.SelectExamDetail(eventtext, Merchantid, "");
            gvExamDetail.DataSource = _datatable;
            gvExamDetail.DataBind();
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    BOSecondCategory _boscat = new BOSecondCategory();
                    BASecondCategory _bascat = new BASecondCategory();
                    _boscat.SecondCategoryName = txtcategory.Text;
                    _boscat.TopCategoryId = Convert.ToInt32(drpTopcategory.SelectedValue);
                    _boscat.IsActive = false;
                    _boscat.IsDelete = false;
                    _boscat.CreatedBy = merchantId;
                    _boscat.CreatedDate = DateTime.UtcNow;
                    _boscat.UpdatedBy = merchantId;
                    _boscat.UpdatedDate = DateTime.UtcNow;
                    _boscat.Event = "Insert";
                    int result = _bascat.Insert(_boscat);
                    if (result == 1)
                    {
                        ShowMessage("Category added successfully", MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            txtcategory.Text = "";
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvMerchantDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMerchantDetail.PageIndex = e.NewPageIndex;
            FilgirdViewMerchantDetail("GETWITHID", merchantId);
        }

        protected void gvExamDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExamDetail.PageIndex = e.NewPageIndex;
            FillgridViewExamDetail("GetExamWithMId", merchantId);
        }

        protected void lnkbtnOnlytestOnce_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int examcodeid = Convert.ToInt32(gvExamDetail.DataKeys[gvrow.RowIndex].Value.ToString());
                LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnOnlytestOnce");
                bool onlytestonce = Convert.ToBoolean(ID.CommandArgument);
                if (onlytestonce == true)
                {
                    _boexmmng.OnlyTestOnce = false;
                }
                else
                {
                    _boexmmng.OnlyTestOnce = true;
                }
                _boexmmng.ExamCodeId = examcodeid;
                _boexmmng.ValidDate = DateTime.UtcNow;
                _boexmmng.CreatedDate = DateTime.UtcNow;
                _boexmmng.UpdatedBy = merchantId;
                _boexmmng.UpdatedDate = DateTime.UtcNow;
                _boexmmng.Event = "UpdateOnlyTestOnce";
                _baexmmng.Update(_boexmmng);
                FillgridViewExamDetail("GetExamWithMId", merchantId);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lnkbtnallowprint_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int examcodeid = Convert.ToInt32(gvExamDetail.DataKeys[gvrow.RowIndex].Value.ToString());
                LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnallowprint");
                bool allowprint = Convert.ToBoolean(ID.CommandArgument);
                if (allowprint == true)
                {
                    _boexmmng.AllowPrint = false;
                }
                else
                {
                    _boexmmng.AllowPrint = true;
                }
                _boexmmng.ExamCodeId = examcodeid;
                _boexmmng.ValidDate = DateTime.UtcNow;
                _boexmmng.CreatedDate = DateTime.UtcNow;
                _boexmmng.UpdatedBy = merchantId;
                _boexmmng.UpdatedDate = DateTime.UtcNow;
                _boexmmng.Event = "UpdateAllowPrint";
                _baexmmng.Update(_boexmmng);
                FillgridViewExamDetail("GetExamWithMId", merchantId);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lnkbtnallowsales_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int examcodeid = Convert.ToInt32(gvExamDetail.DataKeys[gvrow.RowIndex].Value.ToString());
                LinkButton ID = (LinkButton)gvrow.FindControl("lnkbtnallowsales");
                bool allowsales = Convert.ToBoolean(ID.CommandArgument);
                if (allowsales == true)
                {
                    _boexmmng.AllowSales = false;
                }
                else
                {
                    _boexmmng.AllowSales = true;
                }
                _boexmmng.ExamCodeId = examcodeid;
                _boexmmng.ValidDate = DateTime.UtcNow;
                _boexmmng.CreatedDate = DateTime.UtcNow;
                _boexmmng.UpdatedBy = merchantId;
                _boexmmng.UpdatedDate = DateTime.UtcNow;
                _boexmmng.Event = "UpdateAllowSales";
                _baexmmng.Update(_boexmmng);
                FillgridViewExamDetail("GetExamWithMId", merchantId);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void gvExamDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!exists)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    gvExamDetail.Columns[8].Visible = false;
                }
            }
        }
    }
}