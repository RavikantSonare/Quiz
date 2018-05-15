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
using System.Windows.Media;
using System.Data;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Windows.Data;
using ExamSimulator.BOLayer;
using ExamSimulator.BALayer;
using System.Threading.Tasks;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BOUser _bouser = (BOUser)Application.Current.Properties["Bouser"];
        BAExamManage _baexmmng = new BAExamManage();

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
            if (Directory.Exists(Common.UserDataFolder))
            {
                // var allowedExtensions = new[] { ".doc", ".docx" };
                var allowedExtensions = new[] { ".vcee" };
                var filesss = Directory
                    .GetFiles(Common.UserDataFolder)
                    .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
                    .ToList();
                files = filesss.ToArray();
            }
            if (files != null)
            {
                foreach (var item in files)
                {
                    _exsitingExamlist.Add(new TodoItem() { Title = System.IO.Path.GetFileNameWithoutExtension(item), Path = item });
                }
            }
            List<BOExamManage> _boexammng = new List<BOExamManage>();
            _boexammng = _baexmmng.SelectExamDetail("GetExWithUid", _bouser.UserId);
            // _boexammng = _baexmmng.SelectExamDetail("GetExWithUid", 3);

            List<UserExamList> _userExamlist = new List<UserExamList>();

            for (int i = 0; i < _boexammng.Count; i++)
            {
                var data = _exsitingExamlist.Where(x => x.Title.Contains(_boexammng[i].SecondCategory + " " + _boexammng[i].ExamCode));
                if (data.Any())
                {
                    _userExamlist.Add(new UserExamList { CategoryName = _boexammng[i].SecondCategory, ExamCodeList = new List<ExamCodelist>() { new ExamCodelist { ExamCodeId = _boexammng[i].ExamCodeId, ExamCode = _boexammng[i].ExamCode, Title = data.FirstOrDefault().Title, Path = data.FirstOrDefault().Path, IsActive = true, Examtime = _boexammng[i].TestTime } } });
                }
                else
                { _userExamlist.Add(new UserExamList { CategoryName = _boexammng[i].SecondCategory, ExamCodeList = new List<ExamCodelist>() { new ExamCodelist { ExamCodeId = _boexammng[i].ExamCodeId, ExamCode = _boexammng[i].ExamCode, Title = "", Path = "", IsActive = false, Examtime = _boexammng[i].TestTime } } }); }
            }
            var _userExamFileList = from p in _userExamlist
                                    group p.ExamCodeList by p.CategoryName into g
                                    select new { SecondCategory = g.Key, ExamCodeList = g.ToList() };
            // listFile.ItemsSource = _userExamFileList;
            //treeview.Items.Clear();
            treeview.ItemsSource = _userExamFileList;
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
            Button btntest = (Button)sender;
            var list = _baexmmng.SelectExamQestionAnswer("GetEQAWithQId", Convert.ToInt32(btntest.CommandParameter));
            string strserialize = JsonConvert.SerializeObject(list);
            string path = Common.UserDataFolder;
            string filename = list.ExamCode + ".json";
            System.IO.File.WriteAllText(path + list.ExamCode + ".json", strserialize);



            //Get the Input File Name and Extension.
            string fileName = Path.GetFileNameWithoutExtension(filename);
            string fileExtension = Path.GetExtension(filename);

            //Build the File Path for the original (input) and the encrypted (output) file.
            string input = Common.UserDataFolder + fileName + fileExtension;
            string output = Common.UserDataFolder + list.SecondCategory + " " + fileName + ".vcee";

            //Save the Input File, Encrypt it and save the encrypted file in output path.
            Common.Encrypt(input, output);

            //Download the Encrypted File.

            // WebClient webClient = new WebClient();
            // webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            //webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
            // webClient.DownloadFileAsync(new Uri("http://online.xcert.top/ExamSimulator/" + output), @"D:\Work\Project\ExamSimulator\bin\Debug\Examfile\" + output);

            //Delete the original (input) and the encrypted (output) file.
            File.Delete(input);
            //File.Delete(output);
            // DownloadFiles(list);
            BindFileListBox();
        }

        //private void DownloadFiles(BOExamManage _boexm)
        //{
        //    List<BOQAManage> AllDataObject = new List<BOQAManage>();
        //    NullDataReturn:
        //    AllDataObject = _boexm.QuestionList;
        //    if (AllDataObject == null && AllDataObject.Count() <= 0) { goto NullDataReturn; }
        //    List<string> Resource = new List<string>();
        //    List<string> Exhabit = new List<string>();
        //    List<string> Topology = new List<string>();
        //    List<string> Scanrio = new List<string>();

        //    //Process each object
        //    try
        //    {
        //        Resource = AllDataObject.Where(z => z.Exhibit != "").Select(z => z.Exhibit).ToList();
        //        foreach (dynamic result in Resource)
        //        {
        //            lock (this)
        //            {
        //                if (!string.IsNullOrEmpty(result))
        //                {
        //                    var responseWeb = GetMediaData("Pictures", result).Result;
        //                }
        //            }
        //        }
        //        //SoundsNameList = AllDataObject.Where(n => n.SoundUrl != null).Select(z => z.SoundUrl).ToList();
        //        //foreach (dynamic result in SoundsNameList)
        //        //{
        //        //    lock (this)
        //        //    {
        //        //        if (!string.IsNullOrEmpty(result))
        //        //        {
        //        //            var responseWeb = GetMediaData("Sounds", result).Result;
        //        //        }
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private bool GetMediaData(string folderName, string fileName)
        //{
        //    bool isDone = false;
        //    string filePath = "";
        //    WebClient client = new WebClient();
        //    try
        //    {
        //        lock (this)
        //        {
        //            // List data response.
        //            //HttpResponseMessage response = client.DownloadFileAsync(new Uri("http://xcert.top/Media/" + folderName + "/" + fileName)).Result;

        //            //// Check that response was successful or throw exception
        //            //response.EnsureSuccessStatusCode();

        //            //// Read response asynchronously and save asynchronously to file
        //            //filePath = UserDataFolder("Media\\" + folderName, false) + fileName;
        //            //using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        //            //{
        //            //    //copy the content from response to filestream
        //            //    response.Content.CopyToAsync(fileStream).Wait();

        //            //}
        //            byte[] data;
        //            using (WebClient client2 = new WebClient())
        //            {
        //                data = client2.DownloadData("http://localhost:60956/resource/canvasimage.png");
        //            }
        //            File.WriteAllBytes(Common.UserDataFolder + "canvasimage.png", data);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        isDone = false;
        //    }

        //    return isDone;
        //}

        public void wc_DownloadProgressChanged(Object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            txtblkProgressValue.Visibility = Visibility.Visible;
            pbDownloadStatus.BorderBrush = new SolidColorBrush(Colors.Green);
            pbDownloadStatus.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed");
            txtblkProgressValue.Visibility = Visibility.Collapsed;
            pbDownloadStatus.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#0C4068");
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
            ds.Examtime = Convert.ToInt32(button.ToolTip);
            ExamMaster _exammaster = new ExamMaster(ds);
            this.Close();
            _exammaster.Show();
        }
    }

    public class TodoItem
    {
        public string Mode { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public int Examtime { get; set; }
    }

    public class UserExamList
    {
        public string CategoryName { get; set; }
        public List<ExamCodelist> ExamCodeList { get; set; }
    }

    public class ExamCodelist
    {
        public int ExamCodeId { get; set; }
        public string ExamCode { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
        public int Examtime { get; set; }
    }

    class TreeViewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TreeViewItem item = (TreeViewItem)value;
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
            return null;// ic.ItemContainerGenerator.IndexFromContainer(item) == ic.Items.Count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false;
        }
    }
}
