using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLayer;
using BALayer;

namespace DesktopAdmin
{
    public partial class frmAdminLogin : Form
    {
        private BAAdmin baadmin = new BAAdmin();
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTextBoxes())
                {
                    BOAdmin boadmin = baadmin.SelectAdminLogin("GETALL", txtUserName.Text, Encryptdata(txtPassword.Text));
                    if (boadmin != null)
                    {
                        if (txtPassword.Text == Decryptdata(boadmin.Password))
                        {
                            MDIfrmAdminDashboard frm = new DesktopAdmin.MDIfrmAdminDashboard(boadmin.AdminId);
                            frm.Show();
                            frm.MinimumSize = new Size(1028, 772);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void frmAdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private bool ValidateTextBoxes()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter user name");
                return false;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter password");
                return false;
            }
            return true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
