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
        double resultScore;
        double passingSocre;
        double totalScore;

        public ExamReport(int Score, int TotalQuestion, decimal passingPercentage)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            lbldate.Content = now.ToShortDateString();
            lbltime.Content = now.ToLongTimeString();
            passingSocre = ((TotalQuestion * 100) * Convert.ToDouble(passingPercentage)) / 100;// ((TotalQuestion * 100) * 75) / 100;
            resultScore = Score * 100;
            totalScore = TotalQuestion * 100;
            lblTargetScore.Content = Convert.ToString(passingSocre) + "/" + (totalScore);
            lblYourScore.Content = (resultScore) + " / " + (totalScore);
            lblExamName.Content = filelist.Title;
            pbPassingStatus.Minimum = 0;
            pbPassingStatus.Value = passingSocre;
            pbPassingStatus.Maximum = totalScore;
            pbPassingStatus.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#0C4068");
            pbResultStatus.Minimum = 0;
            pbResultStatus.Value = resultScore;
            pbResultStatus.Maximum = totalScore;
            lblPassingStatusValue.Content = lblResultStatusValue.Content = Convert.ToString(totalScore);
            if (resultScore >= passingSocre)
            {
                lblresultStatus.Content = "Congratulation! You has passed the " + filelist.Title + " exam";
                lblresultStatus.Foreground = Brushes.Green;
            }
            else
            {
                pbResultStatus.Foreground = new SolidColorBrush(Colors.Red);
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
