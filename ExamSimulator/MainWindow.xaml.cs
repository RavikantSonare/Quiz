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

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            List<TodoItem> _item = new List<TodoItem>();
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
                    _item.Add(new TodoItem() { Title = System.IO.Path.GetFileNameWithoutExtension(item), Path = item });
                }
            }
            listFile.ItemsSource = _item;
        }

        private void TriggerClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TriggerMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = listFile.Items.IndexOf(button.CommandParameter);
            TodoItem ds = new TodoItem();
            int idx = 0;
            foreach (TodoItem item in listFile.Items)
            {
                if (idx == index)
                {
                    ds.ModeHeading = button.Content.ToString();
                    ds.Mode = button.ToolTip.ToString();
                    ds.Title = item.Title;
                    ds.Path = item.Path;
                }
                idx++;
            }
            ExamMaster _exammaster = new ExamMaster(ds);
            this.Close();
            _exammaster.Show();
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://quizuser.mobi96.org");
        }

        private string filename = System.AppDomain.CurrentDomain.BaseDirectory + "Examfile\\";

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Text files (*.doc,*.docx)|*.doc;*.docx";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    if (!Directory.Exists(filename + openFileDialog.SafeFileName))
                    {
                        File.Delete(filename + openFileDialog.SafeFileName);
                    }
                    File.Copy(openFileDialog.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\" + openFileDialog.SafeFileName);
                    BindFileListBox();
                }
            }
            catch
            {
                MainWindow _mainWindow = new MainWindow();
                _mainWindow.Show();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                string file = ((ExamSimulator.TodoItem)button.CommandParameter).Path;
                if (!Directory.Exists(file))
                {
                    File.Delete(file);
                }
                BindFileListBox();
            }
            catch
            {
                MainWindow _mainWindow = new MainWindow();
                _mainWindow.Show();
            }
        }
    }

    public class TodoItem
    {
        public string ModeHeading { get; set; }
        public string Mode { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
