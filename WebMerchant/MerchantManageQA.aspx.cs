using System;
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
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace WebMerchant
{
    public partial class MerchantManageQA : System.Web.UI.Page
    {
        private int MerchantId = default(int);
        private BOQAManage _boqamng = new BOQAManage();
        private BAQAManage _baqamng = new BAQAManage();
        private List<BOQAManage> _boqamnglist = new List<BOQAManage>();
        BOQAnswer _boqans = new BOLayer.BOQAnswer();
        BAQAnswer _baqans = new BAQAnswer();
        public enum MessageType { Success, Error, Info, Warning };
        DataTable _dtextrapermission = new DataTable();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keysQ = Request.Form.AllKeys.Where(key => key.Contains("tb")).ToList();
            if (keysQ.Count > 0)
            {
                foreach (string key in keysQ)
                {
                    int txtId = Convert.ToInt16(key.Substring(28));
                    this.CreateTextBoxQ(txtId, Convert.ToInt32(Session["Qtypevalue"]), "ctrlPlaceholderTextBox");
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
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        FillddlExamCode(MerchantId);
                        FillrbtnListQuestiontype(_bomerchantDetail.MerchantLevelId);
                        FillgridViewQAManage(MerchantId);
                        _dtextrapermission = (DataTable)Session["extrapermission"];
                        if (_dtextrapermission.Rows[0][0].ToString() == "1")
                        {
                            pnlfileuploaod.Visible = true;
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

        private void FillddlExamCode(int mid)
        {
            BAExamManage _baexmmng = new BAExamManage();
            System.Data.DataTable _datatable1 = new System.Data.DataTable();
            _datatable1 = _baexmmng.SelectExamDetail("GetExamWithMId", mid, "");
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
            System.Data.DataSet _dataset = new System.Data.DataSet();
            _dataset = _baqtype.SelectQuestionTypeList("GetQTypeWithMLevel", levelid);
            if (_dataset.Tables[0].Rows.Count > 0)
            {
                ddlQuestionType.DataValueField = "QuestionTypeId";
                ddlQuestionType.DataTextField = "QuestionType";
                ddlQuestionType.DataSource = _dataset.Tables[0];
                ddlQuestionType.DataBind();
                ddlQuestionType.Items.Insert(0, "Select");
            }
        }

        private void FillgridViewQAManage(int mid)
        {
            System.Data.DataTable _datatable3 = new System.Data.DataTable();
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
            ctrlPlaceholderTextBox.Controls.Clear();
            if (ddlQuestionType.SelectedIndex == 0)
            {
                pnlSingleSelect.Visible = false;
                pnlHotspot.Visible = false;
                pnladdAnswertxtbox.Visible = false;
                pnlETS.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "1")
            {
                prevVaile.Value = Convert.ToString(2);
                for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox");
                }
                pnlSingleSelect.Visible = true;
                pnlHotspot.Visible = false;
                pnladdAnswertxtbox.Visible = true;
                pnlETS.Visible = true;
            }
            else if (ddlQuestionType.SelectedItem.Value == "2")
            {
                prevVaile.Value = Convert.ToString(4);
                for (int loopcnt = 1; loopcnt <= 4; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox");
                }
                pnlSingleSelect.Visible = true;
                pnlHotspot.Visible = false;
                pnladdAnswertxtbox.Visible = true;
                pnlETS.Visible = true;
            }

            else if (ddlQuestionType.SelectedItem.Value == "3")
            {
                prevVaile.Value = Convert.ToString(2);
                for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox");
                }
                pnlSingleSelect.Visible = true;
                pnlHotspot.Visible = false;
                pnladdAnswertxtbox.Visible = true;
                pnlETS.Visible = true;
            }
            else if (ddlQuestionType.SelectedItem.Value == "4")
            {
                prevVaile.Value = Convert.ToString(4);
                for (int loopcnt = 1; loopcnt <= 4; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox");
                }
                pnlSingleSelect.Visible = true;
                pnlHotspot.Visible = false;
                pnladdAnswertxtbox.Visible = true;
                pnlETS.Visible = true;
            }
            else if (ddlQuestionType.SelectedItem.Value == "5")
            {
                pnlHotspot.Visible = true;
                pnlSingleSelect.Visible = false;
                pnladdAnswertxtbox.Visible = false;
                pnlETS.Visible = false;
            }
            else if (ddlQuestionType.SelectedItem.Value == "6")
            {
                prevVaile.Value = Convert.ToString(2);
                for (int loopcnt = 1; loopcnt <= 2; loopcnt++)
                {
                    this.CreateTextBoxQ(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox");
                }
                pnlSingleSelect.Visible = true;
                pnlHotspot.Visible = false;
                pnladdAnswertxtbox.Visible = true;
                pnlETS.Visible = true;
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
                _boqamng.Question = txtQuestion.Text;// hftxtquestion.Value;
                _boqamng.NoofAnswer = Convert.ToInt32(noofanswer);
                _boqamng.Explanation = txtExplanation.Text;// hftxtExplanation.Value;
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

        private void AddSingleAnswer(int qusvalu)
        {
            if (qusvalu == 2)
            {
                int[] array = (ViewState["arrAnswerID"]) as int[];
                for (int loopcnt = 1; loopcnt <= array.Length; loopcnt++)
                {
                    _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.AnswerId = array[loopcnt - 1];
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
        }

        private void AddMultiAnswer(int qusvalu)
        {
            if (qusvalu == 2)
            {
                int[] arrayMulti = (ViewState["arrMultiAnswerID"]) as int[];
                for (int loopcnt = 1; loopcnt <= arrayMulti.Length; loopcnt++)
                {
                    _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.AnswerId = arrayMulti[loopcnt - 1];
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
        }

        private void AddVacantAnswer(int qusvalu)
        {
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
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
        }

        private void AddDragdropAnswer(int qusvalu)
        {
            if (qusvalu == 2)
            {
                int[] arrayDragdrop = (ViewState["arrDragdropAnswerID"]) as int[];
                for (int loopcnt = 1; loopcnt <= arrayDragdrop.Length; loopcnt++)
                {
                    _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.AnswerId = arrayDragdrop[loopcnt - 1];
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
        }

        private void AddHotspotAnswer(int qusvalu)
        {
            string[] AnswerArray = txtmaphtml.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
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
        }

        private void AddScenarioAnswer(int qusvalu)
        {
            if (qusvalu == 2)
            {
                int[] array = (ViewState["arrScenarioAnswerID"]) as int[];
                for (int loopcnt = 1; loopcnt <= array.Length; loopcnt++)
                {
                    _boqans.QuestionId = Convert.ToInt32(ViewState["QAId"]);
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.AnswerId = array[loopcnt - 1];
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
                    if (Request.Params.AllKeys.Contains("ctl00$ContentPlaceHolder1$tb" + loopcnt))
                    {
                        _boqans.Answer = Request.Params["ctl00$ContentPlaceHolder1$tb" + loopcnt].ToString();
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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    int qusvalu = default(int);
                    if (Session["Qtypevalue"].ToString() == "1")
                    {
                        qusvalu = AddQuestion(prevVaile.Value);
                        AddSingleAnswer(qusvalu);
                    }
                    else if (Session["Qtypevalue"].ToString() == "2")
                    {
                        qusvalu = AddQuestion(prevVaile.Value);
                        AddMultiAnswer(qusvalu);
                    }
                    else if (Session["Qtypevalue"].ToString() == "3")
                    {
                        qusvalu = AddQuestion(prevVaile.Value);
                        AddVacantAnswer(qusvalu);
                    }
                    else if (Session["Qtypevalue"].ToString() == "4")
                    {
                        qusvalu = AddQuestion(prevVaile.Value);
                        AddDragdropAnswer(qusvalu);
                    }
                    else if (Session["Qtypevalue"].ToString() == "5")
                    {
                        if (txtmaphtml.Text != "")
                        {
                            string[] AnswerArray = txtmaphtml.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                            ImageUpload(txtimage.Text, hdimage.Value);
                            qusvalu = AddQuestion(AnswerArray.Length.ToString());
                            AddHotspotAnswer(qusvalu);
                        }
                    }
                    else if (Session["Qtypevalue"].ToString() == "6")
                    {
                        qusvalu = AddQuestion(prevVaile.Value);
                        AddScenarioAnswer(qusvalu);
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
                btnAddAnswerSingle.Visible = false;
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
                    //hftxtquestion.Value = _datatable4.Rows[0][4].ToString();
                    txtQuestion.Text = _datatable4.Rows[0][4].ToString();
                    hfExhibit.Value = _datatable4.Rows[0]["Exhibit"].ToString();
                    hfTopology.Value = _datatable4.Rows[0]["Topology"].ToString();
                    hfScenario.Value = _datatable4.Rows[0]["Scenario"].ToString();
                    if (_datatable4.Rows[0][2].ToString().Equals("1"))
                    {
                        pnlSingleSelect.Visible = true;
                        pnlHotspot.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrAnswerID"] = arrAnswerID;
                        txtExplanation.Text = _datatable4.Rows[0][6].ToString();
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("2"))
                    {
                        pnlSingleSelect.Visible = true;
                        pnlHotspot.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrMultiAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrMultiAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrMultiAnswerID"] = arrMultiAnswerID;
                        txtExplanation.Text = _datatable4.Rows[0][6].ToString();
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("3"))
                    {
                        pnlSingleSelect.Visible = true;
                        pnlHotspot.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrVacantAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrVacantAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrVacantAnswerID"] = arrVacantAnswerID;
                        txtExplanation.Text = _datatable4.Rows[0][6].ToString();
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("4"))
                    {
                        pnlSingleSelect.Visible = true;
                        pnlHotspot.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrDragdropAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrDragdropAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrDragdropAnswerID"] = arrDragdropAnswerID;
                        txtExplanation.Text = _datatable4.Rows[0][6].ToString();
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("5"))
                    {
                        pnlSingleSelect.Visible = false;
                        pnlHotspot.Visible = false;
                        ShowMessage("Can not edit hotspot question", MessageType.Info);
                        //ftxtHotspotExplanation.Text = _datatable4.Rows[0][6].ToString();
                        //btnHotspotAdd.Text = "Update";
                    }
                    else if (_datatable4.Rows[0][2].ToString().Equals("6"))
                    {
                        pnlSingleSelect.Visible = true;
                        pnlHotspot.Visible = false;
                        prevVaile.Value = _datatable4.Rows[0][5].ToString();
                        int[] arrScenarioAnswerID = new int[Convert.ToInt32(_datatable4.Rows[0][5])];
                        for (int loopcnt = 1; loopcnt <= Convert.ToInt32(_datatable4.Rows[0][5].ToString()); loopcnt++)
                        {
                            arrScenarioAnswerID[loopcnt - 1] = Convert.ToInt32(_datatable4.Rows[loopcnt - 1][8]);
                            CreateTextBoxQEdit(loopcnt, Convert.ToInt32(ddlQuestionType.SelectedItem.Value), "ctrlPlaceholderTextBox", _datatable4.Rows[loopcnt - 1][9].ToString(), Convert.ToBoolean(_datatable4.Rows[loopcnt - 1][10]));
                        }
                        ViewState["arrScenarioAnswerID"] = arrScenarioAnswerID;
                        //hftxtExplanation.Value = _datatable4.Rows[0][6].ToString();
                        txtExplanation.Text = _datatable4.Rows[0][6].ToString();
                    }
                    lnkbtnAdd.Text = "Update";
                    btnAdd.Text = "Update";
                    lnkbtnAdd.OnClientClick = String.Format("return getConfirmation(this,'{0}','{1}');", "Please confirm", "Are you sure you want to update this record?");
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

        private void InitializeDynamicText(int qtype, string plcholdname, PlaceHolder plcholer)
        {
            int index = plcholer.Controls.OfType<System.Web.UI.WebControls.TextBox>().ToList().Count + 1;
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

            System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
            tb.ID = "tb" + loopcnt;
            tb.EnableViewState = true;
            tb.TextMode = TextBoxMode.MultiLine;
            ctrlPlaceholderTextBox.Controls.Add(tb);

            Label lblClose = new Label();
            lblClose.Text = "</div><div class='col-sm-1'>";
            ctrlPlaceholderTextBox.Controls.Add(lblClose);

            Label lblvalidaclose = new Label();
            lblvalidaclose.Text = "</div></div>";
            ctrlPlaceholderTextBox.Controls.Add(lblvalidaclose);

            Label myScript = new Label();
            myScript.Text = "\n<script type=\"text/javascript\" language=\"Javascript\" >\n";
            string name = "ContentPlaceHolder1_tb" + loopcnt;
            myScript.Text += @"CKEDITOR.replace('" + name + "',";
            myScript.Text += @"{
    filebrowserUploadUrl: './Upload.ashx/',
    filebrowserImageUploadUrl: './Upload.ashx',
    filebrowserFlashUploadUrl: './Upload.ashx/',
}); ";
            myScript.Text += "\n\n </script>";
            ctrlPlaceholderTextBox.Controls.Add(myScript);
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

            System.Web.UI.WebControls.TextBox tb = new System.Web.UI.WebControls.TextBox();
            tb.ID = "tb" + loopcnt;
            tb.Text = tbvalue;
            tb.TextMode = TextBoxMode.MultiLine;
            tb.EnableViewState = true;
            ctrlPlaceholderTextBox.Controls.Add(tb);

            Label lblClose = new Label();
            lblClose.Text = "</div><div class='col-sm-1'>";
            ctrlPlaceholderTextBox.Controls.Add(lblClose);

            Label lblvalidaclose = new Label();
            lblvalidaclose.Text = "</div></div>";
            ctrlPlaceholderTextBox.Controls.Add(lblvalidaclose);

            Label myScript = new Label();
            myScript.Text = "\n<script type=\"text/javascript\" language=\"Javascript\" >\n";
            string name = "ContentPlaceHolder1_tb" + loopcnt;
            myScript.Text += @"CKEDITOR.replace('" + name + "',";
            myScript.Text += @"{
    filebrowserUploadUrl: './Upload.ashx/',
    filebrowserImageUploadUrl: './Upload.ashx',
    filebrowserFlashUploadUrl: './Upload.ashx/',
}); ";
            myScript.Text += "\n\n </script>";
            ctrlPlaceholderTextBox.Controls.Add(myScript);
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            List<Questions> _quetionList = new List<Questions>();
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
                    List<Answerlist> _answerlist = new List<Answerlist>();
                    List<RightAnswer> _rightAnswerlist = new List<RightAnswer>();
                    List<QuestionTypelist> _questionTypeList = new List<QuestionTypelist>();
                    _questionTypeList.Add(new QuestionTypelist { QuestionTypeId = 1, QuestionType = "Question(Single Choice)" });
                    _questionTypeList.Add(new QuestionTypelist { QuestionTypeId = 2, QuestionType = "Question(Multi Choice)" });
                    _questionTypeList.Add(new QuestionTypelist { QuestionTypeId = 3, QuestionType = "Question(Vacant)" });
                    _questionTypeList.Add(new QuestionTypelist { QuestionTypeId = 4, QuestionType = "Question(Drag & Drop)" });
                    _questionTypeList.Add(new QuestionTypelist { QuestionTypeId = 5, QuestionType = "Question(Hotspot)" });
                    _questionTypeList.Add(new QuestionTypelist { QuestionTypeId = 6, QuestionType = "Question(Scenario)" });

                    List<QuestionTypelist> _questionTypeList1 = new List<QuestionTypelist>();
                    List<string> AnswerCharList = new List<string>() { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J." };
                    string CommanStrflag = "Q", QuestionStr = string.Empty, AnswerStr = string.Empty, RightAnswerStr = string.Empty, ExpStr = string.Empty;
                    string resourceimg = string.Empty, exhabitimg = string.Empty, topologyimg = string.Empty, scanarioimg = string.Empty;
                    int DoneQueStatus = 0, questionNo = 0;
                    string[] aas = null; string CurrrentStr = string.Empty;

                    string _imgbtnshow = string.Empty;
                    List<string> ImageTypeList = new List<string>() { "Refer to the exhibit", "Refer to the topology", "Refer to the Scenario" };


                    Document document = new Document(filePath);
                    int index = 1;
                    foreach (Spire.Doc.Section section in document.Sections)
                    {
                        foreach (Spire.Doc.Documents.Paragraph paragraph in section.Paragraphs)
                        {
                            DoneQueStatus++;
                            foreach (DocumentObject docObject in paragraph.ChildObjects)
                            {
                                CurrrentStr = paragraph.Text.Trim();
                                if (String.IsNullOrEmpty(CurrrentStr))
                                {
                                    if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                                    {
                                        string docname = System.IO.Path.GetFileNameWithoutExtension(filePath);
                                        DocPicture pic = docObject as DocPicture;
                                        string filename = System.AppDomain.CurrentDomain.BaseDirectory + "resource\\";
                                        bool exists = System.IO.Directory.Exists(filename);
                                        if (!exists)
                                        {
                                            DirectoryInfo di = System.IO.Directory.CreateDirectory(filename);
                                        }
                                        else
                                        {
                                            //Console.WriteLine("The Folder already exists");
                                        }
                                        DirectoryInfo dInfo = new DirectoryInfo(filename);
                                        DirectorySecurity dSecurity = dInfo.GetAccessControl();
                                        dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                                        dInfo.SetAccessControl(dSecurity);

                                        String imgName = String.Format(docname + "-Question" + questionNo + "-{0}.png", index);
                                        imgName = string.Concat(Path.GetFileNameWithoutExtension(imgName), DateTime.Now.ToString("yyyyMMddHHmmssfff"), Path.GetExtension(imgName));
                                        if (_imgbtnshow == "")
                                        {
                                            resourceimg = imgName;
                                        }
                                        else if (_imgbtnshow == "Refer to the exhibit")
                                        {
                                            exhabitimg = imgName;
                                        }
                                        else if (_imgbtnshow == "Refer to the topology")
                                        {
                                            topologyimg = imgName;
                                        }
                                        else if (_imgbtnshow == "Refer to the Scenario")
                                        {
                                            scanarioimg = imgName;
                                        }
                                        //Save Image
                                        if (!File.Exists(imgName))
                                        {
                                            pic.Image.Save(filename + imgName, System.Drawing.Imaging.ImageFormat.Png);
                                        }
                                        index++;
                                    }
                                }

                                if (!String.IsNullOrEmpty(CurrrentStr))
                                {
                                    var objval = _questionTypeList.Where(a => a.QuestionType.Contains(CurrrentStr)).FirstOrDefault();
                                    if (objval != null)
                                    {
                                        CommanStrflag = "Q";
                                        _questionTypeList1.Add(new QuestionTypelist { QuestionTypeId = objval.QuestionTypeId, QuestionType = objval.QuestionType });
                                        if (questionNo == 0)
                                            questionNo++;
                                    }
                                    if (ImageTypeList.Contains(CurrrentStr))
                                    {
                                        CommanStrflag = "IN";
                                    }

                                    if (AnswerCharList.Contains(CurrrentStr.Substring(0, 2)))
                                        CommanStrflag = "A";

                                    if (CurrrentStr.Contains("Answer:"))
                                        CommanStrflag = "RA";

                                    if (CurrrentStr.Contains("Explanation:"))
                                        CommanStrflag = "E";
                                }
                                switch (CommanStrflag)
                                {
                                    case "Q":
                                        if (!_questionTypeList.Any(a => a.QuestionType.Contains(CurrrentStr)))
                                        {
                                            QuestionStr += CurrrentStr + "\n";
                                        }
                                        break;
                                    case "IN":
                                        _imgbtnshow = CurrrentStr;
                                        CommanStrflag = "";
                                        break;
                                    case "RA":
                                        RightAnswerStr += CurrrentStr;
                                        if (RightAnswerStr.Contains("Answer:"))
                                        {
                                            var s = RightAnswerStr.Split(':');
                                            aas = Array.ConvertAll(s[1].Split(','), p => p.Trim());
                                            for (int j = 0; j < _answerlist.Count; j++)
                                            {
                                                string value = Convert.ToChar(65 + j).ToString();
                                                if (aas.Contains(value))
                                                {
                                                    _rightAnswerlist.Add(new RightAnswer { Rightanswer = true });
                                                }
                                                else _rightAnswerlist.Add(new RightAnswer { Rightanswer = false });
                                            }
                                        }
                                        break;
                                    case "A":
                                        _answerlist.Add(new Answerlist { Answer = CurrrentStr.Substring(2).Trim(), QuestionNo = questionNo });
                                        break;
                                    case "E":
                                        ExpStr += CurrrentStr + "\n";
                                        break;
                                }
                                break;
                            }
                            if (paragraph.ChildObjects.Count == 0 && CurrrentStr != null)
                            {

                                _quetionList.Add(new Questions { QuestionNo = questionNo, Question = QuestionStr, Answerlist = _answerlist, RightAnswerlist = _rightAnswerlist, QuestionType = _questionTypeList1, NoofAnswer = _answerlist.Count, Score = 1, Explaination = ExpStr, RightAnswerString = RightAnswerStr, Resource = resourceimg, Exhibit = exhabitimg, Topology = topologyimg, Scenario = scanarioimg });
                                CommanStrflag = "Q"; QuestionStr = string.Empty; AnswerStr = string.Empty; RightAnswerStr = string.Empty; ExpStr = string.Empty; resourceimg = string.Empty; exhabitimg = string.Empty; topologyimg = string.Empty; scanarioimg = string.Empty; CurrrentStr = string.Empty;
                                _answerlist = new List<Answerlist>(); _rightAnswerlist = new List<RightAnswer>(); _questionTypeList1 = new List<QuestionTypelist>(); _imgbtnshow = string.Empty;
                                questionNo++; index = 1;
                            }
                        }
                        if (uploadAndSave(_quetionList))
                        {
                            FillgridViewQAManage(MerchantId);
                            ShowMessage("Question upload successfully", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage("Some technical error", MessageType.Warning);
                        }
                    }
                    //File.Delete(filePath);
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

        private bool uploadAndSave(List<Questions> diclist)
        {
            bool revalue = false;
            int retqID = default(int);
            try
            {
                //foreach (var item in diclist)
                for (var x = 0; x < diclist.Count; x++)
                {
                    _boqamng.ExamCodeId = Convert.ToInt32(ddlExamCode.SelectedItem.Value);
                    _boqamng.ExamCode = ddlExamCode.SelectedItem.Text;
                    _boqamng.QuestionTypeId = diclist[x].QuestionType.FirstOrDefault().QuestionTypeId;
                    _boqamng.Score = diclist[x].Score;
                    _boqamng.Question = diclist[x].Question;
                    _boqamng.NoofAnswer = diclist[x].NoofAnswer;
                    _boqamng.Explanation = diclist[x].Explaination;
                    _boqamng.MerchantId = MerchantId;
                    _boqamng.Resource = diclist[x].Resource;
                    _boqamng.Exhibit = diclist[x].Exhibit;
                    _boqamng.Topology = diclist[x].Topology;
                    _boqamng.Scenario = diclist[x].Scenario;
                    _boqamng.IsActive = true;
                    _boqamng.IsDelete = false;
                    _boqamng.CreatedBy = MerchantId;
                    _boqamng.CreatedDate = DateTime.UtcNow;
                    _boqamng.UpdatedBy = MerchantId;
                    _boqamng.UpdatedDate = DateTime.UtcNow;
                    _boqamng.QAId = 0;
                    _boqamng.Event = "Insert";
                    retqID = _baqamng.Insert(_boqamng);
                    using (var e1 = diclist[x].Answerlist.GetEnumerator())
                    using (var e2 = diclist[x].RightAnswerlist.GetEnumerator())
                    {
                        while (e1.MoveNext() && e2.MoveNext())
                        {
                            _boqans.QuestionId = retqID;
                            _boqans.Answer = e1.Current.Answer;
                            _boqans.RightAnswer = e2.Current.Rightanswer;
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
            _datatable3 = _baqamng.SelectQAmanageListWithSearch("GetQAWMId", txtSearch.Text, MerchantId);
            gvQuestionManage.DataSource = _datatable3;
            gvQuestionManage.DataBind();
        }

        private void ClearControl()
        {
            btnAddAnswerSingle.Visible = true;
            FillgridViewQAManage(MerchantId);
            Common.ClearControl(Panel1);
            txtQuestion.Text = txtExplanation.Text = "";
            ViewState["QAId"] = ViewState["arrAnswerID"] = ViewState["arrMultiAnswerID"] = ViewState["arrVacantAnswerID"] = ViewState["arrDragdropAnswerID"] = ViewState["arrScenarioAnswerID"] = null;
            ViewState["QAId"] = ViewState["arrAnswerID"] = ViewState["arrMultiAnswerID"] = ViewState["arrVacantAnswerID"] = ViewState["arrDragdropAnswerID"] = ViewState["arrScenarioAnswerID"] = "";
            btnAdd.Text = "Add";
            lnkbtnAdd.Text = "Add";
            lnkbtnAdd.OnClientClick = "";
            pnlSingleSelect.Visible = pnlHotspot.Visible = pnladdAnswertxtbox.Visible = false;
            pnlETS.Visible = true;
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}

[Serializable]
class Questions
{
    public int QuestionNo { get; set; }
    public string Question { get; set; }
    public List<Answerlist> Answerlist { get; set; }
    public List<RightAnswer> RightAnswerlist { get; set; }
    public List<QuestionTypelist> QuestionType { get; set; }
    public int NoofAnswer { get; set; }
    public decimal Score { get; set; }
    public string Explaination { get; set; }
    public string RightAnswerString { get; set; }
    public string Resource { get; set; }
    public string Exhibit { get; set; }
    public string Topology { get; set; }
    public string Scenario { get; set; }
}

[Serializable]
class Answerlist
{
    public string Answer { get; set; }
    public int QuestionNo { get; set; }
}

[Serializable]
class QuestionTypelist
{
    public int QuestionTypeId { get; set; }
    public string QuestionType { get; set; }
}

[Serializable]
class RightAnswer { public bool Rightanswer { get; set; } }