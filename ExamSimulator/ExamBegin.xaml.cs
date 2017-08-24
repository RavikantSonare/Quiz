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
        TodoItem value = (TodoItem)Application.Current.Properties["test"];
        public ExamBegin()
        {
            InitializeComponent();
            lblhead1.Content = value.Title;
        }

        private void btnBegin_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TodoItem toitem = new TodoItem();
            toitem.ModeHeading = button.Content.ToString();
            toitem.Mode = button.Tag.ToString();
            toitem.Title = value.Title;
            toitem.Path = value.Path;
            NavigationService.Navigate(new ExamRun(toitem));
        }
    }
}
