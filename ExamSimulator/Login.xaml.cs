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
using System.Text.RegularExpressions;

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
            if (ValidateTextBoxes())
            {
                BOUser _bousr = _bausr.SelectUserDetail("GetUserDetail", txtEmailid.Text, Encryptdata(txtPassword.Password));
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
                        MessageBox.Show("Email Id or Password Invalid", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtEmailid.Text = txtPassword.Password = "";
                        txtEmailid.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Email Id or Password Invalid");
                }
            }
        }

        private bool ValidateTextBoxes()
        {
            if (txtEmailid.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter email id");
                return false;
            }
            if (txtPassword.Password.Trim().Length == 0)
            {
                MessageBox.Show("Please enter password");
                return false;
            }
            if (!Regex.IsMatch(txtEmailid.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email id");
                txtEmailid.Select(0, txtEmailid.Text.Length);
                txtEmailid.Focus();
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
