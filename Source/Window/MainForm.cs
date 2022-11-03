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
        private MainPage mainPage;
        public MainForm(DebugForm debugForm)
        {
            InitializeComponent();
            mainPage = new MainPage();
            mainPage.ProjectNameChanged += MainPage_ProjectNameChanged;
            mainPage.ProjectDirtyChanged += MainPage_ProjectDirtyChanged;
#if DEBUG
            mainPage.SetDebugForm(debugForm);
#endif
            AddPage(mainPage);
            mainPage.退出DEETUToolStripMenuItem.Click += new EventHandler(this.Close);
            
            base.FormBorderStyle = FormBorderStyle.Sizable;
            Text = "DEETU " + mainPage.ProjectName; 
        }

        private void MainPage_ProjectDirtyChanged(object sender, bool status)
        {
            if (status)
                Text = "DEETU " + mainPage.ProjectName + '*'; 
            else
                Text = "DEETU " + mainPage.ProjectName; 

        }

        private void MainPage_ProjectNameChanged(object sender, string name)
        {
            Text = "DEETU " + name;
            if (mainPage.IsProjectDirty)
                Text += "*";
        }

        public void SetDebugForm(DebugForm debugForm)
        {

        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainPage.IsProjectDirty)
            {
                DialogResult dr = MessageBox.Show("存在未保存的编辑，确定要关闭窗口吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                    e.Cancel = true;
            }    
        }
    }
}
