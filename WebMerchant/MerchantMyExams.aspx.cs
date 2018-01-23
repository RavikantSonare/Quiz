using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;
using System.Web.Services;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;
using System.Net;

namespace WebMerchant
{
    public partial class MerchantMyExams : System.Web.UI.Page
    {
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private BOBundleExam _bobndlexm = new BOBundleExam();
        private BABundleExam _babndlexm = new BABundleExam();
        public enum MessageType { Success, Error, Info, Warning };
        private static int MerchantId = default(int);
        DataTable _dtextrapermission = new DataTable();
        bool exists;

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
                        _dtextrapermission = (DataTable)Session["extrapermission"];
                        exists = _dtextrapermission.Select().ToList().Exists(row => row["ExtraPermissionOptId"].ToString() == "6");
                        FillgridViewExamDetail("GetExamWithMId", _bomerchantDetail.MerchantId, "");
                        FillBundleGrid("GetAll", MerchantId);
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

        protected void btnExamdelete_Click(object sender, EventArgs e)
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

        private void FillBundleGrid(string eventtxt, int merchantid)
        {
            DataTable _datatable = new DataTable();
            _datatable = _babndlexm.SelectBundleDetail("GetAll", merchantid);
            gridBundle.DataSource = _datatable;
            gridBundle.DataBind();
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

        protected void lnkbtnBundleEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int bundleid = Convert.ToInt32(gridBundle.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable table = new DataTable();
                table = _babndlexm.SelectBundleDetailWithID("GetBundleWithId", bundleid);
                if (table.Rows.Count > 0)
                {
                    ViewState["bundleId"] = table.Rows[0]["BundleId"].ToString();
                    txtContent.Text = table.Rows[0]["BundleContent"].ToString();
                    txtPrice.Text = table.Rows[0]["Price"].ToString();
                    chkfeatureestore.Checked = Convert.ToBoolean(table.Rows[0]["FeaturedSelfsEstore"]);
                    MerchantId = Convert.ToInt32(table.Rows[0]["MerchantId"].ToString());
                    lnkbtnAddBundle.Text = "Update";
                    lnkbtnAddBundle.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lnkbtnBundleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int bundleid = Convert.ToInt32(gridBundle.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bobndlexm.BundleId = bundleid;
                    _bobndlexm.IsDelete = true;
                    _bobndlexm.CreatedBy = MerchantId;
                    _bobndlexm.CreatedDate = DateTime.UtcNow;
                    _bobndlexm.UpdatedBy = MerchantId;
                    _bobndlexm.UpdatedDate = DateTime.UtcNow;
                    _bobndlexm.Event = "Delete";
                    int rtnvalue = _babndlexm.Delete(_bobndlexm);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Exam deleted successfully", MessageType.Success);
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

        [WebMethod]
        public static string InsertConfigData(int Examid, int Questiono, decimal Price, string ExamPic, string ExamDes)
        {
            string status = string.Empty;
            try
            {
                String path = HttpContext.Current.Server.MapPath("~/img_exmestoreconfig"); //Path
                                                                                           //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }
                string imagename = Common.AppendTimeStamp("exmpic.png");
                string imgPath = Path.Combine(path, imagename);
                // string convert = ExamPic.Replace("data:image/png;base64,", String.Empty);
                string convert = ExamPic.Split(',')[1];
                byte[] imageBytes = Convert.FromBase64String(convert);
                File.WriteAllBytes(imgPath, imageBytes);

                BOMerchantEstoreConfig _bomecnfg = new BOMerchantEstoreConfig();
                BAMerchantEstoreConfig _bamecnfg = new BAMerchantEstoreConfig();
                _bomecnfg.QuestionNumber = Questiono;
                _bomecnfg.Price = Price;
                _bomecnfg.ExamPicture = imagename;
                _bomecnfg.ExamDescription = ExamDes;
                _bomecnfg.ExamId = Examid;
                _bomecnfg.MerchantId = MerchantId;
                _bomecnfg.IsActive = true;
                _bomecnfg.IsDelete = false;
                _bomecnfg.Createdby = MerchantId;
                _bomecnfg.CreatedDate = DateTime.UtcNow;
                _bomecnfg.UpdatedBy = MerchantId;
                _bomecnfg.UpdatedDate = DateTime.UtcNow;
                _bomecnfg.Event = "Insert";
                if (_bamecnfg.Insert(_bomecnfg) == 1)
                {
                    status = "Insert successfully";
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                status = ex.ToString(); ;
            }
            return status;
        }

        private void ClearControl()
        {
            Common.ClearControl(pnlbundle);
            lnkbtnAddBundle.Text = "Add";
            lnkbtnAddBundle.OnClientClick = "";
            ViewState["bundleId"] = "";
            ViewState["bundleId"] = null;
            FillBundleGrid("GetAll", MerchantId);
        }

        protected void gvExamDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!exists)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    gvExamDetail.Columns[12].Visible = false;
                }
            }
        }
    }
}