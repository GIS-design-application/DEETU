using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using DEETU.Source.Window;
using DEETU.Testing;

namespace DEETU
{
    public partial class MainForm : UIMainFrame
    {
        public MainForm(DebugForm debugForm)
        {
            InitializeComponent();
            var mainPage = new MainPage();
#if DEBUG
            mainPage.SetDebugForm(debugForm);
#endif
            AddPage(mainPage);
            
            base.FormBorderStyle = FormBorderStyle.Sizable;
        }

        public void SetDebugForm(DebugForm debugForm)
        {

        }
    }
}
