using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminMerchantManageEdit : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOMerchantManage _bommng = new BOMerchantManage();
        private BAMerchantManage _bammng = new BAMerchantManage();
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
                        if (Request.QueryString["mID"] != "")
                        {
                            ViewState["querystring"] = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["mID"]));
                            FilldrpMerchantlevel();
                            FillMerchantDetail(Convert.ToInt32(ViewState["querystring"]));
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

        private void FillMerchantDetail(int mid)
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bammng.SelectMerchantManage("GETWITHID", mid);
            if (_datatable1.Rows.Count > 0)
            {
                txtMerchantName.Text = _datatable1.Rows[0]["MerchantName"].ToString();
                txtTelephone.Text = _datatable1.Rows[0]["Telephone"].ToString();
                drpMerchantLevel.SelectedValue = _datatable1.Rows[0]["MerchantLevelId"].ToString();
                ddlActiveStatus.SelectedValue = _datatable1.Rows[0]["ActiveStatus"].ToString();
                DateTime startdate = Convert.ToDateTime(_datatable1.Rows[0]["StartDate"]);
                txtStartDate.Text = startdate.ToString("yyyy-MM-dd");
                DateTime enddate = Convert.ToDateTime(_datatable1.Rows[0]["EndDate"]);
                txtEndDate.Text = enddate.ToString("yyyy-MM-dd");
                txtpassword.Text = Decryptdata(_datatable1.Rows[0]["Password"].ToString());
                txtEmailId.Text = _datatable1.Rows[0]["EmailId"].ToString();
            }
        }

        private void FilldrpMerchantlevel()
        {
            BAMerchantLevel _bamlvl = new BALayer.BAMerchantLevel();
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bamlvl.GetMerchantLevelList("GETALL");
            drpMerchantLevel.DataTextField = "MerchantLevel";
            drpMerchantLevel.DataValueField = "MerchantLevelId";
            drpMerchantLevel.DataSource = _datatable2;
            drpMerchantLevel.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {
                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                if (validateForm())
                {
                    _bommng.MerchantId = Convert.ToInt32(ViewState["querystring"]);
                    _bommng.MerchantName = txtMerchantName.Text;
                    _bommng.Password = Encryptdata(txtpassword.Text);
                    _bommng.EmailId = txtEmailId.Text;
                    _bommng.Telephone = txtTelephone.Text;
                    _bommng.MerchantLevelId = Convert.ToInt32(drpMerchantLevel.SelectedItem.Value);
                    _bommng.StartDate = Convert.ToDateTime(txtStartDate.Text);
                    _bommng.EndDate = Convert.ToDateTime(txtEndDate.Text);
                    _bommng.ActiveStatus = Convert.ToBoolean(ddlActiveStatus.SelectedItem.Value);
                    _bommng.UpdatedBy = adminId;
                    _bommng.UpdatedDate = DateTime.UtcNow;
                    _bommng.Event = "Update";
                    int result = _bammng.Update(_bommng);
                    if (result == 2)
                    {
                        ShowMessage("Merchant updated successfully", MessageType.Success);
                    }
                }
            }
        }

        private bool validateForm()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtMerchantName.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter merchant name";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtTelephone.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter mobile number";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtEmailId.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter email id";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter password";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (drpMerchantLevel.SelectedIndex < 0)
            {
                ret = false;
                lblerror.InnerText = "Select merchant level";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (ddlActiveStatus.SelectedIndex < 0)
            {
                ret = false;
                lblerror.InnerText = "Select status";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter start date";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter end date";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            return ret;
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');window.location='" + Request.ApplicationPath + "AdminMerchantManage.aspx'", true);
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}