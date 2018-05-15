using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebUser.BOLayer;
using WebUser.BALayer;
using System.Web.Services;

namespace WebUser
{
    public partial class OnlineTestStart : System.Web.UI.Page
    {
        #region Global Variables
        // public int currentQuestionIndex;
        static BOExamManage _examqueanslist = new BOExamManage();
        static bool flagMark = false;
        #endregion

        static int hh, mm, ss;
        static double TimeAllSecondes;
        public enum MessageType { Success, Error, Info, Warning };

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

        ArrayList arraylist1 = new ArrayList();
        ArrayList arraylist2 = new ArrayList();
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
                            if (Request.QueryString["tstmd"].ToString().Equals("SM") || Request.QueryString["tstmd"].ToString().Equals("TM"))
                            {
                                Timer1.Enabled = false;
                                pnltimer.Visible = false;
                            }
                            if (Request.QueryString["tstmd"].ToString().Equals("SM"))
                            {
                                btnCorrectAnswer.Visible = true;
                            }
                            string examid = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["exmid"]));
                            _examqueanslist = GetEQAList(examid, Request.QueryString["tstmd"]);
                            GetExamDetail(_examqueanslist);
                            TimeAllSecondes = Convert.ToDouble(_examqueanslist.TestTime) * 60;
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
            catch
            {

            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagMark)
            {
                if (currentQuestionIndex > 0)
                {
                    currentQuestionIndex--;
                    btnnext.Enabled = true;
                    GetExamDetail(_examqueanslist);
                    showQuestionNo(currentQuestionIndex + 1);
                }
                if (currentQuestionIndex == 0)
                {
                    btnnext.Enabled = true;
                    btnprevious.Enabled = false;
                }
            }
            else
            {
                if (currentQuestionIndex > 0)
                {
                    currentQuestionIndex -= 1;
                    btnnext.Enabled = true;
                    showQuestionNo(currentQuestionIndex + 1);
                    GetExamDetail(_examqueanslist);
                }
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (flagMark)
            {
                if (_examqueanslist.QuestionList.Where(f => f.Mark).ToList().Count - 1 > currentQuestionIndex)
                {
                    currentQuestionIndex++;
                    btnprevious.Enabled = true;
                    GetExamDetail(_examqueanslist);
                    showQuestionNo(currentQuestionIndex + 1);
                }
                if (_examqueanslist.QuestionList.Where(f => f.Mark).ToList().Count - 1 == currentQuestionIndex)
                {
                    btnprevious.Enabled = true;
                    btnnext.Enabled = false;
                }
            }
            else
            {
                if (currentQuestionIndex < _examqueanslist.QuestionList.Count - 1)
                {
                    currentQuestionIndex += 1;
                    btnprevious.Enabled = true;
                    showQuestionNo(currentQuestionIndex + 1);
                    GetExamDetail(_examqueanslist);
                }
            }
        }

        private BOExamManage GetEQAList(string examid, object mode)
        {
            BAExamManage _baexmmng = new BAExamManage();
            var list = _baexmmng.SelectExamQestionAnswer("GetEQAWithQId", Convert.ToInt32(examid));
            if (list != null)
            {
                list.QuestionList.ForEach(e => e.Event = mode.ToString());
                if (mode.ToString() == "TM" || mode.ToString() == "TO")
                {
                    list = Shuffle(list);
                    if (!string.IsNullOrEmpty(list.TestOption))
                    {
                        var questinlist = list.QuestionList.Take(Convert.ToInt32(list.TestOption)).ToList();
                        list.QuestionList.Clear();
                        list.QuestionList = questinlist;
                    }
                }
                return list;
            }
            else
            {
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
                btnEndExam.Enabled = false;
                return null;
            }
        }

        public static BOExamManage Shuffle(BOExamManage list)
        {
            var random = new Random();
            for (int index = list.QuestionList.Count - 1; index >= 1; index--)
            {
                int other = random.Next(0, index + 1);
                var temp = list.QuestionList[index];
                list.QuestionList[index] = list.QuestionList[other];
                list.QuestionList[other] = temp;
            }
            return list;
        }

        private void GetExamDetail(BOExamManage _exmlist)
        {
            if (_exmlist != null)
            {
                lblExamName.Text = _exmlist.SecondCategory + " " + _exmlist.ExamCode;
                if (flagMark)
                {
                    lblTotalQuestion.Text = Convert.ToString(_exmlist.QuestionList.Where(q => q.Mark.Equals(true)).Count());
                    dlquesanswer.DataSource = _exmlist.QuestionList.Where(q => q.Mark.Equals(true)).Skip(currentQuestionIndex).Take(1);
                    dlquesanswer.DataBind();
                    dlmark.DataSource = _exmlist.QuestionList.Where(q => q.Mark.Equals(true)).Skip(currentQuestionIndex).Take(1);
                    dlmark.DataBind();
                    showQuestionNo(currentQuestionIndex + 1);
                }
                else
                {
                    lblTotalQuestion.Text = Convert.ToString(_exmlist.QuestionList.Count);
                    dlquesanswer.DataSource = _exmlist.QuestionList.Skip(currentQuestionIndex).Take(1);
                    dlquesanswer.DataBind();
                    dlmark.DataSource = _exmlist.QuestionList.Skip(currentQuestionIndex).Take(1);
                    dlmark.DataBind();
                    showQuestionNo(currentQuestionIndex + 1);
                }
            }
            else
            {
                lblExamName.Text = "No question found!";
                lblExamName.ForeColor = System.Drawing.Color.Red;
                btnprevious.Enabled = false;
                btnnext.Enabled = false;
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                int QuestionID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "QAId"));
                HiddenField hfTestMode = (HiddenField)e.Item.FindControl("hfTestMode");
                RadioButtonList rdbtnAnswerList = (RadioButtonList)e.Item.FindControl("rdbtnAnswerList");
                CheckBoxList chkboxAnswerList = (CheckBoxList)e.Item.FindControl("chkboxAnswerList");
                ListBox lbDrag = (ListBox)e.Item.FindControl("lbDrag");
                ListBox lbDrop = (ListBox)e.Item.FindControl("lbDrop");
                ImageMap imgHotSpot = (ImageMap)e.Item.FindControl("imgHotSpot");
                imgHotSpot.ImageUrl = "http://xcert.top/resource/" + _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().Resource;
                var listanswer = _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().AnswerList;
                for (int i = 0; i < listanswer.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = listanswer[i].Answer;
                    item.Value = listanswer[i].AnswerId.ToString();
                    if (hfTestMode.Value == "SM")
                    {
                        //item.Selected = listanswer[i].RightAnswer;
                    }
                    else if (hfTestMode.Value == "TM" || hfTestMode.Value == "TO")
                    {
                        item.Selected = Convert.ToBoolean(listanswer[i].UserAnswer);
                    }
                    int qutype = _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().QuestionTypeId;
                    if (qutype == 1 || qutype == 3 || qutype == 6)
                    {
                        rdbtnAnswerList.Items.Add(item);
                    }
                    else if (qutype == 2)
                    {
                        chkboxAnswerList.Items.Add(item);
                    }
                    else if (qutype == 4)
                    {
                        if (item.Selected)
                        {
                            lbDrop.Items.Add(item);
                        }
                        else
                        {
                            lbDrag.Items.Add(item);
                        }
                    }
                    else if (qutype == 5)
                    { ArrangeMapHotSpots(imgHotSpot, item, QuestionID); }
                }
            }
        }

        protected void ArrangeMapHotSpots(ImageMap imgmap, ListItem item, int QuestionID)
        {
            RectangleHotSpot hotSpot;
            string[] leftright = item.Text.ToString().Split(',');
            hotSpot = new RectangleHotSpot();
            hotSpot.HotSpotMode = HotSpotMode.Navigate;
            hotSpot.AlternateText = item.Value.ToString();
            hotSpot.Left = Convert.ToInt32(leftright[0]);
            hotSpot.Right = Convert.ToInt32(leftright[2]);
            hotSpot.Top = Convert.ToInt32(leftright[1]);
            hotSpot.Bottom = Convert.ToInt32(leftright[3]);
            hotSpot.NavigateUrl = "javascript:setCordinator(" + QuestionID + "," + item.Value.ToString() + ");";
            imgmap.HotSpots.Add(hotSpot);

        }

        [WebMethod]
        public static void setCordinator(string QuestionID, string AnswerId)
        {
            _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(QuestionID)).FirstOrDefault().AnswerList.ToList().ForEach(u => u.UserAnswer = false);
            _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(QuestionID)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32(AnswerId)).FirstOrDefault().UserAnswer = true;
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
            _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.ToList().ForEach(u => u.UserAnswer = false);
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.Items[i].Selected == true)
                {
                    string value = chklst.Items[i].Value;
                    _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32(value)).FirstOrDefault().UserAnswer = true;
                }
            }
        }

        protected void chkboxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList chklst = (CheckBoxList)sender;
            string commandArguments = chklst.Attributes["commandArguments"].ToString();
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                string value = chklst.Items[i].Value;
                _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32(value)).FirstOrDefault().UserAnswer = chklst.Items[i].Selected;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (TimeAllSecondes > 0)
            {
                TimeAllSecondes = TimeAllSecondes - 1;
            }

            TimeSpan time_Span = TimeSpan.FromSeconds(TimeAllSecondes);
            hh = time_Span.Hours;
            mm = time_Span.Minutes;
            ss = time_Span.Seconds;
            Label2.Text = "  " + hh + ":" + mm + ":" + ss;
            if (time_Span == TimeSpan.Zero)
            {
                // ScriptManager.RegisterStartupScript(this, GetType(), "InvokeButton", "invokeButtonClick();", true);
                btnEndExam_Click(btnEndExam, null);
                // Response.Redirect("UserLogin.aspx");
            }
        }

        protected void lbDrag_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox chklst = (ListBox)sender;
            string commandArguments = chklst.Attributes["commandArguments"].ToString();
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                if (chklst.Items[i].Selected == true)
                {
                    string value = chklst.Items[i].Value;
                    _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32(value)).FirstOrDefault().UserAnswer = true;
                }
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            ListBox list1 = (ListBox)item.FindControl("lbDrag");
            ListBox list2 = (ListBox)item.FindControl("lbDrop");
            Label lbltxt = (Label)item.FindControl("lbltxt");
            string commandArguments = btn.Attributes["commandArguments"].ToString();
            lbltxt.Visible = false;
            if (list1.SelectedIndex >= 0)
            {
                for (int i = 0; i < list1.Items.Count; i++)
                {
                    if (list1.Items[i].Selected)
                    {
                        if (!arraylist1.Contains(list1.Items[i]))
                        {
                            arraylist1.Add(list1.Items[i]);
                        }
                        _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32((list1.Items[i].Value))).FirstOrDefault().UserAnswer = true;
                    }

                }
                for (int i = 0; i < arraylist1.Count; i++)
                {
                    if (!list2.Items.Contains(((ListItem)arraylist1[i])))
                    {
                        list2.Items.Add(((ListItem)arraylist1[i]));
                    }
                    list1.Items.Remove(((ListItem)arraylist1[i]));
                }
                list2.SelectedIndex = -1;
            }
            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please select atleast one in Listbox1 to move";
            }
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            ListBox list1 = (ListBox)item.FindControl("lbDrag");
            ListBox list2 = (ListBox)item.FindControl("lbDrop");
            Label lbltxt = (Label)item.FindControl("lbltxt");
            string commandArguments = btn.Attributes["commandArguments"].ToString();
            lbltxt.Visible = false;
            if (list2.SelectedIndex >= 0)
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    if (list2.Items[i].Selected)
                    {
                        if (!arraylist2.Contains(list2.Items[i]))
                        {
                            arraylist2.Add(list2.Items[i]);
                        }
                        _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32((list2.Items[i].Value))).FirstOrDefault().UserAnswer = false;
                    }

                }
                for (int i = 0; i < arraylist2.Count; i++)
                {
                    if (!list1.Items.Contains(((ListItem)arraylist2[i])))
                    {
                        list1.Items.Add(((ListItem)arraylist2[i]));
                    }
                    list2.Items.Remove(((ListItem)arraylist2[i]));
                }
                list1.SelectedIndex = -1;
            }
            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please select atleast one in Listbox2 to move";
            }

        }

        protected void btnEndExam_Click(object sender, EventArgs e)
        {
            if (_examqueanslist != null)
            {
                if (_examqueanslist.QuestionList != null)
                {
                    if (!_examqueanslist.QuestionList.Any(c => c.AnswerList.All(a => a.UserAnswer == false)))
                    {
                        int mrkcunt = _examqueanslist.QuestionList.Where(ql => ql.Mark == true).Count();
                        if (mrkcunt == 0)
                        {
                            flagMark = false;
                            foreach (var item in _examqueanslist.QuestionList)
                            {
                                var QuetionOrignalAns = _examqueanslist.QuestionList.Where(q => q.Question.Equals(item.Question)).FirstOrDefault().AnswerList.Where(ans => ans.RightAnswer.Equals(true)).ToList();
                                var QuetionUserAns = _examqueanslist.QuestionList.Where(q => q.Question.Equals(item.Question)).FirstOrDefault().AnswerList.Where(u => u.UserAnswer.Equals(true)).ToList();

                                bool a = CheckUserAnswer(QuetionOrignalAns, QuetionUserAns);
                                _examqueanslist.QuestionList.Where(q => q.Question.Equals(item.Question)).FirstOrDefault().UserResult = a;
                            }
                            Session["ExamList"] = _examqueanslist;
                            Response.Redirect("OnlineTestReport.aspx");
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Your time end now!');window.location ='OnlineTestReport.aspx';", true);
                        }
                        else
                        {
                            ShowMessage("Please give answer mark question and uncheck all mark question", MessageType.Warning);
                        }
                    }
                    else
                    {
                        ShowMessage("You have not answered all the questions", MessageType.Warning);
                    }
                }
            }
        }

        private bool CheckUserAnswer(List<BOQAnswer> list1, List<BOQAnswer> list2)
        {
            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                var data = list2.Where(z => z.AnswerId == list1[i].AnswerId).FirstOrDefault();
                if (data == null)
                    return false;
                if (list1[i].RightAnswer != list2[i].UserAnswer)
                    return false;
            }
            return true;
        }

        protected void btnCorrectAnswer_Click(object sender, EventArgs e)
        {
            foreach (DataListItem item in dlquesanswer.Items)
            {
                Panel pnlexplain = (Panel)item.FindControl("pnlexplain");
                pnlexplain.Visible = true;
            }

        }

        protected void chkmark_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var button = sender as CheckBox;
                var QuestionNo = Convert.ToInt32(button.ToolTip);
                _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionNo)).FirstOrDefault().Mark = Convert.ToBoolean(button.Checked);
            }
            catch
            {

            }
        }

        protected void btnReviewMark_Click(object sender, EventArgs e)
        {
            int mrkcunt = _examqueanslist.QuestionList.Where(ql => ql.Mark == true).Count();
            if (mrkcunt > 0)
            {
                flagMark = true;
                currentQuestionIndex = 0;
                _examqueanslist.QuestionList.Where(q => q.Mark.Equals(true)).ToList();
                GetExamDetail(_examqueanslist);
                btnprevious.Enabled = false;
                btnnext.Enabled = true;
            }
            else
            {
                ShowMessage("Sorry! no mark question found", MessageType.Info);
            }
        }

        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}