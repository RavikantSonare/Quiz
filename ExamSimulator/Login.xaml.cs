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
using System.IO;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateTextBoxes())
                {
                    if (File.Exists("Input\\credentials.txt"))
                    {
                        string[] lines = File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "\\Input\\credentials.txt");
                        if ((txtUsername.Text == lines[0]) && (txtPassword.Password == lines[1]))
                        {
                            this.Hide();
                            MainWindow _mainWindow = new ExamSimulator.MainWindow();
                            _mainWindow.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Username or Password Invalid", "Message", MessageBoxButton.OK);
                            txtUsername.Text = txtPassword.Password = "";
                            txtUsername.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password Invalid");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateTextBoxes()
        {
            if (txtUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter user name");
                return false;
            }
            if (txtPassword.Password.Trim().Length == 0)
            {
                MessageBox.Show("Please enter password");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
