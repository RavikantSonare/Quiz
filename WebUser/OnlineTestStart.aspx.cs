using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebUser.BOLayer;
using WebUser.BALayer;

namespace WebUser
{
    public partial class OnlineTestStart : System.Web.UI.Page
    {
        #region Global Variables
        // public int currentQuestionIndex;
        static BOExamManage _examqueanslist = new BOExamManage();
        #endregion

        static int hh, mm, ss;
        static double TimeAllSecondes = 3600;

        private int currentQuestionIndex
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetail"] != null)
                {
                    if (!IsPostBack)
                    {
                        BOUser _bouserDetail = (BOUser)Session["UserDetail"];
                        if (Request.QueryString["exmid"] != null && Request.QueryString["tstmd"] != null)
                        {
                            string examid = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["exmid"]));
                            _examqueanslist = GetEQAList(examid, Request.QueryString["tstmd"]);
                            GetExamDetail(_examqueanslist);
                        }
                        else
                        {
                            Response.Redirect("UserLogin.aspx");
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

            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex -= 1;
                btnnext.Enabled = true;
                showQuestionNo(currentQuestionIndex + 1);
                GetExamDetail(_examqueanslist);
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < _examqueanslist.QuestionList.Count - 1)
            {
                currentQuestionIndex += 1;
                btnprevious.Enabled = true;
                showQuestionNo(currentQuestionIndex + 1);
                GetExamDetail(_examqueanslist);
            }
        }

        private BOExamManage GetEQAList(string examid, object mode)
        {
            BAExamManage _baexmmng = new BAExamManage();
            var list = _baexmmng.SelectExamQestionAnswer("GetEQAWithQId", Convert.ToInt32(examid));
            list.QuestionList.ForEach(e => e.Event = mode.ToString());
            return list;
        }

        private void GetExamDetail(BOExamManage _exmlist)
        {
            if (_exmlist != null)
            {
                lblExamCode.Text = _exmlist.ExamCode;
                lblTotalQuestion.Text = Convert.ToString(_exmlist.QuestionList.Count);
                dlquesanswer.DataSource = _exmlist.QuestionList.Skip(currentQuestionIndex).Take(1);
                dlquesanswer.DataBind();
                showQuestionNo(currentQuestionIndex + 1);
            }
            else
            {
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfTestMode = (HiddenField)e.Item.FindControl("hfTestMode");
                RadioButtonList rdbtnAnswerList = (RadioButtonList)e.Item.FindControl("rdbtnAnswerList");
                CheckBoxList chkboxAnswerList = (CheckBoxList)e.Item.FindControl("chkboxAnswerList");
                int QuestionID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "QAId"));
                var listanswer = _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().AnswerList;
                for (int i = 0; i < listanswer.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = listanswer[i].Answer;
                    item.Value = listanswer[i].AnswerId.ToString();
                    if (hfTestMode.Value == "SM")
                        item.Selected = Convert.ToBoolean(listanswer[i].RightAnswer.Equals("1") ? true : false);
                    rdbtnAnswerList.Items.Add(item);
                    chkboxAnswerList.Items.Add(item);
                }
            }
        }

        private void showQuestionNo(int qno)
        {
            try
            {
                lblOutofTotalQuestion.Text = qno.ToString();
                if (currentQuestionIndex == 0)
                {
                    btnnext.Enabled = true;
                    btnprevious.Enabled = false;
                }
                if (currentQuestionIndex == _examqueanslist.QuestionList.Count - 1)
                {
                    btnprevious.Enabled = true;
                    btnnext.Enabled = false;
                }
            }
            catch
            {

            }
        }

        protected void rdbtnAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList chklst = (RadioButtonList)sender;
            string commandArguments = chklst.Attributes["commandArguments"].ToString();
            string value = chklst.SelectedItem.Value;
            _examqueanslist.QuestionList.Where(q => q.QAId.Equals(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.Answer.Equals(value)).FirstOrDefault().UserAnswer = true;
        }

        protected void chkboxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList chklst = (CheckBoxList)sender;
            string commandArguments = chklst.Attributes["commandArguments"].ToString();
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.Items[i].Selected == true)// getting selected value from CheckBox List  
                {
                    string value = chklst.Items[i].Value;
                    _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32(value)).FirstOrDefault().UserAnswer = true;
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //if (TimeAllSecondes > 0)
            //{
            //    TimeAllSecondes = TimeAllSecondes - 1;
            //}

            //TimeSpan time_Span = TimeSpan.FromSeconds(TimeAllSecondes);
            //hh = time_Span.Hours;
            //mm = time_Span.Minutes;
            //ss = time_Span.Seconds;

            //Label2.Text = "  " + hh + ":" + mm + ":" + ss;
        }
    }
}