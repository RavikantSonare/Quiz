using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ExamSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex m;
        public App()
        {

            bool isnew;
            m = new Mutex(true, "quizsimulator", out isnew);
            if (!isnew)
            {
                Environment.Exit(0);
            }
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public static bool IsAssociated()
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Classes\\.quiz", false) == null);
        }

        public static void Associate()
        {
            RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.quiz");
            RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Application\\ExamSimulator.exe");
            RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.quiz");

            FileReg.CreateSubKey("DefualtIcon").SetValue("", "D:\\Work\\Project\\ExamSimulator\\Resources\\q.ico");
            FileReg.CreateSubKey("PerceivedType").SetValue("", "Text");

            AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\" \"%1\"");
            AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\" \"%1\"");
            AppReg.CreateSubKey("DefualtIcon").SetValue("", "D:\\Work\\Project\\ExamSimulator\\Resources\\q.ico");

            AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\ExamSimulator.exe");

            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
