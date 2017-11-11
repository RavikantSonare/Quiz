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
        #endregion

        static int hh, mm, ss;
        static double TimeAllSecondes;

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
                            string examid = Common.Decrypt(HttpUtility.UrlDecode(Request.QueryString["exmid"]));
                            _examqueanslist = GetEQAList(examid, Request.QueryString["tstmd"]);
                            GetExamDetail(_examqueanslist);
                            TimeAllSecondes = Convert.ToDouble(_examqueanslist.TestTime);
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
                int QuestionID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "QAId"));
                HiddenField hfTestMode = (HiddenField)e.Item.FindControl("hfTestMode");
                RadioButtonList rdbtnAnswerList = (RadioButtonList)e.Item.FindControl("rdbtnAnswerList");
                CheckBoxList chkboxAnswerList = (CheckBoxList)e.Item.FindControl("chkboxAnswerList");
                ListBox lbDrag = (ListBox)e.Item.FindControl("lbDrag");
                ListBox lbDrop = (ListBox)e.Item.FindControl("lbDrop");
                ImageMap imgHotSpot = (ImageMap)e.Item.FindControl("imgHotSpot");
                imgHotSpot.ImageUrl = "http://quizmerchant.mobi96.org/resource/" + _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().Resource;
                var listanswer = _examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().AnswerList;
                for (int i = 0; i < listanswer.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = listanswer[i].Answer;
                    item.Value = listanswer[i].AnswerId.ToString();
                    if (hfTestMode.Value == "SM")
                    {
                        item.Selected = Convert.ToBoolean(listanswer[i].RightAnswer.Equals("1") ? true : false);
                    }
                    else if (hfTestMode.Value == "TM")
                    {
                        item.Selected = Convert.ToBoolean(listanswer[i].UserAnswer);
                    }
                    rdbtnAnswerList.Items.Add(item);
                    chkboxAnswerList.Items.Add(item);
                    if (item.Selected)
                    {
                        lbDrop.Items.Add(item);
                    }
                    else
                    {
                        lbDrag.Items.Add(item);
                    }
                    if (_examqueanslist.QuestionList.Where(q => q.QAId.Equals(QuestionID)).FirstOrDefault().QuestionTypeId == 5)
                    { ArrangeMapHotSpots(imgHotSpot, item, QuestionID); }
                }
            }
        }

        protected void ArrangeMapHotSpots(ImageMap imgmap, ListItem item, int QuestionID)
        {
            //PlaceHolder2.Controls.Add(new Literal
            //{
            //    Text = @"<area shape=""rect"" id='imageMapMachineNumber" + item.Value + "' href='http://www.w3schools.com/TAGS/sun.htm' coords='" + item.Text.ToString() + "'></area>"
            //});
            RectangleHotSpot hotSpot;
            //DataTable ImageMapDT = EzdrojeDB.ImageMapCoordinates(voivodshipId); // get data form DB   
            //foreach (DataRow dr in ImageMapDT.Rows)
            //{
            // string[] val = item.Text.ToString().Split(',');
            string[] leftright = item.Text.ToString().Split(',');
            hotSpot = new RectangleHotSpot();
            hotSpot.HotSpotMode = HotSpotMode.Navigate;
            hotSpot.AlternateText = "alt_text";
            hotSpot.Left = Convert.ToInt32(leftright[0]);
            hotSpot.Right = Convert.ToInt32(leftright[2]);
            hotSpot.Top = Convert.ToInt32(leftright[1]);
            hotSpot.Bottom = Convert.ToInt32(leftright[3]);
            hotSpot.NavigateUrl = "javascript:setCordinator(" + QuestionID + "," + item.Value.ToString() + ");";
            imgmap.HotSpots.Add(hotSpot);
            // }
        }

        [WebMethod]
        public static void setCordinator(string QuestionID, string AnswerId)
        {
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
                if (chklst.Items[i].Selected == true)
                {
                    string value = chklst.Items[i].Value;
                    _examqueanslist.QuestionList.Where(q => q.QAId == Convert.ToUInt32(commandArguments)).FirstOrDefault().AnswerList.Where(f => f.AnswerId == Convert.ToUInt32(value)).FirstOrDefault().UserAnswer = true;
                }
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
            if (Timer1.Interval <= 0)
            {
                Label2.Text = "TimeOut!";
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
    }
}