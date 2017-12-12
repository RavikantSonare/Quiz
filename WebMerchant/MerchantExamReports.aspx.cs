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
    public partial class MerchantExamReports : System.Web.UI.Page
    {
        private BOTemplate _botmplt = new BOTemplate();
        private BATemplate _batmple = new BATemplate();

        private BOExamReports _boexmrpt = new BOExamReports();
        private BAExamReports _baexmrpt = new BAExamReports();

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
                        FillgridViewExamReport(MerchantId);
                        FillgridViewTemplatePicture(MerchantId);
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
            _datatable1 = _batmple.SelecttemplateList("GetTemplateMID", mid);
            gvCertificateTemplate.DataSource = _datatable1;
            gvCertificateTemplate.DataBind();
        }

        private void FillgridViewExamReport(int mid)
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _baexmrpt.SelectExamreportList("GetExamRptMID", mid);
            gvExamReport.DataSource = _datatable2;
            gvExamReport.DataBind();
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
                    _botmplt.CertificateTitle = txtCertificateTitle.Text;
                    _botmplt.SampleUserName = lblsamplemsg.Text;
                    _botmplt.TemplatePicture = lblimg.Text;
                    _botmplt.MerchantId = MerchantId;
                    _botmplt.IsActive = true;
                    _botmplt.IsDelete = false;
                    _botmplt.CreatedBy = MerchantId;
                    _botmplt.CreatedDate = DateTime.UtcNow;
                    _botmplt.UpdatedBy = MerchantId;
                    _botmplt.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["exmrptId"] != null)
                    {
                        _botmplt.TemplateId = Convert.ToInt32(ViewState["exmrptId"]);
                        _botmplt.Event = "Update";
                        if (_batmple.Update(_botmplt) == 2)
                        {
                            ShowMessage("Certificate detail updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _botmplt.TemplateId = 0;
                        _botmplt.Event = "Insert";
                        if (_batmple.Insert(_botmplt) == 1)
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
            FillgridViewExamReport(MerchantId);
            FillgridViewTemplatePicture(MerchantId);
            btnSave.Text = "Save to Template";
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int exmrptId = Convert.ToInt32(gvCertificateTemplate.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable3 = new DataTable();
                _datatable3 = _batmple.SelectTemplateDetailWithID("GetTemplateWithTId", exmrptId);
                if (_datatable3.Rows.Count > 0)
                {
                    ViewState["exmrptId"] = _datatable3.Rows[0]["TemplateId"].ToString();
                    txtCertificateTitle.Text = _datatable3.Rows[0]["CertificateTitle"].ToString();
                    lblimg.Text = _datatable3.Rows[0]["TemplatePicture"].ToString();
                    btnSave.Text = "Update";
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
                    _botmplt.TemplateId = examid;
                    _botmplt.CertificateTitle = txtCertificateTitle.Text;
                    _botmplt.SampleUserName = lblsamplemsg.Text;
                    _botmplt.TemplatePicture = lblimg.Text;
                    _botmplt.MerchantId = MerchantId;
                    _botmplt.IsActive = true;
                    _botmplt.IsDelete = true;
                    _botmplt.CreatedBy = MerchantId;
                    _botmplt.CreatedDate = DateTime.UtcNow;
                    _botmplt.UpdatedBy = MerchantId;
                    _botmplt.UpdatedDate = DateTime.UtcNow;
                    _botmplt.Event = "Delete";
                    int rtnvalue = _batmple.Delete(_botmplt);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Certificate detail deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete certificate because used in another entity", MessageType.Info);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            Clearcontrol();
        }

        protected void gvExamReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find the DropDownList in the Row
                    DropDownList ddlTemplate = (e.Row.FindControl("drpTemplate") as DropDownList);
                    DataTable _datatable4 = new DataTable();
                    _datatable4 = _batmple.SelecttemplateList("GetTemplateMID", MerchantId);
                    if (_datatable4.Rows.Count > 0)
                    {
                        ddlTemplate.DataSource = _datatable4;
                        ddlTemplate.DataTextField = "CertificateTitle";
                        ddlTemplate.DataValueField = "TemplateId";
                        ddlTemplate.DataBind();
                    }
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

        protected void gvExamReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExamReport.PageIndex = e.NewPageIndex;
            FillgridViewExamReport(MerchantId);
        }

        protected void gvCertificateTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCertificateTemplate.PageIndex = e.NewPageIndex;
            FillgridViewTemplatePicture(MerchantId);
        }
    }
}