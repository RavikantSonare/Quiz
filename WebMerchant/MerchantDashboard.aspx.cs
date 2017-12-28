using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantDashboard : System.Web.UI.Page
    {
        public enum MessageType { Success, Error, Info, Warning };
        private int merchantId
        {
            get
            {
                if (ViewState["i"] == null)
                    return 0;
                return (int)ViewState["i"];
            }
            set
            {
                ViewState["i"] = value;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Merchantid"] != null)
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    FilldrpCountry();
                    BAMerchantManage _bamermng = new BAMerchantManage();
                    BOMerchantManage mnag = (BOMerchantManage)Session["merchantDetail"];
                    BOMerchantManage _bomerchantDetail = _bamermng.SelectMerchantLogin("MerchantLogin", mnag.EmailId, mnag.Password);
                    merchantId = _bomerchantDetail.MerchantId;
                    FillMerchantDetail(_bomerchantDetail);
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        private void FilldrpCountry()
        {
            BAMasterCountry _bamstcountry = new BAMasterCountry();
            DataTable _datatable3 = new DataTable();
            _datatable3 = _bamstcountry.GetCountryList("GETALL");
            drpCountry.DataTextField = "Country";
            drpCountry.DataValueField = "CountryId";
            drpCountry.DataSource = _datatable3;
            drpCountry.DataBind();
            FilldrpState(drpCountry.SelectedValue);
        }

        private void FilldrpState(string countryid)
        {
            BAMasterState _bamststate = new BAMasterState();
            DataTable _datatable4 = new DataTable();
            _datatable4 = _bamststate.GetStateList("GETStateWithCouid", countryid);
            drpState.DataTextField = "State";
            drpState.DataValueField = "StateId";
            drpState.DataSource = _datatable4;
            drpState.DataBind();
        }

        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FilldrpState(drpCountry.SelectedValue);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
            }
        }

        private void FillMerchantDetail(BOMerchantManage _bomermng)
        {
            txtMerchantName.Text = _bomermng.MerchantName;
            txtEmailId.Text = _bomermng.EmailId;
            txtUserName.Text = _bomermng.UserName;
            txtpassword.Text = Common.Decryptdata(_bomermng.Password);
            txtMerchantLevel.Text = _bomermng.MerchantLevel;
            txtValidDate.Text = _bomermng.EndDate.ToString("yyyy-MM-dd");
            drpState.SelectedValue = _bomermng.StateId.ToString();
            drpCountry.SelectedValue = _bomermng.CountryId.ToString();
            txtTelephone.Text = _bomermng.Telephone;
            txtBrand.Text = _bomermng.Brand;
            lblPicture.Text = _bomermng.Picture;
            txtAboutMerchant.Text = _bomermng.About;
            lnkbtnUpdate.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this details?");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (fuMerchantPicture.HasFile)
                    {
                        lblPicture.Text = Path.GetFileName(Common.AppendTimeStamp(fuMerchantPicture.PostedFile.FileName));
                        fuMerchantPicture.PostedFile.SaveAs(Server.MapPath("~/img_merchant/") + lblPicture.Text);
                    }
                    BOMerchantManage _bomerchant = new BOMerchantManage();
                    BAMerchantManage _bamerchant = new BAMerchantManage();
                    _bomerchant.MerchantId = merchantId;
                    _bomerchant.MerchantName = txtMerchantName.Text;
                    _bomerchant.UserName = txtUserName.Text;
                    _bomerchant.Password = Common.Encryptdata(txtpassword.Text);
                    _bomerchant.StateId = Convert.ToInt32(drpState.SelectedItem.Value);
                    _bomerchant.Telephone = txtTelephone.Text;
                    _bomerchant.Brand = txtBrand.Text;
                    _bomerchant.Picture = lblPicture.Text;
                    _bomerchant.About = txtAboutMerchant.Text;
                    _bomerchant.IsActive = true;
                    _bomerchant.IsDelete = false;
                    _bomerchant.StartDate = DateTime.UtcNow;
                    _bomerchant.EndDate = DateTime.UtcNow;
                    _bomerchant.CreatedBy = merchantId;
                    _bomerchant.CreatedDate = DateTime.UtcNow;
                    _bomerchant.UpdatedBy = merchantId;
                    _bomerchant.UpdatedDate = DateTime.UtcNow;
                    _bomerchant.Event = "UpdateBySelf";
                    int returnvalue = _bamerchant.Update(_bomerchant);
                    if (returnvalue == 2)
                    {
                        ShowMessage("Updated successfully", MessageType.Success);
                    }
                    else if (returnvalue == -2)
                    {
                        ShowMessage("UserName already taken", MessageType.Info);
                    }
                }
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
    }
}