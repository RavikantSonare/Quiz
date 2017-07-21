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
    /// Interaction logic for ExamBegin.xaml
    /// </summary>
    public partial class ExamBegin : Page
    {
        public ExamBegin()
        {
            InitializeComponent();
            var value = (TodoItem)Application.Current.Properties["test"];
        }

        private void btnBegin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExamRun());
        }
    }
}
