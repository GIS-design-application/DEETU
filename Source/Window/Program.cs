using DEETU.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                Application.Run(new MultiFormApplictionStart());
            }
            catch (Exception e)
            {
                MessageBox.Show("未知错误!请联系管理员\ndhd_520@163.com\n" + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
