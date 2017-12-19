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
    public partial class MerchantMyExams : System.Web.UI.Page
    {
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private BOBundleExam _bobndlexm = new BOBundleExam();
        private BABundleExam _babndlexm = new BABundleExam();
        public enum MessageType { Success, Error, Info, Warning };
        private int MerchantId = default(int);
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
                        FillgridViewExamDetail("GetExamWithMId", _bomerchantDetail.MerchantId, "");
                        FillBundleGrid("GetAll", MerchantId);
                        //FillgridViewExamDetail("GetReportWithMrID", _bomerchantDetail.MerchantId);
                        if (_bomerchantDetail.MerchantLevel == "Free")
                        {
                            gvExamDetail.Columns[0].Visible = gvExamDetail.Columns[6].Visible = gvExamDetail.Columns[7].Visible = gvExamDetail.Columns[8].Visible = gvExamDetail.Columns[9].Visible = gvExamDetail.Columns[10].Visible = false;
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

        private void FillgridViewExamDetail(string eventtext, int Merchantid, string searchtext)
        {
            BAExamManage _baexmmng = new BAExamManage();
            DataTable _datatable = new DataTable();
            _datatable = _baexmmng.SelectExamDetail(eventtext, Merchantid, searchtext);
            //BASalesReports _baslsrpt = new BASalesReports();
            //DataTable _datatable = new DataTable();
            //_datatable = _baslsrpt.SelectSalesReprotsWithMrid(eventtext, Merchantid);
            gvExamDetail.DataSource = _datatable;
            gvExamDetail.DataBind();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void lnkbtnallowsales_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                string examid = lnkbtn.CommandArgument;
                if (examid != "")
                {
                    string name = HttpUtility.UrlEncode(Common.Encrypt(examid));
                    Response.Redirect(string.Format("MerchantAllowSales.aspx?examid=" + name), false);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void gvExamDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExamDetail.PageIndex = e.NewPageIndex;
            FillgridViewExamDetail("GetExamWithMId", MerchantId, "");
        }

        protected void lnkbtnGenerateExamSimulator_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnGenerateExamSimulatorDemo_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnOnlyTestOnce_Click(object sender, EventArgs e)
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
                _boexmmng.UpdatedBy = MerchantId;
                _boexmmng.UpdatedDate = DateTime.UtcNow;
                _boexmmng.Event = "UpdateOnlyTestOnce";
                _baexmmng.Update(_boexmmng);
                FillgridViewExamDetail("GetExamWithMId", MerchantId, "");
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
                _boexmmng.UpdatedBy = MerchantId;
                _boexmmng.UpdatedDate = DateTime.UtcNow;
                _boexmmng.Event = "UpdateAllowPrint";
                _baexmmng.Update(_boexmmng);
                FillgridViewExamDetail("GetExamWithMId", MerchantId, "");
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillgridViewExamDetail("GetExamWithMId", MerchantId, txtsearch.Text);
        }

        protected void btnAddBundle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _bobndlexm.BundleContent = txtContent.Text;
                    _bobndlexm.Price = Convert.ToDecimal(txtPrice.Text);
                    _bobndlexm.FeaturedSelfsEstore = chkfeatureestore.Checked;
                    _bobndlexm.MerchantId = MerchantId;
                    _bobndlexm.IsActive = true;
                    _bobndlexm.IsDelete = false;
                    _bobndlexm.CreatedBy = MerchantId;
                    _bobndlexm.CreatedDate = DateTime.UtcNow;
                    _bobndlexm.UpdatedBy = MerchantId;
                    _bobndlexm.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["bundleId"] != null)
                    {
                        _bobndlexm.BundleId = Convert.ToInt32(ViewState["bundleId"]);
                        _bobndlexm.Event = "Update";
                        if (_babndlexm.Update(_bobndlexm) == 2)
                        {
                            ShowMessage("Bundle updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _bobndlexm.BundleId = 0;
                        _bobndlexm.Event = "Insert";
                        if (_babndlexm.Insert(_bobndlexm) == 1)
                        {
                            ShowMessage("Bundle added successfully", MessageType.Success);
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

        private void FillBundleGrid(string eventtxt, int merchantid)
        {
            DataTable _datatable = new DataTable();
            _datatable = _babndlexm.SelectBundleDetail("GetAll", merchantid);
            gridBundle.DataSource = _datatable;
            gridBundle.DataBind();
        }

        private void ClearControl()
        {
            Common.ClearControl(pnlbundle);
            btnAddBundle.Text = "Add";
            ViewState["bundleId"] = "";
            ViewState["bundleId"] = null;
        }
    }
}