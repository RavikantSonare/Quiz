using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Net;
using System.Diagnostics;
using System.Data;
using ExamSimulator.BOLayer;
using ExamSimulator.BALayer;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BOUser _bouser = (BOUser)Application.Current.Properties["Bouser"];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BindFileListBox();
        }


        private void BindFileListBox()
        {
            List<TodoItem> _exsitingExamlist = new List<TodoItem>();
            String[] files = null;
            if (Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\"))
            {
                var allowedExtensions = new[] { ".doc", ".docx" };
                var filesss = Directory
                    .GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\")
                    .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
                    .ToList();
                files = filesss.ToArray(); //Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\", "*.docx", SearchOption.AllDirectories);
            }
            if (files != null)
            {
                foreach (var item in files)
                {
                    _exsitingExamlist.Add(new TodoItem() { Title = System.IO.Path.GetFileNameWithoutExtension(item), Path = item });
                }
            }

            BAExamManage _baexmmng = new BAExamManage();
            List<BOExamManage> _boexammng = new List<BOExamManage>();
            _boexammng = _baexmmng.SelectExamDetail("GetExWithUid", 3);

            List<UserExamList> _userExamlist = new List<UserExamList>();

            for (int i = 0; i < _boexammng.Count; i++)
            {
                if (_boexammng[i].SecondCategory + "-" + _boexammng[i].ExamCode == _exsitingExamlist[i].Title)
                {
                    _userExamlist.Add(new UserExamList { CategoryName = _boexammng[i].SecondCategory, ExamCodeList = new List<ExamCodelist>() { new ExamCodelist { ExamCode = _boexammng[i].ExamCode, Title = _exsitingExamlist[i].Title, Path = _exsitingExamlist[i].Path, IsActive = true } } });
                }
                else
                { _userExamlist.Add(new UserExamList { CategoryName = _boexammng[i].SecondCategory, ExamCodeList = new List<ExamCodelist>() { new ExamCodelist { ExamCode = _boexammng[i].ExamCode, Title = "", Path = "", IsActive = false } } }); }
            }
            var _userExamFileList = from p in _userExamlist
                                    group p.ExamCodeList by p.CategoryName into g
                                    select new { SecondCategory = g.Key, ExamCodeList = g.ToList() };
            listFile.ItemsSource = _userExamFileList;
        }

        private void TriggerClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TriggerMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            string fileName = string.Empty;
            var button = sender as Button;
            var Examcode = Convert.ToString(button.CommandParameter);
            if (Examcode == "300-120")
            {
                fileName = "Cisco-300-120.docx";
            }
            else if (Examcode == "302-120")
            {
                fileName = "Cisco-302-120.docx";// Replace Your Filename with your required filename
            }
            else
            {
                fileName = "Cisco-Math.docx";
            }

            // Process.Start("http://quizuser.mobi96.org/ExamSimulator/Cisco-302.docx");
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://quizuser.mobi96.org/ExamSimulator/Cisco-302.docx", @"D:\Work\Project\ExamSimulator\bin\Debug\Examfile\" + fileName);
        }

        private void btnExamCode_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var filename = button.CommandParameter;
        }
    }

    public class TodoItem
    {
        public string ModeHeading { get; set; }
        public string Mode { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }

    public class UserExamList
    {
        public string CategoryName { get; set; }
        public List<ExamCodelist> ExamCodeList { get; set; }
    }

    public class ExamCodelist
    {
        public string ExamCode { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
    }
}
