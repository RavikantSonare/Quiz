using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantExamConfig : System.Web.UI.Page
    {
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
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
                        FilldropDowntopCategory();
                        txtdate.Text = SelectMerchantValidDate(MerchantId).ToString("yyyy-MM-dd");
                        FillgridViewExamDetail(MerchantId);
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

        private void FillgridViewExamDetail(int merid)
        {
            try
            {
                DataTable _datatable = new DataTable();
                _datatable = _baexmmng.SelectExamDetail("GetExamWithMId", merid);
                gvExamDetail.DataSource = _datatable;
                gvExamDetail.DataBind();
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        private DateTime SelectMerchantValidDate(int merchantId)
        {
            BAMerchantManage _bamermng = new BAMerchantManage();
            DateTime validdate = _bamermng.SelectValiddate("GetValidDate", merchantId);
            return validdate;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _boexmmng.ExamCode = txtExamCode.Text;
                    _boexmmng.ExamTitle = txtExamtitle.Text;
                    _boexmmng.TopCategoryId = Convert.ToInt32(drpTopCategory.SelectedItem.Value);
                    _boexmmng.SecondCategoryId = Convert.ToInt32(drpSecondCategory.SelectedItem.Value);
                    _boexmmng.PassingPercentage = Convert.ToDecimal(txtPassingPercentage.Text);
                    _boexmmng.TestTime = Convert.ToInt32(txtTestTime.Text);
                    _boexmmng.TestOption = txtTestOption.Text;
                    _boexmmng.ValidDate = Convert.ToDateTime(txtdate.Text);
                    _boexmmng.MerchantId = MerchantId;
                    _boexmmng.IsActive = true;
                    _boexmmng.IsDelete = false;
                    _boexmmng.CreatedBy = MerchantId;
                    _boexmmng.CreatedDate = DateTime.UtcNow;
                    _boexmmng.UpdatedBy = MerchantId;
                    _boexmmng.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["examId"] != null)
                    {
                        _boexmmng.ExamCodeId = Convert.ToInt32(ViewState["examId"]);
                        _boexmmng.Event = "Update";
                        if (_baexmmng.Update(_boexmmng) == 2)
                        {
                            ShowMessage("Exam updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _boexmmng.ExamCodeId = 0;
                        _boexmmng.Event = "Insert";
                        if (_baexmmng.Insert(_boexmmng) == 1)
                        {
                            ShowMessage("Exam added successfully", MessageType.Success);
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

        private void FilldropDowntopCategory()
        {
            BATopCategory _batopcat = new BATopCategory();
            DataTable _table = new DataTable();
            _table = _batopcat.SelectTopCategoryList("GETALL");
            drpTopCategory.DataTextField = "TopCategoryName";
            drpTopCategory.DataValueField = "TopCategoryID";
            drpTopCategory.DataSource = _table;
            drpTopCategory.DataBind();
            FilldropDownSecondCategory(drpTopCategory.SelectedItem.Value);
        }

        private void FilldropDownSecondCategory(string topcatid)
        {
            BASecondCategory _baseccat = new BASecondCategory();
            DataTable _dt = new DataTable();
            _dt = _baseccat.SelectSecondCategoryList("GetWithTopCatId", topcatid);
            drpSecondCategory.DataTextField = "SecondCategoryName";
            drpSecondCategory.DataValueField = "SecondCategoryID";
            drpSecondCategory.DataSource = _dt;
            drpSecondCategory.DataBind();
        }

        protected void drpTopCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FilldropDownSecondCategory(drpTopCategory.SelectedValue);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        private void ClearControl()
        {
            Common.ClearControl(Panel1);
            ViewState["examId"] = null;
            btnAdd.Text = "Add";
            FillgridViewExamDetail(MerchantId);
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
                    int examid = Convert.ToInt32(gvExamDetail.DataKeys[gvrow.RowIndex].Value.ToString());
                    _boexmmng.ExamCodeId = examid;
                    _boexmmng.IsDelete = true;
                    _boexmmng.ValidDate = DateTime.UtcNow;
                    _boexmmng.CreatedBy = MerchantId;
                    _boexmmng.CreatedDate = DateTime.UtcNow;
                    _boexmmng.UpdatedBy = MerchantId;
                    _boexmmng.UpdatedDate = DateTime.UtcNow;
                    _boexmmng.Event = "Delete";
                    int rtnvalue = _baexmmng.Delete(_boexmmng);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Exam deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete Exam because used in another entity", MessageType.Info);
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
                int examid = Convert.ToInt32(gvExamDetail.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable table = new DataTable();
                table = _baexmmng.SelectExamDetailWithID("GetExamWithId", examid);
                if (table.Rows.Count > 0)
                {
                    ViewState["examId"] = table.Rows[0]["ExamCodeId"].ToString();
                    txtExamCode.Text = table.Rows[0]["ExamCode"].ToString();
                    txtExamtitle.Text = table.Rows[0]["ExamTitle"].ToString();
                    drpTopCategory.SelectedValue = table.Rows[0]["TopCategoryId"].ToString();
                    FilldropDownSecondCategory(drpTopCategory.SelectedItem.Value);
                    drpSecondCategory.SelectedValue = table.Rows[0]["SecondCategoryId"].ToString();
                    txtPassingPercentage.Text = table.Rows[0]["PassingPercentage"].ToString();
                    txtTestTime.Text = table.Rows[0]["TestTime"].ToString();
                    txtTestOption.Text = table.Rows[0]["TestOption"].ToString();
                    DateTime date = Convert.ToDateTime(table.Rows[0]["ValidDate"]);
                    txtdate.Text = date.ToString("yyyy-MM-dd");
                    btnAdd.Text = "Update";
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

        protected void gvExamDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExamDetail.PageIndex = e.NewPageIndex;
            FillgridViewExamDetail(MerchantId);
        }
    }
}