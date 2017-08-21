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

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for ExamReport.xaml
    /// </summary>
    public partial class ExamReport : Page
    {
        TodoItem filelist = (TodoItem)Application.Current.Properties["test"];

        public ExamReport(int Score, int OutOfScore)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            lbldate.Content = now.ToShortDateString();
            lbltime.Content = now.ToLongTimeString();
            lblYourScore.Content = Score + " / " + OutOfScore;
            if (Score > OutOfScore / 2)
            {
                lblresultStatus.Content = "Congratulation! You has passed the " + filelist.Title + " exam";
                lblresultStatus.Foreground = Brushes.Green;
            }
            else
            {
                lblresultStatus.Content = "Sorry! You has failed the " + filelist.Title + " exam";
                lblresultStatus.Foreground = Brushes.Red;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            CloseAllWindows();
            MainWindow _mainWindow = new MainWindow();
            _mainWindow.Show();
        }
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Hide();
            }
        }
    }
}
