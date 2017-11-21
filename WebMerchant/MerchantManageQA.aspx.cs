﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Hosting;
using System.Text.RegularExpressions;
using WebMerchant.BOLayer;
using WebMerchant.BALayer;
using System.Data.OleDb;
using System.Data.SqlClient;
//using Microsoft.Office.Interop.Word;
using Code7248.word_reader;
namespace WebMerchant
{
    public partial class MerchantManageQA : System.Web.UI.Page
    {
        private int MerchantId = default(int);
        private BOQAManage _boqamng = new BOQAManage();
        private BAQAManage _baqamng = new BAQAManage();
        private List<BOQAManage> _boqamnglist = new List<BOQAManage>();
        BAQAnswer _baqans = new BAQAnswer();
        BOQAnswer _boqans = new BOLayer.BOQAnswer();
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keysQ = Request.Form.AllKeys.Where(key => key.Contains("tb")).ToList();
            if (keysQ.Count > 0)
            {
                string plchldrname = string.Empty;
                if (Session["Qtypevalue"].ToString() == "1")
                { plchldrname = "ctrlPlaceholderTextBox"; }
                else if (Session["Qtypevalue"].ToString() == "2")
                { plchldrname = "ctrlPlaceholderMulti"; }
                else if (Session["Qtypevalue"].ToString() == "3")
                { plchldrname = "ctrlPlaceholderVacant"; }
                else if (Session["Qtypevalue"].ToString() == "4")
                { plchldrname = "ctrlPlaceholderDragdrop"; }
                else if (Session["Qtypevalue"].ToString() == "6")
                { plchldrname = "ctrlPlaceholderScenario"; }
                foreach (string key in keysQ)
                {
                    int txtId = Convert.ToInt16(key.Substring(28));
                    this.CreateTextBoxQ(txtId, Convert.ToInt32(Session["Qtypevalue"]), plchldrname);
                    txtId++;
                }
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
                    if (!Page.IsPostBack)
                    {
                        ctrlPlaceholderTextBox.Controls.Clear();
                        ctrlPlaceholderMulti.Controls.Clear();
                        ctrlPlaceholderVacant.Controls.Clear();
                        ctrlPlaceholderDragdrop.Controls.Clear();
                        ctrlPlaceholderScenario.Controls.Clear();
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillddlExamCode(MerchantId);
                        FillrbtnListQuestiontype(_bomerchantDetail.MerchantLevelId);
                        FillgridViewQAManage(MerchantId);
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

        private void FillddlExamCode(int mid)
        {
            BAExamManage _baexmmng = new BAExamManage();
            System.Data.DataTable _datatable1 = new System.Data.DataTable();
            _datatable1 = _baexmmng.SelectExamDetail("GetExamWithMId", mid);
            if (_datatable1.Rows.Count > 0)
            {
                ddlExamCode.DataValueField = "ExamCodeId";
                ddlExamCode.DataTextField = "ExamCode";
                ddlExamCode.DataSource = _datatable1;
                ddlExamCode.DataBind();
            }
        }

        private void FillrbtnListQuestiontype(int levelid)
        {
            BAQuestionType _baqtype = new BALayer.BAQuestionType();
            System.Data.DataTable _datatable2 = new System.Data.DataTable();
            _datatable2 = _baqtype.SelectQuestionTypeList("GetQTypeWithMLevel", levelid);
            if (_datatable2.Rows.Count > 0)
            {
                ddlQuestionType.DataValueField = "QuestionTypeId";
                ddlQuestionType.DataTextField = "QuestionType";
                ddlQuestionType.DataSource = _datatable2;
                ddlQuestionType.DataBind();
                ddlQuestionType.Items.Insert(0, "Select");
            }
        }

        private void FillgridViewQAManage(int mid)
        {
            System.Data.DataTable _datatable3 = new System.Data.DataTable();
            //_datatable3 = _baqamng.SelectQAmanageList("GetQAWMId", mid);
            _datatable3 = _baqamng.SelectQAmanageListWithSearch("GetQAWMId", txtSearch.Text, MerchantId);
            gvQuestionManage.DataSource = _datatable3;
            gvQuestionManage.DataBind();
        }

        protected void gvQuestionManage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvQuestionManage.PageIndex = e.NewPageIndex;
            FillgridViewQAManage(MerchantId);
        }

        protected void ddlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Qtypevalue"] = ddlQuestionType.SelectedItem.Value;
            if (ddlQuestionType.SelectedIndex == 0)
            {
                pnlSingleSelect.Visible = false;
                pnlMultiSelect.Visible = false;
                pnlVacant.Visible = false;
                pnlDragdrop.Visible = false;
                pnlHotspot.Visible = false;
                pnlScenario.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "1")
            {
                ctrlPlaceholderTextBox.Controls.Clear();
                ctrlPlaceholderMulti.Controls.Clear();
                ctrlPlaceholderVacant.Controls.Clear();
                ctrlPlaceholderDragdrop.Controls.Clear();
                ctrlPlaceholderScenario.Controls.Clear();
                prevVaile.Value = Convert.ToString(2);
                for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox");
                }
                pnlSingleSelect.Visible = true;
                pnlMultiSelect.Visible = false;
                pnlVacant.Visible = false;
                pnlDragdrop.Visible = false;
                pnlHotspot.Visible = false;
                pnlScenario.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "2")
            {
                ctrlPlaceholderTextBox.Controls.Clear();
                ctrlPlaceholderMulti.Controls.Clear();
                ctrlPlaceholderVacant.Controls.Clear();
                ctrlPlaceholderDragdrop.Controls.Clear();
                ctrlPlaceholderScenario.Controls.Clear();
                prevVaile.Value = Convert.ToString(4);
                for (int loopcnt = 1; loopcnt <= 4; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderMulti");
                }
                pnlMultiSelect.Visible = true;
                pnlSingleSelect.Visible = false;
                pnlVacant.Visible = false;
                pnlDragdrop.Visible = false;
                pnlHotspot.Visible = false;
                pnlScenario.Visible = false;
            }

            else if (ddlQuestionType.SelectedItem.Value == "3")
            {
                ctrlPlaceholderTextBox.Controls.Clear();
                ctrlPlaceholderMulti.Controls.Clear();
                ctrlPlaceholderVacant.Controls.Clear();
                ctrlPlaceholderDragdrop.Controls.Clear();
                ctrlPlaceholderScenario.Controls.Clear();
                prevVaile.Value = Convert.ToString(2);
                for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderVacant");
                }
                pnlVacant.Visible = true;
                pnlMultiSelect.Visible = false;
                pnlSingleSelect.Visible = false;
                pnlDragdrop.Visible = false;
                pnlHotspot.Visible = false;
                pnlScenario.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "4")
            {
                ctrlPlaceholderTextBox.Controls.Clear();
                ctrlPlaceholderMulti.Controls.Clear();
                ctrlPlaceholderVacant.Controls.Clear();
                ctrlPlaceholderDragdrop.Controls.Clear();
                ctrlPlaceholderScenario.Controls.Clear();
                prevVaile.Value = Convert.ToString(4);
                for (int loopcnt = 1; loopcnt <= 4; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderDragdrop");
                }
                pnlDragdrop.Visible = true;
                pnlSingleSelect.Visible = false;
                pnlMultiSelect.Visible = false;
                pnlVacant.Visible = false;
                pnlHotspot.Visible = false;
                pnlScenario.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "5")
            {
                pnlHotspot.Visible = true;
                pnlSingleSelect.Visible = false;
                pnlMultiSelect.Visible = false;
                pnlVacant.Visible = false;
                pnlDragdrop.Visible = false;
                pnlScenario.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "6")
            {
                ctrlPlaceholderTextBox.Controls.Clear();
                ctrlPlaceholderMulti.Controls.Clear();
                ctrlPlaceholderVacant.Controls.Clear();
                ctrlPlaceholderDragdrop.Controls.Clear();
                ctrlPlaceholderScenario.Controls.Clear();
                prevVaile.Value = Convert.ToString(2);
                for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderScenario");
                }
                pnlScenario.Visible = true;
                pnlSingleSelect.Visible = false;
                pnlMultiSelect.Visible = false;
                pnlVacant.Visible = false;
                pnlDragdrop.Visible = false;
                pnlHotspot.Visible = false;
            }
        }

        private int AddQuestion(string noofanswer)
        {
            int revalue = default(int);
            try
            {
                _boqamng.ExamCodeId = Convert.ToInt32(ddlExamCode.SelectedItem.Value);
                _boqamng.ExamCode = ddlExamCode.SelectedItem.Text;
                _boqamng.QuestionTypeId = Convert.ToInt32(ddlQuestionType.SelectedItem.Value);
                _boqamng.Score = Convert.ToDecimal(txtScore.Text);
                _boqamng.Question = hftxtquestion.Value;
                _boqamng.NoofAnswer = Convert.ToInt32(noofanswer);
                _boqamng.Explanation = hftxtExplanation.Value;
                _boqamng.MerchantId = MerchantId;
                _boqamng.IsActive = true;
                _boqamng.IsDelete = false;
                _boqamng.CreatedBy = MerchantId;
                _boqamng.CreatedDate = DateTime.UtcNow;
                _boqamng.UpdatedBy = MerchantId;
                _boqamng.UpdatedDate = DateTime.UtcNow;
                _boqamng.Resource = txtimage.Text;
                _boqamng.Exhibit = FileUploadAppendTimeStamp(fuSingleExhibit, hfExhibit);
                _boqamng.Topology = FileUploadAppendTimeStamp(fuSingleTopology, hfTopology);
                _boqamng.Scenario = FileUploadAppendTimeStamp(fuSingleScenario, hfScenario);
                if (ViewState["QAId"] != null)
                {
                    _boqamng.QAId = Convert.ToInt32(ViewState["QAId"]);
                    _boqamng.Event = "Update";
                    revalue = _baqamng.Update(_boqamng);
                }
                else
                {
                    _boqamng.QAId = 0;
                    _boqamng.Event = "Insert";
                    revalue = _baqamng.Insert(_boqamng);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            return revalue;
        }

        public string FileUploadAppendTimeStamp(FileUpload fu, HiddenField hf)
        {
            string imagename = string.Empty;
            if (fu.HasFile)
            {
                imagename = string.Concat(
                Path.GetFileNameWithoutExtension(fu.PostedFile.FileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fu.PostedFile.FileName)
                );
                fu.PostedFile.SaveAs(Server.MapPath("~/resource/") + imagename);
            }
            else if (!string.IsNullOrEmpty(hf.Value))
            {
                imagename = hf.Value;
            }
            return imagename;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    int qusvalu = default(int);
                    qusvalu = AddQuestion(prevVaile.Value);
                    if (qusvalu == 2)
                    {
                        int[] array = (ViewState["arrAnswerID"]) as int[];
                        for (int loopcnt = 1; loopcnt <= array.Length; loopcnt++)
                        {
                            _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.AnswerId = array[loopcnt - 1];
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$Single"]) == loopcnt)
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Update";
                            if (_baqans.Update(_boqans) == 2)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question updated successfully", MessageType.Success);
                    }
                    else
                    {
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(prevVaile.Value.Trim()); loopcnt++)
                        {
                            _boqans.QuestionId = qusvalu;
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$Single"]) == loopcnt)
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Insert";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question added successfully", MessageType.Success);
                    }
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnMultiAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    int qusvalu = default(int);
                    qusvalu = AddQuestion(prevVaile.Value);
                    if (qusvalu == 2)
                    {
                        int[] arrayMulti = (ViewState["arrMultiAnswerID"]) as int[];
                        for (int loopcnt = 1; loopcnt <= arrayMulti.Length; loopcnt++)
                        {
                            _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.AnswerId = arrayMulti[loopcnt - 1];
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$" + loopcnt))
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Update";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question updated successfully", MessageType.Success);
                    }
                    else
                    {
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(prevVaile.Value.Trim()); loopcnt++)
                        {
                            _boqans.QuestionId = qusvalu;
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$" + loopcnt))
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Insert";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question added successfully", MessageType.Success);
                    }
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnVacantAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    int qusvalu = default(int);
                    qusvalu = AddQuestion(prevVaile.Value);
                    if (qusvalu == 2)
                    {
                        int[] array = (ViewState["arrVacantAnswerID"]) as int[];
                        for (int loopcnt = 1; loopcnt <= array.Length; loopcnt++)
                        {
                            _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.AnswerId = array[loopcnt - 1];
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$Single"]) == loopcnt)
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Update";
                            if (_baqans.Update(_boqans) == 2)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question updated successfully", MessageType.Success);
                    }
                    else
                    {
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(prevVaile.Value.Trim()); loopcnt++)
                        {
                            _boqans.QuestionId = qusvalu;
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$Single"]) == loopcnt)
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Insert";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question added successfully", MessageType.Success);
                    }
                    ClearControl();
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
        }

        protected void btnDragdropAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    int qusvalu = default(int);
                    qusvalu = AddQuestion(prevVaile.Value);
                    if (qusvalu == 2)
                    {
                        int[] arrayDragdrop = (ViewState["arrDragdropAnswerID"]) as int[];
                        for (int loopcnt = 1; loopcnt <= arrayDragdrop.Length; loopcnt++)
                        {
                            _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.AnswerId = arrayDragdrop[loopcnt - 1];
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$" + loopcnt))
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Update";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question updated successfully", MessageType.Success);
                    }
                    else
                    {
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(prevVaile.Value.Trim()); loopcnt++)
                        {
                            _boqans.QuestionId = qusvalu;
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$" + loopcnt))
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Insert";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question added successfully", MessageType.Success);
                    }
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnScenarioAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    int qusvalu = default(int);
                    qusvalu = AddQuestion(prevVaile.Value);
                    if (qusvalu == 2)
                    {
                        int[] array = (ViewState["arrScenarioAnswerID"]) as int[];
                        for (int loopcnt = 1; loopcnt <= array.Length; loopcnt++)
                        {
                            _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.AnswerId = array[loopcnt - 1];
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$Single"]) == loopcnt)
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Update";
                            if (_baqans.Update(_boqans) == 2)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question updated successfully", MessageType.Success);
                    }
                    else
                    {
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(prevVaile.Value.Trim()); loopcnt++)
                        {
                            _boqans.QuestionId = qusvalu;
                            if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$hf" + loopcnt))
                            {
                                _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$hf" + loopcnt].ToString();
                            }
                            if (Convert.ToInt32(Request.Params["ctl00$ContentPlaceHolder1$Single"]) == loopcnt)
                            {
                                _boqans.RightAnswer = true;
                            }
                            else
                            {
                                _boqans.RightAnswer = false;
                            }
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Insert";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                string success = "Success";
                            }
                        }
                        ShowMessage("Question added successfully", MessageType.Success);
                    }
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }

        }

        protected void btnHotspotAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    if (txtmaphtml.Text != "")
                    {
                        string[] AnswerArray = txtmaphtml.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        ImageUpload(txtimage.Text, hdimage.Value);
                        int qusvalu = default(int);
                        qusvalu = AddQuestion(AnswerArray.Length.ToString());
                        if (qusvalu == 2)
                        {
                            int[] array = (ViewState["arrVacantAnswerID"]) as int[];
                            for (int loopcnt = 1; loopcnt <= array.Length; loopcnt++)
                            {
                                _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                                if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                                {
                                    _boqans.AnswerId = array[loopcnt - 1];
                                    _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
                                }
                                //if (lboxVacantAnswer.SelectedIndex == loopcnt - 1)
                                //{
                                //    _boqans.RightAnswer = "1";
                                //}
                                //else
                                //{
                                //    _boqans.RightAnswer = "0";
                                //}
                                _boqans.IsActive = true;
                                _boqans.IsDelete = false;
                                _boqans.CreatedBy = MerchantId;
                                _boqans.CreatedDate = DateTime.UtcNow;
                                _boqans.UpdatedBy = MerchantId;
                                _boqans.UpdatedDate = DateTime.UtcNow;
                                _boqans.Event = "Update";
                                if (_baqans.Update(_boqans) == 2)
                                {
                                    string success = "Success";
                                }
                            }
                            ShowMessage("Question updated successfully", MessageType.Success);
                        }
                        else
                        {
                            for (int loopcnt = 1; loopcnt <= AnswerArray.Length; loopcnt++)
                            {
                                string value = Request.Params["radiobtnrect"];
                                _boqans.QuestionId = qusvalu;
                                _boqans.Answer = AnswerArray[loopcnt - 1];
                                if (value == AnswerArray[loopcnt - 1])
                                {
                                    _boqans.RightAnswer = true;
                                }
                                else
                                {
                                    _boqans.RightAnswer = false;
                                }
                                _boqans.IsActive = true;
                                _boqans.IsDelete = false;
                                _boqans.CreatedBy = MerchantId;
                                _boqans.CreatedDate = DateTime.UtcNow;
                                _boqans.UpdatedBy = MerchantId;
                                _boqans.UpdatedDate = DateTime.UtcNow;
                                _boqans.Event = "Insert";
                                if (_baqans.Insert(_boqans) == 1)
                                {
                                    string success = "Success";
                                }
                            }
                            ShowMessage("Question added successfully", MessageType.Success);
                        }
                        ClearControl();
                    }
                    else
                    {
                        ShowMessage("Please map on image and generate html", MessageType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        public string ImageUpload(string imagename, string value)
        {
            string filePath = string.Empty;
            filePath = HostingEnvironment.MapPath("~/resource/");
            var image = imagename;
            byte[] data;
            if (hdimage.Value == null || hdimage.Value.Length == 0 || hdimage.Value.Length % 4 != 0
|| hdimage.Value.Contains(" ") || hdimage.Value.Contains("\t") || hdimage.Value.Contains("\r") || hdimage.Value.Contains("\n"))
            {
                string valuebase = Regex.Replace(hdimage.Value, "data:image/(png|jpg|gif|jpeg|pjpeg|x-png);base64,", "");
                data = System.Convert.FromBase64String(valuebase);
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    data = client.DownloadData(hdimage.Value);
                }
            }
            using (FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                fs.Write(data, 0, data.Length);
                fs.Close();
            }
            return image;
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ctrlPlaceholderTextBox.Controls.Clear();
                ctrlPlaceholderMulti.Controls.Clear();
                ctrlPlaceholderVacant.Controls.Clear();
                ctrlPlaceholderDragdrop.Controls.Clear();
                ctrlPlaceholderScenario.Controls.Clear();
                btnAddAnswerSingle.Visible = false;
                btnAddAnswerMulti.Visible = false;
                btnAddAnswerVacant.Visible = false;
                btnAddAnswerDragDrop.Visible = false;
                btnAddAnswerScenario.Visible = false;
                LinkButton lnkbtn = sender as LinkButton;
                GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                int _QAId = Convert.ToInt32(gvQuestionManage.DataKeys[gvrow.RowIndex].Value.ToString());
                System.Data.DataTable _datatable4 = new System.Data.DataTable();
                _datatable4 = _baqamng.SelectQAmanagRecord("GetQAwithQId", _QAId);
                if (_datatable4.Rows.Count > 0)
                {
                    ViewState["QAId"] = _datatable4.Rows[0][0].ToString();
                    ddlExamCode.SelectedValue = _datatable4.Rows[0][1].ToString();
                    ddlQuestionType.SelectedValue = _datatable4.Rows[0][2].ToString();
                    Session["Qtypevalue"] = _datatable4.Rows[0][2].ToString();
                    ddlQuestionType.Enabled = false;
                    txtScore.Text = _datatable4.Rows[0][3].ToString();
                    hftxtquestion.Value = _datatable4.Rows[0][4].ToString();
                    hfExhibit.Value = _datatable4.Rows[0]["Exhibit"].ToString();
                    hfTopology.Value = _datatable4.Rows[0]["Topology"].ToString();
                    hfScenario.Value = _datatable4.Rows[0]["Scenario"].ToString();
                    if (_datatable4.Rows[0][2].ToString().Equals("1"))
                    {
                        pnlSingleSelect.Visible = true;
                        pnlMultiSelect.Visible = false;
                        pnlVacant.Visible = false;
                        pnlDragdrop.Visible = false;
                        pnlHotspot.Visible = false;
                        pnlScenario.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrAnswerID"] = arrAnswerID;
                        hftxtExplanation.Value = _datatable4.Rows[0][6].ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("2"))
                    {
                        pnlMultiSelect.Visible = true;
                        pnlSingleSelect.Visible = false;
                        pnlVacant.Visible = false;
                        pnlDragdrop.Visible = false;
                        pnlHotspot.Visible = false;
                        pnlScenario.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrMultiAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrMultiAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderMulti", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrMultiAnswerID"] = arrMultiAnswerID;
                        hftxtExplanation.Value = _datatable4.Rows[0][6].ToString();
                        btnMultiAdd.Text = "Update";
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("3"))
                    {
                        pnlVacant.Visible = true;
                        pnlSingleSelect.Visible = false;
                        pnlMultiSelect.Visible = false;
                        pnlDragdrop.Visible = false;
                        pnlHotspot.Visible = false;
                        pnlScenario.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrVacantAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrVacantAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderVacant", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrVacantAnswerID"] = arrVacantAnswerID;
                        hftxtExplanation.Value = _datatable4.Rows[0][6].ToString();
                        btnVacantAdd.Text = "Update";
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("4"))
                    {
                        pnlDragdrop.Visible = true;
                        pnlSingleSelect.Visible = false;
                        pnlMultiSelect.Visible = false;
                        pnlVacant.Visible = false;
                        pnlHotspot.Visible = false;
                        pnlScenario.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrDragdropAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrDragdropAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderDragdrop", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrDragdropAnswerID"] = arrDragdropAnswerID;
                        hftxtExplanation.Value = _datatable4.Rows[0][6].ToString();
                        btnDragdropAdd.Text = "Update";
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("5"))
                    {
                        pnlSingleSelect.Visible = false;
                        pnlMultiSelect.Visible = false;
                        pnlVacant.Visible = false;
                        pnlDragdrop.Visible = false;
                        pnlHotspot.Visible = false;
                        pnlScenario.Visible = false;
                        ShowMessage("Can not edit hotspot question", MessageType.Info);
                        //ftxtHotspotExplanation.Text = _datatable4.Rows[0][6].ToString();
                        //btnHotspotAdd.Text = "Update";
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("6"))
                    {
                        pnlScenario.Visible = true;
                        pnlSingleSelect.Visible = false;
                        pnlMultiSelect.Visible = false;
                        pnlVacant.Visible = false;
                        pnlDragdrop.Visible = false;
                        pnlHotspot.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrScenarioAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrScenarioAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderScenario", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrScenarioAnswerID"] = arrScenarioAnswerID;
                        hftxtExplanation.Value = _datatable4.Rows[0][6].ToString();
                        btnScenarioAdd.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    LinkButton lnkbtn = sender as LinkButton;
                    GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
                    int _QAId = Convert.ToInt32(gvQuestionManage.DataKeys[gvrow.RowIndex].Value.ToString());
                    _boqamng.QAId = _QAId;
                    _boqamng.IsDelete = true;
                    _boqamng.CreatedBy = MerchantId;
                    _boqamng.CreatedDate = DateTime.UtcNow;
                    _boqamng.UpdatedBy = MerchantId;
                    _boqamng.UpdatedDate = DateTime.UtcNow;
                    _boqamng.Event = "Delete";
                    if (_baqamng.Delete(_boqamng) == 3)
                    {
                        BOQAnswer _boqans = new BOLayer.BOQAnswer();
                        _boqans.QuestionId = _QAId;
                        _boqans.IsDelete = true;
                        _boqans.CreatedBy = MerchantId;
                        _boqans.CreatedDate = DateTime.UtcNow;
                        _boqans.UpdatedBy = MerchantId;
                        _boqans.UpdatedDate = DateTime.UtcNow;
                        _boqans.Event = "Delete";
                        BAQAnswer _baqans = new BAQAnswer();
                        if (_baqans.Insert(_boqans) == 1)
                        {
                            string success = "Success";
                        }
                        ShowMessage("Question deleted successfully", MessageType.Success);
                    }
                    ClearControl();
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
                Response.Redirect("MerchantManageQA.aspx", false);
                //ClearControl();
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
        }

        protected void btnAddAnswerSingle_Click(object sender, EventArgs e)
        {
            InitializeDynamicText(Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", ctrlPlaceholderTextBox);
        }

        protected void btnAddAnswerMulti_Click(object sender, EventArgs e)
        {
            InitializeDynamicText(Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderMulti", ctrlPlaceholderMulti);
        }

        protected void btnAddAnswerVacant_Click(object sender, EventArgs e)
        {
            InitializeDynamicText(Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderVacant", ctrlPlaceholderVacant);
        }

        protected void btnAddAnswerDragDrop_Click(object sender, EventArgs e)
        {
            InitializeDynamicText(Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderDragdrop", ctrlPlaceholderDragdrop);
        }

        protected void btnAddAnswerScenario_Click(object sender, EventArgs e)
        {
            InitializeDynamicText(Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderScenario", ctrlPlaceholderScenario);
        }

        private void InitializeDynamicText(int qtype, string plcholdname, PlaceHolder plcholer)
        {
            int index = plcholer.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBoxQ(index, qtype, plcholdname);
            prevVaile.Value = Convert.ToString(index);
        }

        private void CreateTextBoxQ(int loopcnt, int qtype, string placeholder)
        {
            ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            PlaceHolder ctrlPlaceholderTextBox = (PlaceHolder)cph.FindControl(placeholder);
            Label lblOpen = new Label();
            lblOpen.Text = "<div class='form-group'><label for= '' class='col-sm-3 control-label'>Option " + Convert.ToChar(64 + loopcnt);
            ctrlPlaceholderTextBox.Controls.Add(lblOpen);

            if (qtype == 1 || qtype == 3 || qtype == 6)
            {
                RadioButton rdbtn = new RadioButton();
                rdbtn.ID = loopcnt.ToString();
                rdbtn.CssClass = "";
                rdbtn.GroupName = "Single";
                rdbtn.EnableViewState = true;
                ctrlPlaceholderTextBox.Controls.Add(rdbtn);
            }
            else if (qtype == 2 || qtype == 4)
            {
                System.Web.UI.WebControls.CheckBox chkmulti = new System.Web.UI.WebControls.CheckBox();
                chkmulti.ID = loopcnt.ToString();
                chkmulti.CssClass = "";
                chkmulti.EnableViewState = true;
                ctrlPlaceholderTextBox.Controls.Add(chkmulti);
            }
            Label lblop = new Label();
            lblop.Text = "</label><div class='col-sm-8'>";
            ctrlPlaceholderTextBox.Controls.Add(lblop);

            TextBox tb = new TextBox();
            tb.ID = "tb" + loopcnt;
            tb.CssClass = "summernote form-control";
            tb.EnableViewState = true;
            ctrlPlaceholderTextBox.Controls.Add(tb);

            HiddenField hf = new HiddenField();
            hf.ID = "hf" + loopcnt;
            ctrlPlaceholderTextBox.Controls.Add(hf);

            Label lblClose = new Label();
            lblClose.Text = "</div><div class='col-sm-1'>";
            ctrlPlaceholderTextBox.Controls.Add(lblClose);

            //RequiredFieldValidator rfv = new RequiredFieldValidator();
            //rfv.ID = "rfv" + loopcnt;
            //rfv.ControlToValidate = "tb" + loopcnt;
            //rfv.ValidationGroup = "single";
            //rfv.ForeColor = System.Drawing.Color.Red;
            //rfv.ErrorMessage = "Please Enter Option " + Convert.ToChar(64 + loopcnt);
            //ctrlPlaceholderTextBox.Controls.Add(rfv);

            Label lblvalidaclose = new Label();
            lblvalidaclose.Text = "</div></div>";
            ctrlPlaceholderTextBox.Controls.Add(lblvalidaclose);
        }

        private void CreateTextBoxQEdit(int loopcnt, int qtype, string placeholder, string tbvalue, bool valueans)
        {
            ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            PlaceHolder ctrlPlaceholderTextBox = (PlaceHolder)cph.FindControl(placeholder);
            Label lblOpen = new Label();
            lblOpen.Text = "<div class='form-group'><label for= '' class='col-sm-3 control-label'>Option " + Convert.ToChar(64 + loopcnt);
            ctrlPlaceholderTextBox.Controls.Add(lblOpen);

            if (qtype == 1 || qtype == 3 || qtype == 6)
            {
                RadioButton rdbtn = new RadioButton();
                rdbtn.ID = loopcnt.ToString();
                rdbtn.CssClass = "";
                rdbtn.GroupName = "Single";
                rdbtn.EnableViewState = true;
                ctrlPlaceholderTextBox.Controls.Add(rdbtn);
                if (valueans)
                {
                    rdbtn.Checked = true;
                }
            }
            else if (qtype == 2 || qtype == 4)
            {
                System.Web.UI.WebControls.CheckBox chkmulti = new System.Web.UI.WebControls.CheckBox();
                chkmulti.ID = loopcnt.ToString();
                chkmulti.CssClass = "";
                chkmulti.EnableViewState = true;
                ctrlPlaceholderTextBox.Controls.Add(chkmulti);
                if (valueans)
                {
                    chkmulti.Checked = true;
                }
            }
            Label lblop = new Label();
            lblop.Text = "</label><div class='col-sm-8'>";
            ctrlPlaceholderTextBox.Controls.Add(lblop);

            TextBox tb = new TextBox();
            tb.ID = "tb" + loopcnt;
            tb.Text = tbvalue;
            tb.CssClass = "summernote form-control";
            tb.EnableViewState = true;
            ctrlPlaceholderTextBox.Controls.Add(tb);

            HiddenField hf = new HiddenField();
            hf.ID = "hf" + loopcnt;
            hf.Value = tbvalue;
            ctrlPlaceholderTextBox.Controls.Add(hf);

            Label lblClose = new Label();
            lblClose.Text = "</div><div class='col-sm-1'>";
            ctrlPlaceholderTextBox.Controls.Add(lblClose);

            //RequiredFieldValidator rfv = new RequiredFieldValidator();
            //rfv.ID = "rfv" + loopcnt;
            //rfv.ControlToValidate = "tb" + loopcnt;
            //rfv.ValidationGroup = "single";
            //rfv.ForeColor = System.Drawing.Color.Red;
            //rfv.ErrorMessage = "Please Enter Option " + Convert.ToChar(64 + loopcnt);
            //ctrlPlaceholderTextBox.Controls.Add(rfv);

            Label lblvalidaclose = new Label();
            lblvalidaclose.Text = "</div></div>";
            ctrlPlaceholderTextBox.Controls.Add(lblvalidaclose);
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            try
            {
                if (this.FileUpload1.HasFile)
                {
                    filePath = Server.MapPath("~/ExcelUpload/") + Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (!File.Exists(filePath))
                    {
                        FileUpload1.SaveAs(filePath);
                    }

                    TextExtractor extractor = new TextExtractor(filePath);
                    string docmunet = extractor.ExtractText();
                    string[] doc = docmunet.Split('\n');

                    List<propertyClass> objprop = new List<propertyClass>();
                    List<string> objprop1 = new List<string>();
                    List<int> objAnswerlist = new List<int>();
                    List<string> objprop2 = new List<string>() { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J." };

                    string tempp = string.Empty;
                    int questNo = 0;
                    bool flag = true;
                    string[] s;
                    string[] aas = null;
                    for (int i = 0; i < doc.Count(); i++)
                    {
                        string temp = doc[i].Trim();
                        if (temp != string.Empty)
                        {
                            if (temp == "Question")
                            {
                                questNo++;
                            }
                            else
                            {
                                if (objprop2.Contains(temp.Substring(0, 2)))
                                {
                                    objprop1.Add(temp.Substring(2).Trim());
                                }
                                else
                                {
                                    if (temp.Contains("Answer:"))
                                    {
                                        s = temp.Split(':');
                                        aas = Array.ConvertAll(s[1].Split(','), p => p.Trim());
                                        for (int j = 0; j < objprop1.Count; j++)
                                        {
                                            string value = Convert.ToChar(65 + j).ToString();
                                            if (aas.Contains(value))
                                                objAnswerlist.Add(1);
                                            else objAnswerlist.Add(0);
                                        }
                                        flag = false;
                                    }
                                    else
                                    {
                                        tempp += temp + "\n";
                                    }
                                }
                            }
                        }
                        if (questNo > 0 && flag == false)
                        {
                            int qtype = 1;
                            if (aas.Length > 1)
                            {
                                qtype = 2;
                            }
                            objprop.Add(new propertyClass { QuestionNo = questNo, Question = tempp, Answer = objprop1, RightAnswer = objAnswerlist, QuestionType = qtype, NoofAnswer = objprop1.Count, Score = 1 });
                            tempp = ""; objprop1 = new List<string>(); objAnswerlist = new List<int>();
                            flag = true;
                        }
                    }
                    if (uploadAndSave(objprop))
                    {
                        FillgridViewQAManage(MerchantId);
                        ShowMessage("Question upload successfully", MessageType.Success);
                    }
                    else
                    {
                        ShowMessage("Some technical error", MessageType.Warning);
                    }
                    // File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            finally
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
        }

        private string readFileContent(string path)
        {
            string filePath = Server.MapPath("~/ExcelUpload/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(filePath);
            //string filePath = Server.MapPath("~/ExcelUpload/QuizDemo.docx");
            TextExtractor extractor = new TextExtractor(filePath);
            string text = extractor.ExtractText();
            return text;

        }

        private bool uploadAndSave(List<propertyClass> diclist)
        {
            bool revalue = false;
            int retqID = default(int);
            try
            {
                foreach (var item in diclist)
                {
                    _boqamng.ExamCodeId = Convert.ToInt32(ddlExamCode.SelectedItem.Value);
                    _boqamng.ExamCode = ddlExamCode.SelectedItem.Text;
                    _boqamng.QuestionTypeId = item.QuestionType;
                    _boqamng.Score = item.Score;
                    _boqamng.Question = item.Question;
                    _boqamng.NoofAnswer = item.NoofAnswer;
                    _boqamng.Explanation = "";
                    _boqamng.MerchantId = MerchantId;
                    _boqamng.IsActive = true;
                    _boqamng.IsDelete = false;
                    _boqamng.CreatedBy = MerchantId;
                    _boqamng.CreatedDate = DateTime.UtcNow;
                    _boqamng.UpdatedBy = MerchantId;
                    _boqamng.UpdatedDate = DateTime.UtcNow;
                    _boqamng.QAId = 0;
                    _boqamng.Event = "Insert";
                    retqID = _baqamng.Insert(_boqamng);
                    using (var e1 = item.Answer.GetEnumerator())
                    using (var e2 = item.RightAnswer.GetEnumerator())
                    {
                        while (e1.MoveNext() && e2.MoveNext())
                        {
                            _boqans.QuestionId = retqID;
                            _boqans.Answer = e1.Current;
                            _boqans.RightAnswer = true;// e2.Current.ToString();
                            _boqans.IsActive = true;
                            _boqans.IsDelete = false;
                            _boqans.CreatedBy = MerchantId;
                            _boqans.CreatedDate = DateTime.UtcNow;
                            _boqans.UpdatedBy = MerchantId;
                            _boqans.UpdatedDate = DateTime.UtcNow;
                            _boqans.Event = "Insert";
                            if (_baqans.Insert(_boqans) == 1)
                            {
                                revalue = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError(ex);
                ShowMessage("Some technical error", MessageType.Warning);
            }
            return revalue;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            System.Data.DataTable _datatable3 = new System.Data.DataTable();
            //_datatable3 = _baqamng.SelectQAmanageListWithSearch("GetQAWMIdandSearch", txtSearch.Text, MerchantId);
            _datatable3 = _baqamng.SelectQAmanageListWithSearch("GetQAWMId", txtSearch.Text, MerchantId);
            gvQuestionManage.DataSource = _datatable3;
            gvQuestionManage.DataBind();
        }

        private void ClearControl()
        {
            btnAddAnswerSingle.Visible = true;
            btnAddAnswerMulti.Visible = true;
            btnAddAnswerVacant.Visible = true;
            btnAddAnswerDragDrop.Visible = true;
            btnAddAnswerScenario.Visible = true;
            FillgridViewQAManage(MerchantId);
            Common.ClearControl(Panel1);
            txtQuestion.Text = txtExplanation.Text = "";
            ViewState["QAId"] = ViewState["arrAnswerID"] = ViewState["arrMultiAnswerID"] = ViewState["arrVacantAnswerID"] = ViewState["arrDragdropAnswerID"] = ViewState["arrScenarioAnswerID"] = null;
            ViewState["QAId"] = ViewState["arrAnswerID"] = ViewState["arrMultiAnswerID"] = ViewState["arrVacantAnswerID"] = ViewState["arrDragdropAnswerID"] = ViewState["arrScenarioAnswerID"] = "";
            btnAdd.Text = btnMultiAdd.Text = btnVacantAdd.Text = btnDragdropAdd.Text = btnHotspotAdd.Text = btnScenarioAdd.Text = "Add";
            pnlSingleSelect.Visible = pnlMultiSelect.Visible = pnlVacant.Visible = pnlDragdrop.Visible = pnlHotspot.Visible = pnlScenario.Visible = false;
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}
class propertyClass
{
    public int QuestionNo { get; set; }
    public string Question { get; set; }
    public List<string> Answer { get; set; }
    public List<int> RightAnswer { get; set; }
    public int QuestionType { get; set; }
    public int NoofAnswer { get; set; }
    public decimal Score { get; set; }
}