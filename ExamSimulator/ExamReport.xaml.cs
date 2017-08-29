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
            double passingSocre = ((OutOfScore * 100) * 75) / 100;
            lblTargetScore.Content = Convert.ToString(passingSocre) + "/" + (OutOfScore * 100);
            lblYourScore.Content = (Score * 100) + " / " + (OutOfScore * 100);
            lblExamName.Content = filelist.Title;
            pbPassingStatus.Minimum = 0;
            pbPassingStatus.Value = passingSocre;
            pbPassingStatus.Maximum = OutOfScore * 100;
            pbPassingStatus.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#0C4068");
            pbResultStatus.Minimum = 0;
            pbResultStatus.Value = Score * 100;
            pbResultStatus.Maximum = OutOfScore * 100;
            lblPassingStatusValue.Content = lblResultStatusValue.Content = Convert.ToString(OutOfScore * 100);
            if (Score * 100 >= passingSocre)
            {
                lblresultStatus.Content = "Congratulation! You has passed the " + filelist.Title + " exam";
                lblresultStatus.Foreground = Brushes.Green;
            }
            else
            {
                pbResultStatus.Background = new SolidColorBrush(Colors.Red);
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
