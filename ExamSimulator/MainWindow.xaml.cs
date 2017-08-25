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
                var data = _exsitingExamlist.Where(x => x.Title.Contains(_boexammng[i].SecondCategory + "-" + _boexammng[i].ExamCode));
                if (data.Any())
                {
                    _userExamlist.Add(new UserExamList { CategoryName = _boexammng[i].SecondCategory, ExamCodeList = new List<ExamCodelist>() { new ExamCodelist { ExamCode = _boexammng[i].ExamCode, Title = data.FirstOrDefault().Title, Path = data.FirstOrDefault().Path, IsActive = true } } });
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
            Button button = sender as Button;
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
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
            webClient.DownloadFileAsync(new Uri("http://quizuser.mobi96.org/ExamSimulator/" + fileName), @"D:\Work\Project\ExamSimulator\bin\Debug\Examfile\" + fileName);

        }

        public void wc_DownloadProgressChanged(Object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            pbDownloadStatus.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed");
            pbDownloadStatus.Value = 0;
            BindFileListBox();
        }

        private void btnExamCode_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var filename = button.CommandParameter;
            TodoItem ds = new TodoItem();
            ds.Title = button.Tag.ToString();
            ds.Path = filename.ToString();
            ExamMaster _exammaster = new ExamMaster(ds);
            this.Close();
            _exammaster.Show();
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
