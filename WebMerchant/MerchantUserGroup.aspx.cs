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
    public partial class MerchantUserGroup : System.Web.UI.Page
    {
        private BOUserGroup _bousergrp = new BOUserGroup();
        private BAUserGroup _bausergrp = new BAUserGroup();
        private int MerchantId = default(int);
        public enum MessageType { Success, Error, Info, Warning };
        static List<ListItem> selected, unselected;
        private List<string> setcurrentitem
        {
            get
            {
                if (ViewState["setcurrentitem"] == null)
                    return null;
                return (List<string>)ViewState["setcurrentitem"];
            }
            set
            {
                ViewState["setcurrentitem"] = value;
            }
        }

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
                        FillTopddlCategory();
                        FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
                        FillchkboxListAccessOption();
                        FillgridViewUserGroupList(MerchantId);
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

        private void FillchkboxListExam(int catid, int mid)
        {
            selected = chkExamCodeList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            unselected = chkExamCodeList.Items.Cast<ListItem>().Where(li => !li.Selected).ToList();
            if (selected.Count > 0)
            {
                foreach (ListItem listItem in selected)
                {
                    if (!setcurrentitem.Contains(listItem.Value))
                    {
                        setcurrentitem.Add(listItem.Value);
                    }
                }
                foreach (ListItem listItem in unselected)
                {
                    if (setcurrentitem.Contains(listItem.Value))
                    {
                        setcurrentitem.Remove(listItem.Value);
                    }
                }
            }
            BAExamManage _baexmmng = new BAExamManage();
            DataTable _datatable1 = new DataTable();
            _datatable1 = _baexmmng.SelectExamDetail("GetExamWithMId", mid, "");
            _datatable1.Columns.Add("FullName", typeof(string), "ExamCode + ' (' + SecondCategoryName +')'");
            if (catid > 0)
            {
                var rows = _datatable1.AsEnumerable().Where(row => row.Field<int>("SecondCategoryId") == catid).ToList();
                if (rows.Any())
                    _datatable1 = rows.CopyToDataTable();
                else
                    _datatable1 = _datatable1.Clone();
            }
            chkExamCodeList.DataValueField = "ExamCodeId";
            chkExamCodeList.DataTextField = "FullName";
            chkExamCodeList.DataSource = _datatable1;
            chkExamCodeList.DataBind();
            if (setcurrentitem != null)
            {
                for (int i = 0; i < chkExamCodeList.Items.Count; i++)
                {
                    chkExamCodeList.Items[i].Selected = false;
                    for (int x = 0; x < setcurrentitem.Count; x++)
                    {
                        if (chkExamCodeList.Items[i].Value == setcurrentitem[x])
                        {
                            chkExamCodeList.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        private void FillchkboxListAccessOption()
        {
            BOUserAccess _bousraccess = new BOUserAccess();
            BAUserAccess _bausraccess = new BAUserAccess();
            DataTable _datatable1 = new DataTable();
            _datatable1 = _bausraccess.SelectUserAccess("GETALL");
            foreach (DataRow row in _datatable1.Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["AccessOption"].ToString();
                item.Value = row["AccessOptionId"].ToString();
                chklistAccessoption.Items.Add(item);
            }
        }

        private void FillgridViewUserGroupList(int mid)
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bausergrp.SelectGroupDetail("GetGroupWithMId", mid);
            gvGroup.DataSource = _datatable2;
            gvGroup.DataBind();
        }

        private void FillTopddlCategory()
        {
            BATopCategory batcat = new BATopCategory();
            DataTable _datatable3 = new DataTable();
            _datatable3 = batcat.SelectTopCategoryList("GETALL");
            ddlTopCategory.DataTextField = "TopCategoryName";
            ddlTopCategory.DataValueField = "TopCategoryID";
            ddlTopCategory.DataSource = _datatable3;
            ddlTopCategory.DataBind();
            FillSecondddlCategory(ddlTopCategory.SelectedItem.Value);
        }

        private void FillSecondddlCategory(string value)
        {
            BASecondCategory bascat = new BASecondCategory();
            DataTable _datatable3 = new DataTable();
            _datatable3 = bascat.SelectSecondCategoryList("GetWithTopCatId", value);
            ddlSecondCategory.DataTextField = "SecondCategoryName";
            ddlSecondCategory.DataValueField = "SecondCategoryId";
            ddlSecondCategory.DataSource = _datatable3;
            ddlSecondCategory.DataBind();
            FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _bousergrp.GroupName = txtGroupName.Text;
                    _bousergrp.MerchantId = MerchantId;
                    _bousergrp.ExamId = chklist();
                    _bousergrp.AccessOption = accessoption();
                    _bousergrp.IsActive = true;
                    _bousergrp.IsDelete = false;
                    _bousergrp.Createdby = MerchantId;
                    _bousergrp.CreatedDate = DateTime.UtcNow;
                    _bousergrp.UpdatedBy = MerchantId;
                    _bousergrp.UpdatedDate = DateTime.UtcNow;
                    if (ViewState["groupId"] != null && !ViewState["groupId"].Equals(""))
                    {
                        _bousergrp.GroupId = Convert.ToInt32(ViewState["groupId"]);
                        _bousergrp.Event = "Update";
                        if (_bausergrp.Update(_bousergrp) == 2)
                        {
                            ShowMessage("Group updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _bousergrp.GroupId = 0;
                        _bousergrp.Event = "Insert";
                        int result = _bausergrp.Insert(_bousergrp);
                        if (result == 1)
                        {
                            ShowMessage("Group added successfully", MessageType.Success);
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

        private string chklist()
        {
            string exmcodeid = string.Empty;
            foreach (ListItem item in chkExamCodeList.Items)
            {
                if (item.Selected)
                {
                    if (exmcodeid != "" && exmcodeid != null)
                    {
                        exmcodeid += "," + item.Value;
                    }
                    else
                    {
                        exmcodeid += item.Value;
                    }
                }
            }
            return exmcodeid;
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
                        str += "," + item.Value;
                    }
                    else
                    {
                        str += item.Value;
                    }
                }
            }
            return str;
        }

        private void ClearControl()
        {
            Common.ClearControl(pnlusergroup);
            btnAdd.Text = "Add";
            ViewState["groupId"] = "";
            ViewState["groupId"] = null;
            FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
            FillgridViewUserGroupList(MerchantId);
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
                int userId = Convert.ToInt32(gvGroup.DataKeys[gvrow.RowIndex].Value.ToString());
                DataTable _datatable4 = new DataTable();
                _datatable4 = _bausergrp.SelectGroupDetailWithGroupID("GetGroupWithGId", userId);
                if (_datatable4.Rows.Count > 0)
                {
                    ViewState["groupId"] = _datatable4.Rows[0]["GroupId"].ToString();
                    txtGroupName.Text = _datatable4.Rows[0]["GroupName"].ToString();
                    setcurrentitem = _datatable4.Rows[0]["ExamId"].ToString().Split(',').ToList();
                    for (int i = 0; i < chkExamCodeList.Items.Count; i++)
                    {
                        chkExamCodeList.Items[i].Selected = false;
                        for (int x = 0; x < setcurrentitem.Count; x++)
                        {
                            if (chkExamCodeList.Items[i].Value == setcurrentitem[x])
                            {
                                chkExamCodeList.Items[i].Selected = true;
                            }
                        }
                    }
                    string[] accessoption = _datatable4.Rows[0]["AccessOption"].ToString().Split(',');
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
                    int userId = Convert.ToInt32(gvGroup.DataKeys[gvrow.RowIndex].Value.ToString());
                    _bousergrp.GroupId = userId;
                    _bousergrp.IsDelete = true;
                    _bousergrp.Createdby = MerchantId;
                    _bousergrp.CreatedDate = DateTime.UtcNow;
                    _bousergrp.UpdatedBy = MerchantId;
                    _bousergrp.UpdatedDate = DateTime.UtcNow;
                    _bousergrp.Event = "Delete";
                    int rtnvalue = _bausergrp.Delete(_bousergrp);
                    if (rtnvalue == 3)
                    {
                        ShowMessage("Group deleted successfully", MessageType.Success);
                    }
                    else if (rtnvalue == 5)
                    {
                        ShowMessage("Can not delete Group because used in another entity", MessageType.Info);
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

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }

        protected void gvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGroup.PageIndex = e.NewPageIndex;
            FillgridViewUserGroupList(MerchantId);
        }

        protected void ddlTopCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillSecondddlCategory(ddlTopCategory.SelectedValue);
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void ddlSecondCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
        }
    }
}