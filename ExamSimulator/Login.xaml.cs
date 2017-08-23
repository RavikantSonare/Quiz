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
using ExamSimulator.BOLayer;
using ExamSimulator.BALayer;
using System.Data;
using System.Data.SqlClient;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private BAUser _bausr = new BAUser();
        public Login()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginFunction();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Connection unsuccessful..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginFunction()
        {
            BOUser _bousr = _bausr.SelectUserDetail("GetUserDetail", txtUsername.Text, Encryptdata(txtPassword.Password));
            if (_bousr != null)
            {
                Application.Current.Properties["Bouser"] = _bousr;
                if (txtPassword.Password == Decryptdata(_bousr.AccessPassword))
                {
                    this.Hide();
                    MainWindow _mainWindow = new ExamSimulator.MainWindow();
                    _mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password Invalid", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUsername.Text = txtPassword.Password = "";
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Username or Password Invalid");
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    LoginFunction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}
