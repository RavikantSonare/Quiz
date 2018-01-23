using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantCertificate : System.Web.UI.Page
    {
        private BOMerchantCertificate _bomercertfict = new BOMerchantCertificate();
        private BAMerchantCertificate _bamercertfict = new BAMerchantCertificate();

        private BOExamReports _boexmrpt = new BOExamReports();
        private BAExamReports _baexmrpt = new BAExamReports();

        private int MerchantId = default(int);
        public enum MessageType { Success, Error, Info, Warning };
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
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        _dtextrapermission = (DataTable)Session["extrapermission"];
                        exists = _dtextrapermission.Select().ToList().Exists(row => row["ExtraPermissionOptId"].ToString() == "5");
                        if (exists)
                        {
                            pnlCertificate.Visible = true;
                        }
                        // FillgridViewTemplatePicture(MerchantId);
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

        private void FillgridViewTemplatePicture(int mid)
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bamercertfict.SelectCertifcateList("GetCertifcateMID", mid);
            gvCertificateTemplate.DataSource = _datatable1;
            gvCertificateTemplate.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (fuTemplatePicture.HasFile)
                    {
                        lblimg.Text = Path.GetFileName(fuTemplatePicture.PostedFile.FileName);
                        fuTemplatePicture.PostedFile.SaveAs(Server.MapPath("~/TemplateImage/") + lblimg.Text);
                    }
                    _bomercertfict.CertificateTitle = txtCertificateTitle.Text;
                    _bomercertfict.SampleUserName = lblsamplemsg.Text;
                    _bomercertfict.CertificatePic = lblimg.Text;
                    _bomercertfict.NameBox = "";
                    _bomercertfict.DateBox = "";
                    _bomercertfict.MerchantId = MerchantId;
                    _bomercertfict.IsActive = true;
                    _bomercertfict.IsDelete = false;
                    _bomercertfict.CreatedBy = MerchantId;
                    _bomercertfict.CreatedDate = DateTime.UtcNow;
                    _bomercertfict.UpdatedBy = MerchantId;
                    _bomercertfict.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["exmrptId"] != null)
                    {
                        _bomercertfict.CertificateId = Convert.ToInt32(ViewState["exmrptId"]);
                        _bomercertfict.Event = "Update";
                        if (_bamercertfict.Update(_bomercertfict) == 2)
                        {
                            ShowMessage("Certificate detail updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _bomercertfict.CertificateId = 0;
                        _bomercertfict.Event = "Insert";
                        if (_bamercertfict.Insert(_bomercertfict) == 1)
                        {
                            ShowMessage("Certificate detail added successfully", MessageType.Success);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            Clearcontrol();
        }

        private void Clearcontrol()
        {
            txtCertificateTitle.Text = "";
            FillgridViewTemplatePicture(MerchantId);
            lnkbtnSave.Text = "Save to Template";
            lnkbtnSave.OnClientClick = "";
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int exmrptId = Convert.ToInt32(gvCertificateTemplate.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable3 = new DataTable();
                _datatable3 = _bamercertfict.SelectCertifcateDetailWithID("GetTemplateWithTId", exmrptId);
                if (_datatable3.Rows.Count > 0)
                {
                    ViewState["exmrptId"] = _datatable3.Rows[0]["TemplateId"].ToString();
                    txtCertificateTitle.Text = _datatable3.Rows[0]["CertificateTitle"].ToString();
                    lblimg.Text = _datatable3.Rows[0]["TemplatePicture"].ToString();
                    lnkbtnSave.Text = "Update";
                    lnkbtnSave.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
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
                    int examid = Convert.ToInt32(gvCertificateTemplate.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bomercertfict.CertificateId = examid;
                    _bomercertfict.CertificateTitle = txtCertificateTitle.Text;
                    _bomercertfict.NameBox = "";
                    _bomercertfict.DateBox = "";
                    _bomercertfict.SampleUserName = lblsamplemsg.Text;
                    _bomercertfict.CertificatePic = lblimg.Text;
                    _bomercertfict.MerchantId = MerchantId;
                    _bomercertfict.IsActive = true;
                    _bomercertfict.IsDelete = true;
                    _bomercertfict.CreatedBy = MerchantId;
                    _bomercertfict.CreatedDate = DateTime.UtcNow;
                    _bomercertfict.UpdatedBy = MerchantId;
                    _bomercertfict.UpdatedDate = DateTime.UtcNow;
                    _bomercertfict.Event = "Delete";
                    int rtnvalue = _bamercertfict.Delete(_bomercertfict);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Certificate detail deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete certificate because used in another entity", MessageType.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            Clearcontrol();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Clearcontrol();
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

        protected void gvCertificateTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCertificateTemplate.PageIndex = e.NewPageIndex;
            FillgridViewTemplatePicture(MerchantId);
        }

        protected void lnkbtnresultdelete_Click(object sender, EventArgs e)
        {
            BOExamManage _boexmnge = new BOExamManage();
            BAExamManage _baexmmng = new BAExamManage();
            LinkButton lnkbtn = sender as LinkButton;
            int id = Convert.ToInt32(lnkbtn.CommandArgument);
            //_boexmnge.ExamCodeId = _boexammanage.ExamCodeId;
            //_boexmnge.OnlyTestOnce = false;
            //_boexmnge.UpdatedBy = _bouserDetail.UserId;
            //_boexmnge.UpdatedDate = DateTime.UtcNow;
            //_boexmnge.Event = "UpdateByUser";
            //_baexmmng.IUD(_boexmnge);
        }
    }
}