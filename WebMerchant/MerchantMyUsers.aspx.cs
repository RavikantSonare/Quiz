﻿using System;
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
        static List<ListItem> selectedGroup, unselectedGroup;
        private List<string> setcurrentitemGroup
        {
            get
            {
                if (ViewState["setcurrentitemGroup"] == null)
                    return null;
                return (List<string>)ViewState["setcurrentitemGroup"];
            }
            set
            {
                ViewState["setcurrentitemGroup"] = value;
            }
        }
        //  private int merchantId = default(int);

            //For add new user
        private DataView dvlistitem;
        private DataTable dtlistitem = new DataTable();

        //for add user group
        private DataView dvlistitemgrp;
        private DataTable dtlistitemgrp = new DataTable();

        DataTable _dtextrapermission = new DataTable();

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
                        Tab_1.CssClass = "Clicked";
                        MainView.ActiveViewIndex = 0;
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillddlUserGroup(MerchantId);
                        FillddlTopCategoryUser(FillddlTopCategory());
                        if (ddlSecondCategory.Items.Count != 0)
                        {
                            FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
                        }
                        GetExtraPermission(_bomerchantDetail.MerchantLevelId);
                        _dtextrapermission = (DataTable)ViewState["extrapermission"];
                        FillchkboxListAccessOptionUser(_dtextrapermission);
                        FillgridViewUserList(MerchantId);
                        FillgridViewUserGroupList(MerchantId);
                    }
                    if (ViewState["dtlistitem"] == null)
                    {
                        dtlistitem.Columns.Add(new DataColumn("Item"));
                        dtlistitem.Columns.Add(new DataColumn("Id"));
                        ViewState["dtlistitem"] = dtlistitem;
                        dvlistitem = new DataView(dtlistitem);
                    }
                    if (ViewState["dtlistitemgrp"] == null)
                    {
                        dtlistitemgrp.Columns.Add(new DataColumn("Item"));
                        dtlistitemgrp.Columns.Add(new DataColumn("Id"));
                        ViewState["dtlistitemgrp"] = dtlistitemgrp;
                        dvlistitemgrp = new DataView(dtlistitemgrp);
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

        private void GetExtraPermission(int levelid)
        {
            DataTable _datatable = new DataTable();
            BAQuestionType _baqtype = new BALayer.BAQuestionType();
            DataSet _dataset = new System.Data.DataSet();
            if (ViewState["extrapermission"] != null && !ViewState["extrapermission"].Equals(""))
            {
                _datatable = (DataTable)ViewState["dtAcsOpt"];
            }
            else
            {
                _dataset = _baqtype.SelectQuestionTypeList("GetQTypeWithMLevel", levelid);
                _datatable = _dataset.Tables[1];
                ViewState["extrapermission"] = _datatable;
            }
        }

        private void FillchkboxListExam(int catid, int mid)
        {
            selected = chkExamCodeList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            unselected = chkExamCodeList.Items.Cast<ListItem>().Where(li => !li.Selected).ToList();
            if (selected.Count > 0)
            {
                if (setcurrentitem != null)
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

        //private DataTable FillchkboxListAccessOption()
        //{
        //    BAUserAccess _bausraccess = new BAUserAccess();
        //    DataTable _datatable1 = new DataTable();
        //    if (ViewState["dtAcsOpt"] != null)
        //    {
        //        _datatable1 = (DataTable)ViewState["dtAcsOpt"];
        //    }
        //    else
        //    {
        //        _datatable1 = _bausraccess.SelectUserAccess("GETALL");
        //        ViewState["dtAcsOpt"] = _datatable1;
        //    }
        //    return _datatable1;
        //}

        private void FillchkboxListAccessOptionUser(DataTable _table)
        {
            DataRow[] rows = _table.Select(
        "ExtraPermissionOptId IN (2,3,4)", "",
System.Data.DataViewRowState.CurrentRows);
            foreach (DataRow row in rows)
            {
                ListItem item = new ListItem();
                item.Text = row["ExtraPermissionOpt"].ToString();
                item.Value = row["ExtraPermissionOptId"].ToString();
                chklistAccessoption.Items.Add(item);
            }


            //foreach (DataRow row in _table.Rows)
            //{
            //    ListItem item = new ListItem();
            //    item.Text = row["AccessOption"].ToString();
            //    item.Value = row["AccessOptionId"].ToString();
            //    chklistAccessoption.Items.Add(item);
            //}
        }

        private DataTable FillddlTopCategory()
        {
            BATopCategory batcat = new BATopCategory();
            DataTable _datatable3 = new DataTable();
            if (ViewState["dtTopCat"] != null && !ViewState["dtTopCat"].Equals(""))
            {
                _datatable3 = (DataTable)ViewState["dtTopCat"];
            }
            else
            {
                _datatable3 = batcat.SelectTopCategoryList("GETALL");
                ViewState["dtTopCat"] = _datatable3;
            }
            return _datatable3;
        }

        private void FillddlTopCategoryUser(DataTable _table)
        {
            ddlTopCategory.DataTextField = "TopCategoryName";
            ddlTopCategory.DataValueField = "TopCategoryID";
            ddlTopCategory.DataSource = _table;
            ddlTopCategory.DataBind();
            if (ddlTopCategory.Items.Count != 0)
            {
                FillddlSecondCategoryUser(FillddlSecondCategory(ddlTopCategory.SelectedItem.Value));
            }
        }

        private DataTable FillddlSecondCategory(string value)
        {
            BASecondCategory bascat = new BASecondCategory();
            DataTable _datatable3 = new DataTable();
            _datatable3 = bascat.SelectSecondCategoryList("GetWithTopCatId", value);
            return _datatable3;
        }

        private void FillddlSecondCategoryUser(DataTable _table)
        {
            ddlSecondCategory.DataTextField = "SecondCategoryName";
            ddlSecondCategory.DataValueField = "SecondCategoryId";
            ddlSecondCategory.DataSource = _table;
            ddlSecondCategory.DataBind();
            if (ddlSecondCategory.Items.Count != 0)
            {
                FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
            }
        }

        private void FillddlUserGroup(int mid)
        {
            BAUserGroup _bausergrp = new BAUserGroup();
            DataTable _datatable3 = new DataTable();
            _datatable3 = _bausergrp.SelectGroupDetail("GetGroupWithMId", mid);
            ddlStudnetGroup.DataTextField = "GroupName";
            ddlStudnetGroup.DataValueField = "GroupId";
            ddlStudnetGroup.DataSource = _datatable3;
            ddlStudnetGroup.DataBind();
            ddlStudnetGroup.Items.Insert(0, new ListItem("None", "0"));
            ddlStudnetGroup.SelectedIndex = 0;
            pnlgroupsection.Visible = true;
        }

        private void FillgridViewUserList(int mid)
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bamyuser.SelectUserDetail("GetUserWithMId", mid);
            gvMyUser.DataSource = _datatable2;
            gvMyUser.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _bomyuser.UserName = txtRealName.Text;
                    _bomyuser.AccessPassword = Encryptdata(txtPassword.Text);
                    _bomyuser.EmailId = txtEmailAddress.Text;
                    _bomyuser.MerchantId = MerchantId;
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
                    _bomyuser.GroupId = Convert.ToInt32(ddlStudnetGroup.SelectedItem.Value);
                    _bomyuser.SecondCategoryId = Convert.ToInt32(ddlSecondCategory.SelectedItem.Value);
                    if (!ddlStudnetGroup.SelectedItem.Value.Equals("0"))
                    {
                        _bomyuser.GroupStatus = true;
                        _bomyuser.AccessOption = "";
                    }
                    else { _bomyuser.GroupStatus = false; }

                    if (ViewState["userId"] != null && !ViewState["userId"].Equals(""))
                    {
                        _bomyuser.UserId = Convert.ToInt32(ViewState["userId"]);
                        _bomyuser.Event = "Update";
                        int retval = _bamyuser.Update(_bomyuser);
                        if (retval == 2)
                        {
                            txtEmailAddress.Enabled = true;
                            AssignExamUser(Convert.ToInt32(ViewState["userId"]), Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), _bomyuser.Event);
                            ShowMessage("User updated successfully", MessageType.Success);
                        }
                        else if (retval == -11)
                        {
                            ShowMessage("Please make the unique password", MessageType.Info);
                        }
                    }
                    else
                    {
                        _bomyuser.UserId = 0;
                        _bomyuser.Event = "Insert";
                        int retval = _bamyuser.Insert(_bomyuser);
                        if (retval > 0)
                        {
                            AssignExamUser(retval, Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), _bomyuser.Event);
                            ShowMessage("User added successfully", MessageType.Success);
                        }
                        else if (retval == -1)
                        {
                            ShowMessage("Email Id already exist", MessageType.Info);
                        }
                        else if (retval == -11)
                        {
                            ShowMessage("Please make the unique password", MessageType.Info);
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

        private void AssignExamUser(int UserId, int SecondCatId, string parentEvent)
        {
            BOAssignExamUser _boaeu = new BOAssignExamUser();
            BAAssignExamUser _baaeu = new BAAssignExamUser();
            foreach (ListItem item in chkcheckdECL.Items)
            {
                //if (item.Selected)
                //{
                    _boaeu.UserId = UserId;
                    _boaeu.ExamId = Convert.ToInt32(item.Value);
                    _boaeu.SecondCatId = SecondCatId;
                    if (chklistAccessoption.Items.FindByValue("2").Selected)
                        _boaeu.OnlineTest = true;
                    else
                        _boaeu.OnlineTest = false;
                    if (chklistAccessoption.Items.FindByValue("3").Selected)
                        _boaeu.OfflineSimulator = true;
                    else
                        _boaeu.OfflineSimulator = false;
                    if (chklistAccessoption.Items.FindByValue("4").Selected)
                        _boaeu.TestOnce = true;
                    else
                        _boaeu.TestOnce = false;
                    _boaeu.IsActive = true;
                    _boaeu.IsDelete = false;
                    _boaeu.CreatedBy = MerchantId;
                    _boaeu.CreatedDate = DateTime.UtcNow;
                    _boaeu.UpdatedBy = MerchantId;
                    _boaeu.UpdatedDate = DateTime.UtcNow;
                    _boaeu.Event = parentEvent;
                    _baaeu.Insert(_boaeu);
               // }
            }
        }

        private Tuple<string, string> chklist()
        {
            string exmcode = string.Empty;
            string exmcodeid = string.Empty;
            foreach (ListItem item in chkcheckdECL.Items)
            {
                //if (item.Selected)
                //{
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
                //}
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
            Common.ClearControl(pnlMyuser);
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            ViewState["userId"] = "";
            ViewState["userId"] = null;
            FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
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
                    txtRealName.Text = _datatable4.Rows[0]["UserName"].ToString();
                    txtPassword.Text = Decryptdata(_datatable4.Rows[0]["AccessPassword"].ToString());
                    txtEmailAddress.Text = _datatable4.Rows[0]["EmailId"].ToString();
                    txtEmailAddress.Enabled = false;
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
                    DateTime dateform = Convert.ToDateTime(_datatable4.Rows[0]["ValidTime"]);
                    txtValidTime.Text = dateform.ToString("yyyy-MM-ddTHH:mm");
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
                    DateTime dateto = Convert.ToDateTime(_datatable4.Rows[0]["ValidTimeTo"]);
                    txtValidTimeto.Text = dateto.ToString("yyyy-MM-ddTHH:mm");
                    ddlStudnetGroup.SelectedValue = _datatable4.Rows[0]["GroupId"].ToString();
                    if (_datatable4.Rows[0]["GroupStatus"].Equals(true))
                    {
                        pnlgroupsection.Visible = false;
                    }
                    else { pnlgroupsection.Visible = true; }
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

        protected void ddlTopCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillddlSecondCategoryUser(FillddlSecondCategory(ddlTopCategory.SelectedValue));
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void ddlSecondCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSecondCategory.Items.Count != 0)
            {
                FillchkboxListExam(Convert.ToInt32(ddlSecondCategory.SelectedItem.Value), MerchantId);
            }
        }

        protected void ddlStudnetGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStudnetGroup.SelectedItem.Value != "0")
            {
                pnlgroupsection.Visible = false;
            }
            else { pnlgroupsection.Visible = true; }
        }

        private void FillgridViewUserGroupList(int mid)
        {
            DataTable _datatable2 = new DataTable();
            _datatable2 = _bausergrp.SelectGroupDetail("GetGroupWithMId", mid);
            gvGroup.DataSource = _datatable2;
            gvGroup.DataBind();
        }

        private void FillddlTopCategoryGroup(DataTable _table)
        {
            ddlTopCategoryGruop.DataTextField = "TopCategoryName";
            ddlTopCategoryGruop.DataValueField = "TopCategoryID";
            ddlTopCategoryGruop.DataSource = _table;
            ddlTopCategoryGruop.DataBind();
            if (ddlTopCategoryGruop.Items.Count != 0)
            {
                FillddlSecondCategoryGroup(FillddlSecondCategory(ddlTopCategoryGruop.SelectedItem.Value));
            }
        }

        private void FillddlSecondCategoryGroup(DataTable _table)
        {
            ddlSecondCategoryGroup.DataTextField = "SecondCategoryName";
            ddlSecondCategoryGroup.DataValueField = "SecondCategoryId";
            ddlSecondCategoryGroup.DataSource = _table;
            ddlSecondCategoryGroup.DataBind();
            if (ddlSecondCategoryGroup.Items.Count != 0)
            {
                FillchkboxListExamgGroup(Convert.ToInt32(ddlSecondCategoryGroup.SelectedItem.Value), MerchantId);
            }
        }

        private void FillchkboxListAccessOptionGroup(DataTable _table)
        {
            chklistAccessoptionGroup.Items.Clear();

            DataRow[] rows = _table.Select("ExtraPermissionOptId IN (2,3,4)", "", System.Data.DataViewRowState.CurrentRows);
            foreach (DataRow row in rows)
            {
                ListItem item = new ListItem();
                item.Text = row["ExtraPermissionOpt"].ToString();
                item.Value = row["ExtraPermissionOptId"].ToString();
                chklistAccessoptionGroup.Items.Add(item);
            }


            //foreach (DataRow row in _table.Rows)
            //{
            //    ListItem item = new ListItem();
            //    item.Text = row["AccessOption"].ToString();
            //    item.Value = row["AccessOptionId"].ToString();
            //    chklistAccessoptionGroup.Items.Add(item);
            //}
        }

        private void FillchkboxListExamgGroup(int catid, int mid)
        {
            selectedGroup = chkExamCodeListGroup.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            unselectedGroup = chkExamCodeListGroup.Items.Cast<ListItem>().Where(li => !li.Selected).ToList();
            if (selectedGroup.Count > 0)
            {
                if (setcurrentitemGroup != null)
                {
                    foreach (ListItem listItem in selectedGroup)
                    {
                        if (!setcurrentitemGroup.Contains(listItem.Value))
                        {
                            setcurrentitemGroup.Add(listItem.Value);
                        }
                    }
                    foreach (ListItem listItem in unselectedGroup)
                    {
                        if (setcurrentitemGroup.Contains(listItem.Value))
                        {
                            setcurrentitemGroup.Remove(listItem.Value);
                        }
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
            chkExamCodeListGroup.DataValueField = "ExamCodeId";
            chkExamCodeListGroup.DataTextField = "FullName";
            chkExamCodeListGroup.DataSource = _datatable1;
            chkExamCodeListGroup.DataBind();
            if (setcurrentitemGroup != null)
            {
                for (int i = 0; i < chkExamCodeListGroup.Items.Count; i++)
                {
                    chkExamCodeListGroup.Items[i].Selected = false;
                    for (int x = 0; x < setcurrentitemGroup.Count; x++)
                    {
                        if (chkExamCodeListGroup.Items[i].Value == setcurrentitemGroup[x])
                        {
                            chkExamCodeListGroup.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected void gvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGroup.PageIndex = e.NewPageIndex;
            FillgridViewUserGroupList(MerchantId);
        }

        protected void ddlTopCategoryGruop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTopCategoryGruop.Items.Count != 0)
                {
                    FillddlSecondCategoryGroup(FillddlSecondCategory(ddlTopCategoryGruop.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void ddlSecondCategoryGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSecondCategoryGroup.Items.Count != 0)
            {
                FillchkboxListExamgGroup(Convert.ToInt32(ddlSecondCategoryGroup.SelectedItem.Value), MerchantId);
            }
        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    _bousergrp.GroupName = txtGroupName.Text;
                    _bousergrp.MerchantId = MerchantId;
                    _bousergrp.ExamId = chklistGroup();
                    _bousergrp.AccessOption = accessoptionGroup();
                    _bousergrp.IsActive = true;
                    _bousergrp.IsDelete = false;
                    _bousergrp.Createdby = MerchantId;
                    _bousergrp.CreatedDate = DateTime.UtcNow;
                    _bousergrp.UpdatedBy = MerchantId;
                    _bousergrp.UpdatedDate = DateTime.UtcNow;
                    _bousergrp.SecondCategoryId = Convert.ToInt32(ddlSecondCategoryGroup.SelectedItem.Value);
                    if (ViewState["groupId"] != null && !ViewState["groupId"].Equals(""))
                    {
                        _bousergrp.GroupId = Convert.ToInt32(ViewState["groupId"]);
                        _bousergrp.Event = "Update";
                        if (_bausergrp.Update(_bousergrp) == 2)
                        {
                            AssignExamUserGroup(Convert.ToInt32(ViewState["groupId"]), Convert.ToInt32(ddlSecondCategoryGroup.SelectedItem.Value), _bousergrp.Event);
                            ShowMessage("Group updated successfully", MessageType.Success);
                        }
                    }
                    else
                    {
                        _bousergrp.GroupId = 0;
                        _bousergrp.Event = "Insert";
                        int result = _bausergrp.Insert(_bousergrp);
                        if (result > 0)
                        {
                            AssignExamUserGroup(result, Convert.ToInt32(ddlSecondCategoryGroup.SelectedItem.Value), _bousergrp.Event);
                            ShowMessage("Group added successfully", MessageType.Success);
                        }
                        else if (result == -1)
                        {
                            ShowMessage("Group already exist", MessageType.Info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            ClearControlGroup();
        }

        protected void btnResetGroup_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlGroup();
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        private void ClearControlGroup()
        {
            Common.ClearControl(pnlusergroup);
            lnkbtnAddGroup.Text = "Add";
            lnkbtnAddGroup.OnClientClick = "";
            ViewState["groupId"] = "";
            ViewState["groupId"] = null;
            FillchkboxListExamgGroup(Convert.ToInt32(ddlSecondCategoryGroup.SelectedItem.Value), MerchantId);
            FillgridViewUserGroupList(MerchantId);
        }

        private void AssignExamUserGroup(int UserGroupId, int SecondCatId, string parentEvent)
        {
            BOAssignExamUserGroup _boaeug = new BOAssignExamUserGroup();
            BAAssignExamUserGroup _baaeug = new BAAssignExamUserGroup();
            foreach (ListItem item in chkcheckdECLgrp.Items)
            {
                //if (item.Selected)
                //{
                    _boaeug.UserGroupId = UserGroupId;
                    _boaeug.ExamId = Convert.ToInt32(item.Value);
                    _boaeug.SecondCatId = SecondCatId;
                    if (chklistAccessoptionGroup.Items.FindByValue("2").Selected)
                        _boaeug.OnlineTest = true;
                    else
                        _boaeug.OnlineTest = false;
                    if (chklistAccessoptionGroup.Items.FindByValue("3").Selected)
                        _boaeug.OfflineSimulator = true;
                    else
                        _boaeug.OfflineSimulator = false;
                    if (chklistAccessoptionGroup.Items.FindByValue("4").Selected)
                        _boaeug.TestOnce = true;
                    else
                        _boaeug.TestOnce = false;
                    _boaeug.IsActive = true;
                    _boaeug.IsDelete = false;
                    _boaeug.CreatedBy = MerchantId;
                    _boaeug.CreatedDate = DateTime.UtcNow;
                    _boaeug.UpdatedBy = MerchantId;
                    _boaeug.UpdatedDate = DateTime.UtcNow;
                    _boaeug.Event = parentEvent;
                    _baaeug.Insert(_boaeug);
               // }
            }
        }

        private string chklistGroup()
        {
            string exmcodeid = string.Empty;
            foreach (ListItem item in chkcheckdECLgrp.Items)
            {
                //if (item.Selected)
                //{
                    if (exmcodeid != "" && exmcodeid != null)
                    {
                        exmcodeid += "," + item.Value;
                    }
                    else
                    {
                        exmcodeid += item.Value;
                    }
                //}
            }
            return exmcodeid;
        }

        private string accessoptionGroup()
        {
            string str = default(string);
            foreach (ListItem item in chklistAccessoptionGroup.Items)
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

        protected void lnkbtnEditGroup_Click(object sender, EventArgs e)
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
                    setcurrentitemGroup = _datatable4.Rows[0]["ExamId"].ToString().Split(',').ToList();
                    for (int i = 0; i < chkExamCodeListGroup.Items.Count; i++)
                    {
                        chkExamCodeListGroup.Items[i].Selected = false;
                        for (int x = 0; x < setcurrentitemGroup.Count; x++)
                        {
                            if (chkExamCodeListGroup.Items[i].Value == setcurrentitemGroup[x])
                            {
                                chkExamCodeListGroup.Items[i].Selected = true;
                            }
                        }
                    }
                    string[] accessoption = _datatable4.Rows[0]["AccessOption"].ToString().Split(',');
                    for (int i = 0; i < chklistAccessoptionGroup.Items.Count; i++)
                    {
                        chklistAccessoptionGroup.Items[i].Selected = false;
                        for (int x = 0; x < accessoption.Length; x++)
                        {
                            if (chklistAccessoptionGroup.Items[i].Value == accessoption[x])
                            {
                                chklistAccessoptionGroup.Items[i].Selected = true;
                            }
                        }
                    }
                    lnkbtnAddGroup.Text = "Update";
                    lnkbtnAddGroup.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lnkbtnDeleteGroup_Click(object sender, EventArgs e)
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
            ClearControlGroup();
        }

        protected void chkExamCodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //alwaysselectitem = chkExamCodeList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            foreach (ListItem item in chkExamCodeList.Items)
            {
                if (item.Selected)
                {
                    dtlistitem = (DataTable)ViewState["dtlistitem"];
                    bool contains = dtlistitem.AsEnumerable().Any(row => item.Value == row.Field<String>("Id"));
                    if (dtlistitem != null && contains==false)
                    {
                        DataRow dr = dtlistitem.NewRow();
                        dr["Item"] = item.Text;
                        dr["Id"] = item.Value;
                        dtlistitem.Rows.Add(dr);
                        dvlistitem = new DataView(dtlistitem);
                    }
                    chkcheckdECL.DataValueField = "Id";
                    chkcheckdECL.DataTextField = "Item";
                    chkcheckdECL.DataSource = (DataTable)ViewState["dtlistitem"];
                    chkcheckdECL.DataBind();
                }
            }
        }

        protected void chkExamCodeListGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in chkExamCodeListGroup.Items)
            {
                if (item.Selected)
                {
                    dtlistitemgrp = (DataTable)ViewState["dtlistitemgrp"];
                    bool contains = dtlistitemgrp.AsEnumerable().Any(row => item.Value == row.Field<String>("Id"));
                    if (dtlistitemgrp != null && contains == false)
                    {
                        DataRow dr = dtlistitemgrp.NewRow();
                        dr["Item"] = item.Text;
                        dr["Id"] = item.Value;
                        dtlistitemgrp.Rows.Add(dr);
                        dvlistitemgrp = new DataView(dtlistitemgrp);
                    }
                    chkcheckdECLgrp.DataValueField = "Id";
                    chkcheckdECLgrp.DataTextField = "Item";
                    chkcheckdECLgrp.DataSource = (DataTable)ViewState["dtlistitemgrp"];
                    chkcheckdECLgrp.DataBind();
                }
            }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab_1.CssClass = "Clicked";
            Tab_2.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab_1.CssClass = "Initial";
            Tab_2.CssClass = "Clicked";
            MainView.ActiveViewIndex = 1;
            FillddlTopCategoryGroup(FillddlTopCategory());
            _dtextrapermission = (DataTable)ViewState["extrapermission"];
            FillchkboxListAccessOptionGroup(_dtextrapermission);
        }
    }
}