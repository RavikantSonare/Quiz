using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Globalization;

namespace WebUser
{
    public class Common
    {
        public static string Select = "---Select---";
        public static string All = "All";
        public static string EncryptionKey = "PROJECT63QUIZ17";

        public static string MessageBox(int returnValue)
        {
            string _mess = string.Empty;

            if (returnValue.Equals(1))
                _mess = "Record Inserted";
            else if (returnValue.Equals(2))
                _mess = "Loding/Email Already Exists";
            else if (returnValue.Equals(3))
                _mess = "Name Already Exists";
            else if (returnValue.Equals(4))
                _mess = "Record Updated";
            else if (returnValue.Equals(5))
                _mess = "Record hasbeen Deleted";

            return _mess;
        }

        public static DateTime ConverDate(string strDate)
        {
            DateTime parsed;
            bool valid = DateTime.TryParseExact(strDate, "dd/MM/yyyy",
                                                CultureInfo.InvariantCulture,
                                                DateTimeStyles.None,
                                                out parsed);

            if (valid.Equals(false))
            {
                valid = DateTime.TryParseExact(strDate, "MM/dd/yyyy",
                                                               CultureInfo.InvariantCulture,
                                                               DateTimeStyles.None,
                                                               out parsed);
            }

            return parsed;
        }

        public static void ClearControl(Panel _page)
        {
            foreach (Control item in _page.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txtBoxes = (TextBox)item;
                    if (txtBoxes.TabIndex.Equals(1))
                    {
                        txtBoxes.Focus();
                    }
                    txtBoxes.Text = null;
                }
                if (item is DropDownList)
                {
                    DropDownList ddl = (DropDownList)item;
                    if (ddl.TabIndex.Equals(1))
                    {
                        ddl.Focus();
                    }
                    ddl.SelectedIndex = 0;
                }
                if (item is CheckBox)
                {
                    CheckBox chk = (CheckBox)item;
                    if (chk.TabIndex.Equals(1))
                    {
                        chk.Focus();
                    }
                    chk.Checked = false;
                }

            }
        }

        public static void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Errorfile/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static string Encrypt(string clearText)
        {
            //string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            //string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}