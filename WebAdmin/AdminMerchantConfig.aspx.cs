using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebAdmin.BOLayer;
using WebAdmin.BALayer;

namespace WebAdmin
{
    public partial class AdminMerchantConfig : System.Web.UI.Page
    {
        private int adminId = default(int);
        private BOMerchantLevel _bomlvl = new BOMerchantLevel();
        private BAMerchantLevel _bamlvl = new BAMerchantLevel();
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

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
                        BindQuestionTypeCheckboxList();
                        BindExtraPermissionCheckboxList();
                        FillgridViewMerchantLevel();
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

        private void BindQuestionTypeCheckboxList()
        {
            BOQuestionType _boqtype = new BOQuestionType();
            BAQuestionType _baqtype = new BAQuestionType();
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baqtype.SelectQuestionType("GETALL");
            foreach (DataRow row in _datatable1.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["QuestionType"].ToString();
                item.Value = row["QuestionTypeId"].ToString();
                item.Selected = Convert.ToBoolean(row["DefaultPermission"]);
                item.Enabled = !Convert.ToBoolean(row["DefaultPermission"]);
                chkQuestionType.Items.Add(item);
            }
        }

        private void BindExtraPermissionCheckboxList()
        {
            BOExtraPermission _boextper = new BOExtraPermission();
            BAExtraPermission _baextper = new BAExtraPermission();
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baextper.SelectExtraPermission("GETALL");
            foreach (DataRow row in _datatable1.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["ExtraPermissionOpt"].ToString();
                item.Value = row["ExtraPermissionOptId"].ToString();
                item.Selected = Convert.ToBoolean(row["DefaultPermission"]);
                item.Enabled = !Convert.ToBoolean(row["DefaultPermission"]);
                chkExtraPermission.Items.Add(item);
            }
        }

        private void FillgridViewMerchantLevel()
        {
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bamlvl.GetMerchantLevelList("GETALL");
            gvMerchantLevel.DataSource = _datatable1;
            gvMerchantLevel.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string questiontype = string.Empty;
                string extrapermission = string.Empty;
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (validateForm())
                    {
                        _bomlvl.MerchantLevel = txtMerchantLevel.Text;
                        _bomlvl.AnnualFee = Convert.ToDecimal(txtPrice.Text);
                        _bomlvl.ExamCount = Convert.ToInt32(txtExamCount.Text);
                        _bomlvl.StudentCount = Convert.ToInt32(txtStudentCount.Text);
                        _bomlvl.ShopperFee = Convert.ToDecimal(txtShopperFee.Text);
                        foreach (ListItem item in chkQuestionType.Items)
                        {
                            if (item.Selected)
                            {
                                if (questiontype != "" && questiontype != null)
                                {
                                    questiontype += "," + item.Value;
                                }
                                else
                                {
                                    questiontype += item.Value;
                                }
                            }
                        }
                        _bomlvl.QuestionType = questiontype;
                        foreach (ListItem item in chkExtraPermission.Items)
                        {
                            if (item.Selected)
                            {
                                if (extrapermission != "" && extrapermission != null)
                                {
                                    extrapermission += "," + item.Value;
                                }
                                else
                                {
                                    extrapermission += item.Value;
                                }
                            }
                        }
                        _bomlvl.ExtraPermission = extrapermission;
                        _bomlvl.IsActive = true;
                        _bomlvl.IsDelete = false;
                        _bomlvl.CreatedBy = adminId;
                        _bomlvl.CreatedDate = DateTime.UtcNow;
                        _bomlvl.UpdateBy = adminId;
                        _bomlvl.UpdateDate = DateTime.UtcNow;
                        if (ViewState["mlvlId"] != null)
                        {
                            _bomlvl.MerchantLevelId = Convert.ToInt32(ViewState["mlvlId"]);
                            _bomlvl.Event = "Update";
                            if (_bamlvl.Update(_bomlvl) == 2)
                            {
                                ShowMessage("Merchant level updated successfully", MessageType.Success);
                            }
                        }
                        else
                        {
                            _bomlvl.MerchantLevelId = 0;
                            _bomlvl.Event = "Insert";
                            if (_bamlvl.Insert(_bomlvl) == 1)
                            {
                                ShowMessage("Merchant level added successfully", MessageType.Success);
                            }
                        }
                    }
                    else
                    {
                        lblerror.InnerText = "Please enter top Merchant level and annual fee";
                        lblerror.Attributes.Add("Style", "display: block;color: #D8000C;");
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
                int mlvlId = Convert.ToInt32(gvMerchantLevel.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable2 = new DataTable();
                _datatable2 = _bamlvl.SelectMerchantLevelWithID("GetMLevelwithId", mlvlId);
                if (_datatable2.Rows.Count > 0)
                {
                    ViewState["mlvlId"] = _datatable2.Rows[0]["MerchantLevelId"].ToString();
                    txtMerchantLevel.Text = _datatable2.Rows[0]["MerchantLevel"].ToString();
                    txtPrice.Text = _datatable2.Rows[0]["AnnualFee"].ToString();
                    txtExamCount.Text = _datatable2.Rows[0]["ExamCount"].ToString();
                    txtStudentCount.Text = _datatable2.Rows[0]["StudentCount"].ToString();
                    txtShopperFee.Text = _datatable2.Rows[0]["ShopperFee"].ToString();
                    string[] qtype = _datatable2.Rows[0]["QuestionType"].ToString().Split(',');
                    for (int i = 0; i < chkQuestionType.Items.Count; i++)
                    {
                        chkQuestionType.Items[i].Selected = false;
                        for (int x = 0; x < qtype.Length; x++)
                        {
                            if (chkQuestionType.Items[i].Value == qtype[x])
                            {
                                chkQuestionType.Items[i].Selected = true;
                            }
                        }
                    }
                    string[] extrapermission = _datatable2.Rows[0]["ExtraPermission"].ToString().Split(',');
                    for (int i = 0; i < chkExtraPermission.Items.Count; i++)
                    {
                        chkExtraPermission.Items[i].Selected = false;
                        for (int x = 0; x < extrapermission.Length; x++)
                        {
                            if (chkExtraPermission.Items[i].Value == extrapermission[x])
                            {
                                chkExtraPermission.Items[i].Selected = true;
                            }
                        }
                    }
                    lnkbtnAdd.Text = "Update";
                    lnkbtnAdd.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
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
                    int mlvlId = Convert.ToInt32(gvMerchantLevel.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bomlvl.MerchantLevelId = mlvlId;
                    _bomlvl.IsDelete = true;
                    _bomlvl.CreatedBy = adminId;
                    _bomlvl.CreatedDate = DateTime.UtcNow;
                    _bomlvl.UpdateBy = adminId;
                    _bomlvl.UpdateDate = DateTime.UtcNow;
                    _bomlvl.Event = "Delete";
                    int rtnvalue = _bamlvl.Delete(_bomlvl);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Merchant level deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete Merchant level because used in another entity", MessageType.Info);
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

        protected void gvMerchantLevel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvMerchantLevel.PageIndex = e.NewPageIndex;
                FillgridViewMerchantLevel();
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        private bool validateForm()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(txtMerchantLevel.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter merchant level";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter price";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtExamCount.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter exam count";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtStudentCount.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter student count";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (string.IsNullOrEmpty(txtShopperFee.Text))
            {
                ret = false;
                lblerror.InnerText = "Enter shopper fee";
                lblerror.Attributes.Add("Style", "display: block;color: Red;");
                return false;
            }
            else
            {
                lblerror.InnerText = "";
            }
            if (chkQuestionType.SelectedIndex < 0)
            {
                ret = false;
                lblerror.InnerText = "select at least one extra permission";
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        private void ClearControl()
        {
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            ViewState["mlvlId"] = "";
            ViewState["mlvlId"] = null;
            FillgridViewMerchantLevel();
            Common.ClearControl(Panel1);
        }
    }
}