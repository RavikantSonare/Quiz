using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;

namespace WebMerchant
{
    public partial class MerchantMyUsers : System.Web.UI.Page
    {
        private BOMyUsers _bomyuser = new BOMyUsers();
        private BAMyUsers _bamyuser = new BAMyUsers();
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
                        FillddlCategory();
                        FillchkboxListExam(MerchantId);
                        FillgridViewUserList(MerchantId);
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

        private void FillchkboxListExam(int mid)
        {
            BAExamManage _baexmmng = new BAExamManage();
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baexmmng.SelectExamDetail("GetExamWithMId", mid);
            if (_datatable1.Rows.Count > 0)
            {
                chkExamCodeList.DataValueField = "ExamCodeId";
                chkExamCodeList.DataTextField = "ExamCode";
                chkExamCodeList.DataSource = _datatable1;
                chkExamCodeList.DataBind();
            }
        }

        private void FillgridViewUserList(int mid)
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bamyuser.SelectUserDetail("GetUserWithMId", mid);
            gvMyUser.DataSource = _datatable2;
            gvMyUser.DataBind();
        }

        private void FillddlCategory()
        {
            BASecondCategory bascat = new BASecondCategory();
            DataTable _datatable3 = new DataTable();
            _datatable3 = bascat.SelectSecondCategoryList("GETALL");
            ddlCategory.DataTextField = "SecondCategoryName";
            ddlCategory.DataValueField = "SecondCategoryId";
            ddlCategory.DataSource = _datatable3;
            ddlCategory.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _bomyuser.UserName = txtUserName.Text;
                    _bomyuser.AccessPassword = Encryptdata(txtPassword.Text);
                    _bomyuser.MerchantId = MerchantId;
                    _bomyuser.SecondCategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                    _bomyuser.ExamId = chklist().Item2;
                    _bomyuser.ExamCode = chklist().Item1;
                    _bomyuser.ValidTime = Convert.ToDateTime(txtValidTime.Text);
                    _bomyuser.AccessOption = accessoption();
                    _bomyuser.IsActive = true;
                    _bomyuser.IsDelete = false;
                    _bomyuser.CreatedBy = MerchantId;
                    _bomyuser.CreatedDate = DateTime.UtcNow;
                    _bomyuser.UpdatedBy = MerchantId;
                    _bomyuser.UpdatedDate = DateTime.UtcNow;
                    _bomyuser.ValidTimeTo = Convert.ToDateTime(txtValidTimeto.Text);
                    if (ViewState["userId"] != null)
                    {
                        _bomyuser.UserId = Convert.ToInt32(ViewState["userId"]);
                        _bomyuser.Event = "Update";
                        if (_bamyuser.Update(_bomyuser) == 2)
                        {
                            ShowMessage("User updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _bomyuser.UserId = 0;
                        _bomyuser.Event = "Insert";
                        if (_bamyuser.Insert(_bomyuser) == 1)
                        {
                            ShowMessage("User added successfully", MessageType.Success);
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

        private Tuple<string, string> chklist()
        {
            string exmcode = string.Empty;
            string exmcodeid = string.Empty;
            foreach (ListItem item in chkExamCodeList.Items)
            {
                if (item.Selected)
                {
                    if (exmcode != "" && exmcode != null)
                    {
                        exmcode += "," + item.Text;
                        exmcodeid += "," + item.Value;
                    }
                    else
                    {
                        exmcode += item.Text;
                        exmcodeid += item.Value;
                    }
                }
            }

            return Tuple.Create(exmcode, exmcodeid);
        }

        private string accessoption()
        {
            string str = default(string);
            foreach (ListItem item in chklistAccessoption.Items)
            {
                if (item.Selected)
                {
                    if (str != "" && str != null)
                    {
                        str += "&" + item.Text;
                    }
                    else
                    {
                        str += item.Text;
                    }
                }
            }
            return str;
        }

        private void ClearControl()
        {
            Common.ClearControl(pnlMyuser);
            btnAdd.Text = "Add";
            ViewState["userId"] = "";
            ViewState["userId"] = null;
            FillchkboxListExam(MerchantId);
            FillgridViewUserList(MerchantId);
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

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int userId = Convert.ToInt32(gvMyUser.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable4 = new DataTable();
                _datatable4 = _bamyuser.SelectUserDetailWithID("GetUserWithUId", userId);
                if (_datatable4.Rows.Count > 0)
                {
                    ViewState["userId"] = _datatable4.Rows[0]["UserId"].ToString();
                    txtUserName.Text = _datatable4.Rows[0]["UserName"].ToString();
                    txtPassword.Text = Decryptdata(_datatable4.Rows[0]["AccessPassword"].ToString());
                    ddlCategory.SelectedItem.Text = _datatable4.Rows[0]["SecondCategoryName"].ToString();
                    string[] examId = _datatable4.Rows[0]["ExamId"].ToString().Split(',');
                    for (int i = 0; i < chkExamCodeList.Items.Count; i++)
                    {
                        chkExamCodeList.Items[i].Selected = false;
                        for (int x = 0; x < examId.Length; x++)
                        {
                            if (chkExamCodeList.Items[i].Value == examId[x])
                            {
                                chkExamCodeList.Items[i].Selected = true;
                            }
                        }
                    }
                    DateTime dateform = Convert.ToDateTime(_datatable4.Rows[0]["ValidTime"]);
                    txtValidTime.Text = dateform.ToString("yyyy-MM-ddTHH:mm");
                    string[] accessoption = _datatable4.Rows[0]["AccessOption"].ToString().Split('&');
                    for (int i = 0; i < chklistAccessoption.Items.Count; i++)
                    {
                        chklistAccessoption.Items[i].Selected = false;
                        for (int x = 0; x < accessoption.Length; x++)
                        {
                            if (chklistAccessoption.Items[i].Value == accessoption[x])
                            {
                                chklistAccessoption.Items[i].Selected = true;
                            }
                        }
                    }
                    DateTime dateto = Convert.ToDateTime(_datatable4.Rows[0]["ValidTimeTo"]);
                    txtValidTimeto.Text = dateto.ToString("yyyy-MM-ddTHH:mm");
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
                    int userId = Convert.ToInt32(gvMyUser.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bomyuser.UserId = userId;
                    _bomyuser.IsDelete = true;
                    _bomyuser.CreatedBy = MerchantId;
                    _bomyuser.CreatedDate = DateTime.UtcNow;
                    _bomyuser.UpdatedBy = MerchantId;
                    _bomyuser.UpdatedDate = DateTime.UtcNow;
                    _bomyuser.Event = "Delete";
                    int rtnvalue = _bamyuser.Delete(_bomyuser);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("User deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete user because used in another entity", MessageType.Info);
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

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvMyUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Decryptdata(e.Row.Cells[2].Text);
            }
        }

        protected void gvMyUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMyUser.PageIndex = e.NewPageIndex;
            FillgridViewUserList(MerchantId);
        }
    }
}