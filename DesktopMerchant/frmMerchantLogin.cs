using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopMerchant.BOLayer;
using DesktopMerchant.BALayer;

namespace DesktopMerchant
{
    public partial class frmMerchantLogin : Form
    {
        private BAMerchantManage _bamermng = new BAMerchantManage();

        public frmMerchantLogin()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    BOMerchantManage _boMerchant = _bamermng.SelectMerchantLogin("MerchantLogin", txtUserName.Text, Encryptdata(txtPassword.Text));
                    if (_boMerchant != null)
                    {
                        if (txtPassword.Text == Decryptdata(_boMerchant.Password))
                        {
                            MDIfrmMerchantDashboard frm = new MDIfrmMerchantDashboard(_boMerchant.MerchantId);
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Password Invalid");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password Invalid");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Correct UserName/Password");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
