using System;
using System.Collections.Generic;
using System.Linq;
#if DEBUG
using DEETU.Testing;
#endif
using System.Windows.Forms;

namespace DEETU
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            Application.Run(new MultiFormApplictionStart());
#else
            Application.Run(new MainForm());
#endif
        }
    }
}
