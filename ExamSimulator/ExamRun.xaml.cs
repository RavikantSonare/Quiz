using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.IO;
using System.Data;
using System.Windows.Threading;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ExamSimulator.BOLayer;
namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for ExamRun.xaml
    /// </summary>
    public partial class ExamRun : System.Windows.Controls.Page
    {
        #region Global Variables
        int currentQuestionIndex = 0;
        BOExamManage _list = new BOExamManage();
        TodoItem filelist = new TodoItem();
        DispatcherTimer _timer;
        TimeSpan _time;
        ListBox dragSource = null;
        bool flagMark = false;
        #endregion

        public ExamRun(TodoItem filelistitem)
        {
            InitializeComponent();
            try
            {
                filelist = filelistitem;
                if (!filelistitem.Mode.Equals("SM"))
                {
                    _time = TimeSpan.FromSeconds(filelistitem.Examtime * 60);
                    _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                    {
                        lblTimer.Content = _time.ToString("c");
                        if (_time == TimeSpan.Zero)
                        {
                            _timer.Stop();
                            btnEndExamEndTimer.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        }
                        _time = _time.Add(TimeSpan.FromSeconds(-1));
                    }, Application.Current.Dispatcher);
                    _timer.Start();
                }
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
                BindQuestionlist(_list);
                btnPrevious.IsEnabled = false;
            }
            catch
            {

            }
        }

        private void BindQuestionlist(BOExamManage _qestlist)
        {
            if (flagMark)
            {
                listQuestion.ItemsSource = _qestlist.QuestionList.Where(f => f.Mark).Skip(currentQuestionIndex).Take(1);
                listQuestionMark.ItemsSource = _qestlist.QuestionList.Where(f => f.Mark).Skip(currentQuestionIndex).Take(1);
                showQuestionNo(currentQuestionIndex + 1, _qestlist.QuestionList.Where(f => f.Mark).ToList().Count);
            }
            else
            {
                listQuestion.ItemsSource = _qestlist.QuestionList.Skip(currentQuestionIndex).Take(1);
                listQuestionMark.ItemsSource = _qestlist.QuestionList.Skip(currentQuestionIndex).Take(1);
                showQuestionNo(currentQuestionIndex + 1, _qestlist.QuestionList.Count);
            }
        }

        private BOExamManage bindQuestionListboxToList()
        {
            BOExamManage _examqueanslist = new BOExamManage();
            try
            {
                if (filelist != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filelist.Path);
                    string fileExtension = ".json";

                    string input = filelist.Path;
                    string output = fileName + fileExtension;

                    if (!Directory.Exists(Common.UserDataFolder))
                    {
                        File.Delete(Common.UserDataFolder + output);
                    }
                    Common.Decrypt(input, Common.UserDataFolder + output);
                    var json = File.ReadAllText(Common.UserDataFolder + output);
                    _examqueanslist = JsonConvert.DeserializeObject<BOExamManage>(json);
                    if (filelist.Mode == "SM")
                    {
                        btnCorrectAnswer.Visibility = Visibility.Visible;
                        _examqueanslist.QuestionList.ForEach(e => e.ExamMode = false);
                        // _examqueanslist.QuestionList.Where(q => q.IsActive.Equals(false)).ToList().ForEach(b => b.AnswerList.Where(a => a.RightAnswer.Equals(true)).ToList().ForEach(r => r.UserAnswer = true));
                    }
                    else
                    {
                        stpnlTimer.Visibility = Visibility.Visible;
                        _examqueanslist.QuestionList.ForEach(e => e.ExamMode = true);
                        _examqueanslist = Shuffle(_examqueanslist);
                        if (!string.IsNullOrEmpty(_examqueanslist.TestOption))
                        {
                            var questinlist = _examqueanslist.QuestionList.Take(Convert.ToInt32(_examqueanslist.TestOption)).ToList();
                            _examqueanslist.QuestionList.Clear();
                            _examqueanslist.QuestionList = questinlist;
                        }
                    }
                    //Delete the original (input) and the encrypted (output) file.
                    File.Delete(Common.UserDataFolder + output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return _examqueanslist;
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flagMark)
                {
                    if (_list.QuestionList.Where(f => f.Mark).ToList().Count - 1 > currentQuestionIndex)
                    {
                        currentQuestionIndex++;
                        btnPrevious.IsEnabled = true;
                        BindQuestionlist(_list);
                        //showQuestionNo(currentQuestionIndex + 1, _list.QuestionList.Where(f => f.Mark).ToList().Count);
                    }
                    if (_list.QuestionList.Where(f => f.Mark).ToList().Count - 1 == currentQuestionIndex)
                    {
                        BindQuestionlist(_list);
                        btnPrevious.IsEnabled = true;
                        btnNext.IsEnabled = false;
                    }
                }
                else
                {
                    if (_list.QuestionList.Count - 1 > currentQuestionIndex)
                    {
                        currentQuestionIndex++;
                        btnPrevious.IsEnabled = true;
                        BindQuestionlist(_list);
                        // showQuestionNo(currentQuestionIndex + 1, _list.QuestionList.Count);
                    }
                    if (_list.QuestionList.Count - 1 == currentQuestionIndex)
                    {
                        BindQuestionlist(_list);
                        btnPrevious.IsEnabled = true;
                        btnNext.IsEnabled = false;
                    }
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
                if (flagMark)
                {
                    if (currentQuestionIndex > 0)
                    {
                        currentQuestionIndex--;
                        btnNext.IsEnabled = true;
                        BindQuestionlist(_list);
                        // showQuestionNo(currentQuestionIndex + 1, _list.QuestionList.Where(f => f.Mark).ToList().Count);
                    }
                    if (currentQuestionIndex == 0)
                    {
                        btnNext.IsEnabled = true;
                        btnPrevious.IsEnabled = false;
                    }
                }
                else
                {
                    if (currentQuestionIndex > 0)
                    {
                        currentQuestionIndex--;
                        btnNext.IsEnabled = true;
                        BindQuestionlist(_list);
                        //  showQuestionNo(currentQuestionIndex + 1, _list.QuestionList.Count);
                    }
                    if (currentQuestionIndex == 0)
                    {
                        btnNext.IsEnabled = true;
                        btnPrevious.IsEnabled = false;
                    }
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
                _list.QuestionList.Where(q => q.QAId.Equals(QuestionNo)).FirstOrDefault().AnswerList.ToList().ForEach(n => n.UserAnswer = false);
                _list.QuestionList.Where(q => q.QAId.Equals(QuestionNo)).FirstOrDefault().AnswerList.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnswer = true;

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
                _list.QuestionList.Where(q => q.QAId.Equals(QuestionNo)).FirstOrDefault().AnswerList.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnswer = button.IsChecked.Value;
            }
            catch
            {

            }
        }

        private void checkMark_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as CheckBox;
                var QuestionNo = Convert.ToInt32(button.TabIndex);
                _list.QuestionList.Where(q => q.QAId.Equals(QuestionNo)).FirstOrDefault().Mark = Convert.ToBoolean(button.IsChecked);
                int mrkcunt = _list.QuestionList.Where(ql => ql.Mark == true).Count();
                if (mrkcunt == 0)
                {
                    flagMark = false;
                    BindQuestionlist(_list);
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
                if (!_list.QuestionList.Any(c => c.AnswerList.All(a => a.UserAnswer == false)))
                {
                    int mrkcunt = _list.QuestionList.Where(ql => ql.Mark == true).Count();
                    if (mrkcunt == 0)
                    {
                        foreach (var item in _list.QuestionList)
                        {
                            var QuetionOrignalAns = _list.QuestionList.Where(q => q.QAId.Equals(item.QAId)).FirstOrDefault().AnswerList.Where(ans => ans.RightAnswer.Equals(true)).ToList();
                            var QuetionUserAns = _list.QuestionList.Where(q => q.QAId.Equals(item.QAId)).FirstOrDefault().AnswerList.Where(u => u.UserAnswer.Equals(true)).ToList();

                            bool a = CheckUserAnswer(QuetionOrignalAns, QuetionUserAns);
                            _list.QuestionList.Where(q => q.QAId.Equals(item.QAId)).FirstOrDefault().UserResult = a;
                        }
                        NavigationService.Navigate(new ExamReport(_list.QuestionList.Where(z => z.UserResult == true).Count(), _list.QuestionList.Count(), _list.PassingPercentage, _list.SecondCategory + " " + _list.ExamCode));
                    }
                    else
                    {
                        MessageBox.Show("Please give answer mark question and uncheck all mark question", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("You have not answered all the questions", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {

            }
        }

        private void btnEndExamEndTimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in _list.QuestionList)
                {
                    var QuetionOrignalAns = _list.QuestionList.Where(q => q.QAId.Equals(item.QAId)).FirstOrDefault().AnswerList.Where(ans => ans.RightAnswer.Equals(true)).ToList();
                    var QuetionUserAns = _list.QuestionList.Where(q => q.QAId.Equals(item.QAId)).FirstOrDefault().AnswerList.Where(u => u.UserAnswer.Equals(true)).ToList();

                    bool a = CheckUserAnswer(QuetionOrignalAns, QuetionUserAns);
                    _list.QuestionList.Where(q => q.QAId.Equals(item.QAId)).FirstOrDefault().UserResult = a;
                }
                NavigationService.Navigate(new ExamReport(_list.QuestionList.Where(z => z.UserResult == true).Count(), _list.QuestionList.Count(), _list.PassingPercentage, _list.SecondCategory + " " + _list.ExamCode));

            }
            catch
            {

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

        //private bool CheckUserAnswer(List<RightAnswer> list1, List<Answerlist> list2)
        //{
        //    if (list1.Count != list2.Count)
        //        return false;

        //    for (int i = 0; i < list1.Count; i++)
        //    {
        //        if (list1[i].Rightanswer != list2[i].UserAnwer)
        //            return false;
        //    }
        //    return true;
        //}

        private void btnReviewMarkExam_Click(object sender, RoutedEventArgs e)
        {
            int mrkcunt = _list.QuestionList.Where(ql => ql.Mark == true).Count();
            if (mrkcunt > 0)
            {
                flagMark = true;
                currentQuestionIndex = 0;
                //_list = _list.QuestionList.Where(q => q.Mark.Equals(true)).ToList();
                _list.QuestionList.Where(q => q.Mark.Equals(true)).ToList();
                BindQuestionlist(_list);
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = true;
                //showQuestionNo(currentQuestionIndex + 1, _list.QuestionList.Count);
            }
            else
            {
                MessageBox.Show("Sorry! no mark question found", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCorrectAnswer_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in listQuestion.Items)
            {
                ListBoxItem container = listQuestion.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                ListBoxItem myListBoxItem = (ListBoxItem)(listQuestion.ItemContainerGenerator.ContainerFromIndex(0));
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Border boderCorrectAnswer = (Border)myDataTemplate.FindName("brdrCorrectAnswer", myContentPresenter);
                boderCorrectAnswer.Visibility = Visibility.Visible;
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
                BOQAnswer droppedData = e.Data.GetData(typeof(BOQAnswer)) as BOQAnswer;
                var obj = _list.QuestionList.Where(q => q.QAId.Equals(droppedData.QuestionId)).FirstOrDefault().AnswerList.Where(f => f.Answer.Equals(droppedData.Answer)).FirstOrDefault();
                obj.UserAnswer = true; obj.OrderingList = OrderingListNo;
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
                BOQAnswer droppedData = e.Data.GetData(typeof(BOQAnswer)) as BOQAnswer;
                var obj = _list.QuestionList.Where(q => q.QAId.Equals(droppedData.QuestionId)).FirstOrDefault().AnswerList.Where(f => f.Answer.Equals(droppedData.Answer)).FirstOrDefault();
                obj.UserAnswer = false; obj.OrderingList = OrderingListNo;
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
        private static object GetDataFromListBox(ListBox source, System.Windows.Point point)
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

        private void btnExhibit_Click(object sender, EventArgs e)
        {
            foreach (var item in listQuestion.Items)
            {
                ListBoxItem container = listQuestion.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                ListBoxItem myListBoxItem = (ListBoxItem)(listQuestion.ItemContainerGenerator.ContainerFromIndex(0));
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Button target = (Button)myDataTemplate.FindName("btnExhibit", myContentPresenter);
                ExhibitImage frmexhibit = new ExhibitImage(Convert.ToString(target.CommandParameter), Convert.ToString(target.Content));
                frmexhibit.Owner = Window.GetWindow(this);
                frmexhibit.ShowDialog();
            }
        }

        private void btnTopology_Click(object sender, EventArgs e)
        {
            foreach (var item in listQuestion.Items)
            {
                ListBoxItem container = listQuestion.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                ListBoxItem myListBoxItem = (ListBoxItem)(listQuestion.ItemContainerGenerator.ContainerFromIndex(0));
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Button target = (Button)myDataTemplate.FindName("btnTopology", myContentPresenter);
                ExhibitImage frmexhibit = new ExhibitImage(Convert.ToString(target.CommandParameter), Convert.ToString(target.Content));
                frmexhibit.Owner = Window.GetWindow(this);
                frmexhibit.ShowDialog();
            }
        }

        private void btnScenario_Click(object sender, EventArgs e)
        {
            foreach (var item in listQuestion.Items)
            {
                ListBoxItem container = listQuestion.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                ListBoxItem myListBoxItem = (ListBoxItem)(listQuestion.ItemContainerGenerator.ContainerFromIndex(0));
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Button target = (Button)myDataTemplate.FindName("btnScenario", myContentPresenter);
                ExhibitImage frmexhibit = new ExhibitImage(Convert.ToString(target.CommandParameter), Convert.ToString(target.Content));
                frmexhibit.Owner = Window.GetWindow(this);
                frmexhibit.ShowDialog();
            }
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            var rect = sender as System.Windows.Shapes.Path;
            rect.Fill = Brushes.Gray;
            rect.StrokeThickness = 3;
            rect.Stroke = Brushes.Orange;
            rect.Opacity = .25d;
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            var rect = sender as System.Windows.Shapes.Path;
            rect.Fill = Brushes.Transparent;
            rect.StrokeThickness = 2;
            rect.Stroke = Brushes.Goldenrod;
            rect.Opacity = 1d;
        }

        private void Rectangle_MouseLeftButtonup(object sender, MouseEventArgs e)
        {
            var rect = sender as System.Windows.Shapes.Path;
            rect.Fill = Brushes.Gray;
            rect.StrokeThickness = 3;
            rect.Opacity = .35d;
            var QuestionNo = Convert.ToInt32(rect.ToolTip);
            var UserAns = rect.Tag.ToString();
            _list.QuestionList.Where(q => q.QAId.Equals(QuestionNo)).FirstOrDefault().AnswerList.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnswer = true;
        }
    }

}
