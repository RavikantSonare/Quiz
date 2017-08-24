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
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for ExamRun.xaml
    /// </summary>
    public partial class ExamRun : System.Windows.Controls.Page
    {
        int index = 0;
        List<Questions> _list = new List<Questions>();
        // TodoItem filelist = (TodoItem)Application.Current.Properties["test"];
        TodoItem filelist = new TodoItem();
        DispatcherTimer _timer;
        TimeSpan _time;
        ListBox dragSource = null;

        public ExamRun(TodoItem filelistitem)
        {
            InitializeComponent();
            try
            {
                filelist = filelistitem;
                _time = TimeSpan.FromSeconds(300);
                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    lblTimer.Content = _time.ToString("c");
                    if (_time == TimeSpan.Zero)
                    {
                        _timer.Stop();
                        btnEndExam.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        // NavigationService.Navigate(new ExamReport(_list.Where(z => z.userResult == true).Count(), _list.Count()));
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
                BindQuestionlist(_list);
                btnPrevious.IsEnabled = false;
                showQuestionNo(index + 1, _list.Count);
            }
            catch
            {

            }
        }

        private void BindQuestionlist(List<Questions> _qestlist)
        {
            listQuestion.ItemsSource = _qestlist.Skip(index).Take(1);
            listQuestionMark.ItemsSource = _qestlist.Skip(index).Take(1);
        }

        private void Decrypt(string inputFilePath, string outputfilePath)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                {
                    using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                        {
                            int data;
                            while ((data = cs.ReadByte()) != -1)
                            {
                                fsOutput.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }

        List<Questions> _quetionList = new List<Questions>();
        private List<Questions> bindQuestionListboxToList()
        {
            try
            {
                if (filelist != null)
                {
                    List<Answerlist> _answerlist = new List<Answerlist>();
                    List<RightAnswer> _rightAnswerlist = new List<RightAnswer>();
                    List<string> QuestionTypeList = new List<string>() { "Question(Single Choice)", "Question(Multi Choice)", "Question(Vacant)", "Question(Drag & Drop)", "Question(Hotspot)", "Question(Scenario)" };
                    List<string> AnswerCharList = new List<string>() { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J." };
                    string CommanStrflag = "Q", QuestionStr = string.Empty, AnswerStr = string.Empty, RightAnswerStr = string.Empty, ExpStr = string.Empty;
                    string QuestionImageStr = string.Empty, qtype = string.Empty;
                    int DoneQueStatus = 0, questionNo = 0;
                    string[] aas = null; string CurrrentStr = string.Empty;

                    string _imgbtnshow = string.Empty;
                    List<string> ImageTypeList = new List<string>() { "Refer to the exhibit", "Refer to the topology", "Refer to the Scenario" };

                    //Get the Input File Name and Extension
                    //string fileName = Path.GetFileNameWithoutExtension(filelist.Path);
                    //string fileExtension = Path.GetExtension(filelist.Path);

                    ////Build the File Path for the original (input) and the decrypted (output) file
                    //string input = filelist.Path;
                    //string output = fileName + "_dec" + fileExtension;

                    //if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\ExamReadfile\\" + output))
                    //{
                    //    File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "\\ExamReadfile\\" + output);
                    //}
                    //File.Copy(input, System.AppDomain.CurrentDomain.BaseDirectory + "\\ExamReadfile\\" + output);
                    ////Save the Input File, Decrypt it and save the decrypted file in output path.
                    ////FileUpload1.SaveAs(input);
                    //this.Decrypt(input, System.AppDomain.CurrentDomain.BaseDirectory + "\\ExamReadfile\\" + output);
                    //Document document = new Document(System.AppDomain.CurrentDomain.BaseDirectory + "\\ExamReadfile\\" + output);

                    Document document = new Document(filelist.Path);
                    int index = 1;
                    foreach (Spire.Doc.Section section in document.Sections)
                    {
                        //Get Each Paragraph of Section
                        foreach (Spire.Doc.Documents.Paragraph paragraph in section.Paragraphs)
                        {
                            //paragraph.ChildObjects.Clear();
                            //Get Each Document Object of Paragraph Items
                            DoneQueStatus++;
                            foreach (DocumentObject docObject in paragraph.ChildObjects)
                            {
                                CurrrentStr = paragraph.Text.Trim();
                                if (String.IsNullOrEmpty(CurrrentStr))
                                {
                                    if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                                    {
                                        string docname = System.IO.Path.GetFileNameWithoutExtension(filelist.Path);
                                        DocPicture pic = docObject as DocPicture;
                                        string filename = System.AppDomain.CurrentDomain.BaseDirectory + "ExamImage\\";
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

                                        String imgName = String.Format(filename + docname + "-Question" + questionNo + "-{0}.png", index);
                                        QuestionImageStr = imgName;
                                        //Save Image
                                        if (!File.Exists(imgName))
                                        {
                                            pic.Image.Save(imgName, System.Drawing.Imaging.ImageFormat.Png);
                                        }
                                        index++;
                                    }
                                }

                                if (!String.IsNullOrEmpty(CurrrentStr))
                                {
                                    if (QuestionTypeList.Contains(CurrrentStr))
                                    {
                                        CommanStrflag = "Q";
                                        qtype = CurrrentStr;
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
                                        if (!QuestionTypeList.Contains(CurrrentStr))
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
                                        _answerlist.Add(new Answerlist { Answer = CurrrentStr.Substring(2).Trim(), QuestionNo = questionNo });
                                        break;
                                    case "E":
                                        ExpStr += CurrrentStr + "\n";
                                        break;
                                }
                                //if (filePath.Length == section.Paragraphs.Count + 2 || DoneQueStatus >= 2)
                                //{
                                //    int qtype = 1; bool mode = true; bool ureslut = false;
                                //    if (aas.Length > 1)
                                //    {
                                //        qtype = 2;
                                //    }
                                //    if (filelist != null && filelist.Mode == "SM")
                                //    { mode = false; ureslut = true; }
                                //    _quetionList.Add(new Questions { QuestionNo = questionNo, Question = QuestionStr, Answerlist = _answerlist, RightAnswerlist = _rightAnswerlist, QuestionType = qtype, NoofAnswer = _answerlist.Count, Score = 1, userResult = ureslut, Explaination = ExpStr, ExamMode = mode, Mark = false });
                                //    CommanStrflag = "Q"; QuestionStr = string.Empty; AnswerStr = string.Empty; RightAnswerStr = string.Empty; ExpStr = string.Empty;
                                //    _answerlist = new List<Answerlist>(); _rightAnswerlist = new List<ExamSimulator.RightAnswer>();
                                //    questionNo++;
                                //}
                                //DoneQueStatus = 0;
                            }
                            if (paragraph.ChildObjects.Count == 0 && CurrrentStr != null)
                            {
                                bool mode = true; bool ureslut = false;

                                if (filelist != null && filelist.Mode == "SM")
                                { mode = false; ureslut = true; }
                                _quetionList.Add(new Questions { QuestionNo = questionNo, Question = QuestionStr, Image = QuestionImageStr, Answerlist = _answerlist, RightAnswerlist = _rightAnswerlist, QuestionType = qtype, NoofAnswer = _answerlist.Count, Score = 1, userResult = ureslut, Explaination = ExpStr, ExamMode = mode, Mark = false, ImageBtnShow = _imgbtnshow });
                                CommanStrflag = "Q"; QuestionStr = string.Empty; AnswerStr = string.Empty; RightAnswerStr = string.Empty; ExpStr = string.Empty; QuestionImageStr = string.Empty; CurrrentStr = string.Empty;
                                _answerlist = new List<Answerlist>(); _rightAnswerlist = new List<ExamSimulator.RightAnswer>(); _imgbtnshow = string.Empty;
                                questionNo++; index = 1;
                            }
                        }
                    }
                    //foreach (Section section in document.Sections)
                    //{
                    //    for (int i = 0; i < section.Body.ChildObjects.Count; i++)
                    //    {
                    //        if (section.Body.ChildObjects[i].DocumentObjectType == DocumentObjectType.Paragraph)
                    //        {
                    //            if (String.IsNullOrEmpty((section.Body.ChildObjects[i] as Paragraph).Text.Trim()))
                    //            {
                    //                section.Body.ChildObjects.Remove(section.Body.ChildObjects[i]);
                    //                i--;
                    //            }
                    //        }

                    //    }
                    //}
                    //string result = "result.docx";
                    //document.SaveToFile(result, FileFormat.Docx2010);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    BindQuestionlist(_list);
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
                    BindQuestionlist(_list);
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

                //var QuetionOrignalAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().RightAnswerlist;
                //var QuetionUserAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList();
                //int i = 0;
                //foreach (var item in QuetionOrignalAns.ToList())
                //{
                //    if (item.Rightanswer == QuetionUserAns[i].UserAnwer && item.Rightanswer)
                //    {
                //        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = true;
                //        break;
                //    }
                //    else
                //    {
                //        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = false;
                //    }
                //    i++;
                //}
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
                _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnwer = button.IsChecked.Value;

                //var QuetionOrignalAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().RightAnswerlist;
                //var QuetionUserAns = _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.ToList();
                //int i = 0;
                //foreach (var item in QuetionOrignalAns.ToList())
                //{
                //    if (item.Rightanswer == QuetionUserAns[i].UserAnwer && item.Rightanswer)
                //    {
                //        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = true;
                //    }
                //    else
                //    {
                //        _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().userResult = false;
                //    }
                //    i++;
                //}
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
                _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Mark = Convert.ToBoolean(button.IsChecked);
            }
            catch
            {

            }
        }

        private void btnEndExam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in _list)
                {
                    var QuetionOrignalAns = _list.Where(q => q.QuestionNo.Equals(item.QuestionNo)).FirstOrDefault().RightAnswerlist;
                    var QuetionUserAns = _list.Where(q => q.QuestionNo.Equals(item.QuestionNo)).FirstOrDefault().Answerlist.ToList();//.Select(a => new { a.UserAnwer}).ToList();

                    bool a = CheckUserAnswer(QuetionOrignalAns, QuetionUserAns);
                    _list.Where(q => q.QuestionNo.Equals(item.QuestionNo)).FirstOrDefault().userResult = a;
                }
                NavigationService.Navigate(new ExamReport(_list.Where(z => z.userResult == true).Count(), _list.Count()));
            }
            catch
            {

            }
        }

        private bool CheckUserAnswer(List<RightAnswer> list1, List<Answerlist> list2)
        {

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Rightanswer != list2[i].UserAnwer)
                    return false;
            }

            return true;
        }

        private void btnReviewMarkExam_Click(object sender, RoutedEventArgs e)
        {
            _list = _list.Where(q => q.Mark.Equals(true)).ToList();
            BindQuestionlist(_list);
            btnPrevious.IsEnabled = false;
            showQuestionNo(index + 1, _list.Count);
        }

        private void btnCorrectAnswer_Click(object sender, RoutedEventArgs e)
        {
           
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
                //System.Windows.Controls.Primitives.Popup target = (System.Windows.Controls.Primitives.Popup)myDataTemplate.FindName("MyPopup", myContentPresenter);
                //target.IsOpen = true;
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
            _list.Where(q => q.QuestionNo.Equals(QuestionNo)).FirstOrDefault().Answerlist.Where(f => f.Answer.Equals(UserAns)).FirstOrDefault().UserAnwer = true;
        }

        private void btnPauseTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            MessageBox.Show("Your exam has been paused. Click 'OK' to continue.", "Paused", MessageBoxButton.OK, MessageBoxImage.Information);
            _timer.Start();
        }
    }


    class Questions
    {
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public string Image { get; set; }
        public List<Answerlist> Answerlist { get; set; }
        public List<RightAnswer> RightAnswerlist { get; set; }
        public string QuestionType { get; set; }
        public int NoofAnswer { get; set; }
        public decimal Score { get; set; }
        public bool userResult { get; set; }
        public string Explaination { get; set; }
        public bool ExamMode { get; set; }
        public bool Mark { get; set; }
        public string ImageBtnShow { get; set; }
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
