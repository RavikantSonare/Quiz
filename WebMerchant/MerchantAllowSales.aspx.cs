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
    public partial class MerchantAllowSales : System.Web.UI.Page
    {
        private BOMerchantAllowSales _bomallsales = new BOMerchantAllowSales();
        private BAMerchantAllowSales _bamallsales = new BAMerchantAllowSales();
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
                        if (Request.QueryString["examid"] != null)
                        {
                            ViewState["querystring"] = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["examid"]));
                            FillGridviewAllowSales(Convert.ToInt32(ViewState["querystring"]));
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

        private void FillGridviewAllowSales(int examid)
        {
            DataTable _datatable = new DataTable();
            _datatable = _bamallsales.SelectAllowSales("GetwithId", examid);
            gvAllowSales.DataSource = _datatable;
            gvAllowSales.DataBind();
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    string selfdescription = "Auto Insert Self Description";
                    _bomallsales.ExamId = Convert.ToInt32(ViewState["querystring"]);
                    _bomallsales.NoofQuestion = Convert.ToInt32(txtTotalQuestion.Text);
                    _bomallsales.Price = Convert.ToDecimal(txtPrice.Text);
                    if (!string.IsNullOrEmpty(txtSelfDescription.Text))
                        _bomallsales.SelfDescription = txtSelfDescription.Text;
                    else
                        _bomallsales.SelfDescription = selfdescription;
                    _bomallsales.IsActive = true;
                    _bomallsales.IsDelete = false;
                    _bomallsales.CreatedBy = MerchantId;
                    _bomallsales.CreatedDate = DateTime.UtcNow;
                    _bomallsales.UpdatedBy = MerchantId;
                    _bomallsales.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["allslsid"] != null && !ViewState["allslsid"].Equals(""))
                    {
                        _bomallsales.Id = Convert.ToInt32(ViewState["allslsid"]);
                        _bomallsales.Event = "Update";
                        //if (_bamallsales.Update(_bomallsales) == 2)
                        //{
                        //    ShowMessage("Exam updated successfully", MessageType.Success);
                        //}
                    }
                    else
                    {
                        _bomallsales.Id = 0;
                        _bomallsales.Event = "Insert";
                        if (_bamallsales.Insert(_bomallsales) == 1)
                        {
                            ShowMessage("Details added successfully", MessageType.Success);
                        }
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
            ClearControl();
        }

        private void ClearControl()
        {
            Common.ClearControl(Panel1);
            FillGridviewAllowSales(Convert.ToInt32(ViewState["querystring"]));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void gvAllowSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAllowSales.PageIndex = e.NewPageIndex;
            FillGridviewAllowSales(Convert.ToInt32(ViewState["querystring"]));
        }
    }
}