﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Collections;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for ExamRun.xaml
    /// </summary>
    public partial class ExamRun : System.Windows.Controls.Page
    {
        int index = 0;
        List<Questions> _list = new List<Questions>();
        TodoItem filelist = (TodoItem)Application.Current.Properties["test"];
        DispatcherTimer _timer;
        TimeSpan _time;
        ListBox dragSource = null;

        public ExamRun()
        {
            InitializeComponent();

            try
            {
                _time = TimeSpan.FromSeconds(300);
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    lblTimer.Content = _time.ToString("c");
                    if (_time == TimeSpan.Zero)
                    {
                        _timer.Stop();
                        NavigationService.Navigate(new ExamReport(_list.Where(z => z.userResult == true).Count(), _list.Count()));
                    }
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);

                _timer.Start();
            }
            catch
            {

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _list = bindQuestionListboxToList();
                listQuestion.ItemsSource = _list.Skip(index).Take(1);
                btnPrevious.IsEnabled = false;
                showQuestionNo(index + 1, _list.Count);
                if (_list.Count < 2)
                {
                    btnNext.IsEnabled = false;
                    btnPrevious.IsEnabled = false;
                }
            }
            catch
            {

            }
        }

        List<Questions> _quetionList = new List<Questions>();
        private List<Questions> bindQuestionListboxToList()
        {
            try
            {
                string[] filePath;
                if (filelist != null)
                {
                    filePath = File.ReadAllLines(filelist.Path);
                }
                else
                {
                    filePath = File.ReadAllLines(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Examfile\\Quiz1.txt");
                }

                List<Answerlist> _answerlist = new List<Answerlist>();
                List<RightAnswer> _rightAnswerlist = new List<RightAnswer>();
                List<string> AnswerCharList = new List<string>() { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J." };
                string CommanStrflag = "Q", QuestionStr = string.Empty, AnswerStr = string.Empty, RightAnswerStr = string.Empty, ExpStr = string.Empty;
                int DoneQueStatus = 0, questionNo = 0;
                string[] aas = null;

                for (int i = 0; i < filePath.Length; i++)
                {
                    string CurrrentStr = filePath[i].Trim();
                    if (String.IsNullOrEmpty(CurrrentStr))
                    {
                        DoneQueStatus++;
                        continue;
                    }

                    if (!String.IsNullOrEmpty(CurrrentStr))
                    {
                        if (CurrrentStr == "Question")
                        {
                            CommanStrflag = "Q";
                            if (questionNo == 0)
                                questionNo++;
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
                            if (CurrrentStr != "Question")
                            {
                                QuestionStr += CurrrentStr + "\n";
                            }
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
                                        if (filelist != null && filelist.Mode == "SM")
                                        {
                                            _answerlist[j].UserAnwer = true;
                                        }
                                    }
                                    else _rightAnswerlist.Add(new RightAnswer { Rightanswer = false });
                                }
                            }
                            break;
                        case "A":
                            _answerlist.Add(new Answerlist { Answer = CurrrentStr.Trim(), QuestionNo = questionNo });
                            break;
                        case "E":
                            ExpStr += CurrrentStr + "\n";
                            break;

                    }
                    if (filePath.Length == i + 2 || DoneQueStatus >= 2)
                    {
                        int qtype = 1; bool mode = true; bool ureslut = false;
                        if (aas.Length > 1)
                        {
                            qtype = 2;
                        }
                        if (filelist != null && filelist.Mode == "SM")
                        { mode = false; ureslut = true; }
                        _quetionList.Add(new Questions { QuestionNo = questionNo, Question = QuestionStr, Answerlist = _answerlist, RightAnswerlist = _rightAnswerlist, QuestionType = qtype, NoofAnswer = _answerlist.Count, Score = 1, userResult = ureslut, Explaination = ExpStr, ExamMode = mode });
                        CommanStrflag = "Q"; QuestionStr = string.Empty; AnswerStr = string.Empty; RightAnswerStr = string.Empty; ExpStr = string.Empty;
                        _answerlist = new List<Answerlist>(); _rightAnswerlist = new List<ExamSimulator.RightAnswer>();
                        questionNo++;
                    }
                    DoneQueStatus = 0;
                }
            }
            catch
            {

            }
            return _quetionList;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_list.Count - 1 > index)
                {
                    index++;
                    btnPrevious.IsEnabled = true;
                    listQuestion.ItemsSource = _list.Skip(index).Take(1);
                    showQuestionNo(index + 1, _list.Count);
                }
                if (_list.Count - 1 == index)
                {
                    btnPrevious.IsEnabled = true;
                    btnNext.IsEnabled = false;
                }
            }
            catch
            {

            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (index > 0)
                {
                    index--;
                    btnNext.IsEnabled = true;
                    listQuestion.ItemsSource = _list.Skip(index).Take(1);
                    showQuestionNo(index + 1, _list.Count);
                }
                if (index == 0)
                {
                    btnNext.IsEnabled = true;
                    btnPrevious.IsEnabled = false;
                }
            }
            catch
            {

            }
        }

        private void showQuestionNo(int qno, int totalques)
        {
            try
            {
                lblQuestionOutof.Content = totalques.ToString();
                lblQuestionNo.Content = qno.ToString();

            }
            catch
            {

            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as RadioButton;
                var QuestionNo = Convert.ToInt32(button.TabIndex);
                var UserAns = button.Tag.ToString();
                _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList().ForEach(n => n.UserAnwer = false);
                _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnwer = true;

                var QuetionOrignalAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().RightAnswerlist;
                var QuetionUserAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList();
                int i = 0;
                foreach (var item in QuetionOrignalAns.ToList())
                {
                    if (item.Rightanswer == QuetionUserAns[i].UserAnwer && item.Rightanswer)
                    {
                        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = true;
                        break;
                    }
                    else
                    {
                        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = false;
                    }
                    i++;
                }
            }
            catch
            {

            }
        }

        private void Checkbox_checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as CheckBox;
                var QuestionNo = Convert.ToInt32(button.TabIndex);
                var UserAns = button.Tag.ToString();
                //  _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList().ForEach(n => n.UserAnwer = false);
                _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnwer = true;

                var QuetionOrignalAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().RightAnswerlist;
                var QuetionUserAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList();
                int i = 0;
                foreach (var item in QuetionOrignalAns.ToList())
                {
                    if (item.Rightanswer == QuetionUserAns[i].UserAnwer && item.Rightanswer)
                    {
                        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = true;
                        break;
                    }
                    else
                    {
                        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = false;
                    }
                    i++;
                }
            }
            catch
            {

            }
        }

        private void btnEndExam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new ExamReport(_list.Where(z => z.userResult == true).Count(), _list.Count()));
            }
            catch
            {

            }
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

                if (data != null)
                {
                    DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
                }
            }
            catch
            {

            }
        }

        int OrderingListNo = 0;
        private void lbDrop_Drop(object sender, DragEventArgs e)
        {
            try
            {
                Answerlist droppedData = e.Data.GetData(typeof(Answerlist)) as Answerlist;
                var obj = _list.Where(q => q.QuestionNo.Equals(droppedData.QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(droppedData.Answer)).FirstOrDefault();
                obj.UserAnwer = true; obj.OrderingList = OrderingListNo;
                OrderingListNo++;
                foreach (var item in listQuestion.Items)
                {
                    var _Container = listQuestion.ItemContainerGenerator
                        .ContainerFromItem(item);
                    var _Children = AllChildren(_Container);
                    if (_Children.Count > 0)
                    {
                        var _control = _Children.OfType<ListBox>().First(x => x.Name.Equals("lbDrag")); _control.Items.Refresh();
                        _control = _Children.OfType<ListBox>().First(x => x.Name.Equals("lbDrop"));
                        _control.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("OrderingList", System.ComponentModel.ListSortDirection.Ascending));
                        _control.Items.Refresh();
                    }
                }
            }
            catch
            {

            }
        }

        private void lbDrag_Drop(object sender, DragEventArgs e)
        {
            try
            {
                Answerlist droppedData = e.Data.GetData(typeof(Answerlist)) as Answerlist;
                var obj = _list.Where(q => q.QuestionNo.Equals(droppedData.QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(droppedData.Answer)).FirstOrDefault();
                obj.UserAnwer = false; obj.OrderingList = OrderingListNo;
                OrderingListNo--;
                foreach (var item in listQuestion.Items)
                {
                    var _Container = listQuestion.ItemContainerGenerator
                        .ContainerFromItem(item);
                    var _Children = AllChildren(_Container);
                    if (_Children.Count > 0)
                    {
                        var _control = _Children.OfType<ListBox>().First(x => x.Name.Equals("lbDrag")); _control.Items.Refresh();
                        _control = _Children.OfType<ListBox>().First(x => x.Name.Equals("lbDrop"));
                        _control.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("OrderingList", System.ComponentModel.ListSortDirection.Ascending));
                        _control.Items.Refresh();
                    }
                }
            }
            catch
            {

            }
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control>();
            try
            {
                if (parent != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                    {
                        var _Child = VisualTreeHelper.GetChild(parent, i);
                        if (_Child is Control)
                            _List.Add(_Child as Control);
                        _List.AddRange(AllChildren(_Child));
                    }
                }
            }
            catch { }
            return _List;
        }

        #region GetDataFromListBox(ListBox,Point)
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }
        #endregion
    }


    class Questions
    {
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public List<Answerlist> Answerlist { get; set; }
        public List<RightAnswer> RightAnswerlist { get; set; }
        public int QuestionType { get; set; }
        public int NoofAnswer { get; set; }
        public decimal Score { get; set; }
        public bool userResult { get; set; }
        public string Explaination { get; set; }
        public bool ExamMode { get; set; }
    }

    class Answerlist
    {
        public string Answer { get; set; }
        public bool UserAnwer { get; set; }
        public int QuestionNo { get; set; }
        public int OrderingList { get; set; } = 0;
    }

    class RightAnswer { public bool Rightanswer { get; set; } }
}
