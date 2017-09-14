using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using Microsoft.Win32;

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
    }
}
