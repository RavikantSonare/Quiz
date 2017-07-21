using System;
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
using System.Collections;

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
            List<TodoItem> _item = new List<TodoItem>();
            String[] files = null;
            // string[] files1 = Directory.GetFiles(@"C:\Users\mobiweb\Documents\Visual Studio 2015\Projects\QuizProjectApp\ExamSimulator\Examfile\", "*.txt", SearchOption.AllDirectories);
            if (Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\"))
            {
                files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "\\Examfile\\", "*.txt", SearchOption.AllDirectories);
            }
            else
            {
                files = Directory.GetFiles(@"C:\Users\mobiweb\Documents\Visual Studio 2015\Projects\QuizProjectApp\ExamSimulator\Examfile\", "*.txt", SearchOption.AllDirectories);
            }
            if (files.Length > 0)
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

            ItemContainerGenerator generator = this.listFile.ItemContainerGenerator;
            TodoItem ds = new TodoItem();
            List<TodoItem> ListofAllData = new List<TodoItem>();
            //ListBoxItem selectedItem = (ListBoxItem)generator.ContainerFromIndex(listFile.SelectedIndex);
            int idx = 0;
            foreach (TodoItem item in generator.Items)
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
    }

    public class TodoItem
    {
        public string ModeHeading { get; set; }
        public string Mode { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
