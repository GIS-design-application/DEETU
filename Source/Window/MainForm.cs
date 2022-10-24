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

namespace DEETU
{
    public partial class MainForm : UIMainFrame
    {
        public MainForm()
        {
            InitializeComponent();
            AddPage(new MainPage());
            base.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
