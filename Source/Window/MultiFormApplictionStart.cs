using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEETU.Testing;

namespace DEETU.Testing
{
    class MultiFormApplictionStart: ApplicationContext 
    {
        /// <summary>
        /// 多窗口同时启动类
        /// <remarks>继承ApplicationContext的原因是Application.Run(ApplicationContext context);参数的需要</remarks>
        /// <remarks>另一个是关闭同时启动的窗口</remarks>
        /// </summary>
        private void onFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }

        public MultiFormApplictionStart()
        {
#if DEBUG
            var debugform = new DebugForm();
            var mainform = new MainForm(debugform);
            //将要显示的窗体集合
            var formList = new List<Form>(){
                mainform, debugform
            };
#else
            var mainform = new MainForm(null);
            //将要显示的窗体集合
            var formList = new List<Form>(){
                mainform
            };
#endif

            foreach (var item in formList)
            {
                item.FormClosed += onFormClosed;
            }

            foreach (var item in formList)
            {
                item.Show();
            }
        }
    }
}
