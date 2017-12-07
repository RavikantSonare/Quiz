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
using System.Windows.Shapes;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for ExamMaster.xaml
    /// </summary>
    public partial class ExamMaster : Window
    {
        public ExamMaster()
        {
            InitializeComponent();
        }
        public ExamMaster(TodoItem _toitem)
        {
            InitializeComponent();
            lblExamName.Content = _toitem.Title;
            Application.Current.Properties["test"] = _toitem;
        }
        private void TriggerClose(object sender, RoutedEventArgs e)
        {
            CloseAllWindows();
            MainWindow _mainWindow = new MainWindow();
            _mainWindow.Show();
        }

        private void TriggerMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void TriggerMaximize(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Hide();
            }
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }
    }
}
