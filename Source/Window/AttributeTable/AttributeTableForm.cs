using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace DEETU.Source.Window
{
    public partial class AttributeTableForm : UIForm
    {
        public AttributeTableForm()
        {
            InitializeComponent();

        }

        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            uiTabControl1.SelectedIndex = menuIndex;
        }
    }
}
