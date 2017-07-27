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
    /// Interaction logic for ExhibitImage.xaml
    /// </summary>
    public partial class ExhibitImage : Window
    {
        public ExhibitImage(string imagename)
        {
            InitializeComponent();
            if (imagename != null)
                imgExhibit.Source = new BitmapImage(new Uri(imagename));
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
