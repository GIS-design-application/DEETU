namespace DEETU.Source.Window
{
    partial class SelectedByExpressionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldsListBox = new Sunny.UI.UIListBox();
            this.valueListBox = new Sunny.UI.UIListBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.getUniqueValueButton = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.expressionTextBox = new Sunny.UI.UIRichTextBox();
            this.uiFlowLayoutPanel1 = new Sunny.UI.UIPanel();
            this.quoteButton = new Sunny.UI.UIButton();
            this.nullButton = new Sunny.UI.UIButton();
            this.inButton = new Sunny.UI.UIButton();
            this.isButton = new Sunny.UI.UIButton();
            this.likeButton = new Sunny.UI.UIButton();
            this.notButton = new Sunny.UI.UIButton();
            this.orButton = new Sunny.UI.UIButton();
            this.andButton = new Sunny.UI.UIButton();
            this.rightPButton = new Sunny.UI.UIButton();
            this.leftPButton = new Sunny.UI.UIButton();
            this.percentButton = new Sunny.UI.UIButton();
            this.leButton = new Sunny.UI.UIButton();
            this.lessButton = new Sunny.UI.UIButton();
            this.equalButton = new Sunny.UI.UIButton();
            this.geButton = new Sunny.UI.UIButton();
            this.greatButton = new Sunny.UI.UIButton();
            this.notEqualButton = new Sunny.UI.UIButton();
            this.powButton = new Sunny.UI.UIButton();
            this.divideButton = new Sunny.UI.UIButton();
            this.timeButton = new Sunny.UI.UIButton();
            this.minusButton = new Sunny.UI.UIButton();
            this.plusButton = new Sunny.UI.UIButton();
            this.searchTextBox = new Sunny.UI.UITextBox();
            this.searchValueButton = new Sunny.UI.UISymbolButton();
            this.okButton = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.layerNameText = new Sunny.UI.UITextBox();
            this.uiComboboxEx1 = new Sunny.UI.UIComboboxEx();
            this.uiFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldsListBox
            // 
            this.fieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsListBox.FillColor = System.Drawing.Color.White;
            this.fieldsListBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fieldsListBox.FormatString = "";
            this.fieldsListBox.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.fieldsListBox.Location = new System.Drawing.Point(5, 92);
            this.fieldsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fieldsListBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.fieldsListBox.Name = "fieldsListBox";
            this.fieldsListBox.Padding = new System.Windows.Forms.Padding(2);
            this.fieldsListBox.Size = new System.Drawing.Size(489, 105);
            this.fieldsListBox.Style = Sunny.UI.UIStyle.Custom;
            this.fieldsListBox.TabIndex = 0;
            this.fieldsListBox.Text = "fieldListBox";
            this.fieldsListBox.ItemDoubleClick += new System.EventHandler(this.fieldsListBox_ItemDoubleClick);
            // 
            // valueListBox
            // 
            this.valueListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueListBox.FillColor = System.Drawing.Color.White;
            this.valueListBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.valueListBox.FormatString = "";
            this.valueListBox.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.valueListBox.Location = new System.Drawing.Point(240, 230);
            this.valueListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.valueListBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.valueListBox.Name = "valueListBox";
            this.valueListBox.Padding = new System.Windows.Forms.Padding(2);
            this.valueListBox.Size = new System.Drawing.Size(255, 146);
            this.valueListBox.Style = Sunny.UI.UIStyle.Custom;
            this.valueListBox.TabIndex = 2;
            this.valueListBox.Text = "valueListBox";
            this.valueListBox.ItemDoubleClick += new System.EventHandler(this.valueListBox_ItemDoubleClick);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(2, 69);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "字段列表";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(236, 202);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(88, 26);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "唯一值列表";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // getUniqueValueButton
            // 
            this.getUniqueValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getUniqueValueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getUniqueValueButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.getUniqueValueButton.Location = new System.Drawing.Point(386, 381);
            this.getUniqueValueButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.getUniqueValueButton.Name = "getUniqueValueButton";
            this.getUniqueValueButton.Size = new System.Drawing.Size(109, 23);
            this.getUniqueValueButton.Style = Sunny.UI.UIStyle.Custom;
            this.getUniqueValueButton.TabIndex = 5;
            this.getUniqueValueButton.Text = "获取唯一值";
            this.getUniqueValueButton.Click += new System.EventHandler(this.getUniqueValueButton_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(8, 202);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(128, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "操作符";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(8, 381);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(370, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 8;
            this.uiLabel4.Text = "Select * from where";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expressionTextBox
            // 
            this.expressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionTextBox.AutoWordSelection = true;
            this.expressionTextBox.FillColor = System.Drawing.Color.White;
            this.expressionTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.expressionTextBox.Location = new System.Drawing.Point(8, 409);
            this.expressionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.expressionTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.expressionTextBox.Size = new System.Drawing.Size(486, 120);
            this.expressionTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.expressionTextBox.TabIndex = 9;
            this.expressionTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiFlowLayoutPanel1
            // 
            this.uiFlowLayoutPanel1.Controls.Add(this.quoteButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.nullButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.inButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.isButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.likeButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.notButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.orButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.andButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.rightPButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.leftPButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.percentButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.leButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.lessButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.equalButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.geButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.greatButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.notEqualButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.powButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.divideButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.timeButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.minusButton);
            this.uiFlowLayoutPanel1.Controls.Add(this.plusButton);
            this.uiFlowLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiFlowLayoutPanel1.Location = new System.Drawing.Point(6, 230);
            this.uiFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiFlowLayoutPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiFlowLayoutPanel1.Name = "uiFlowLayoutPanel1";
            this.uiFlowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.uiFlowLayoutPanel1.Size = new System.Drawing.Size(224, 146);
            this.uiFlowLayoutPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiFlowLayoutPanel1.TabIndex = 10;
            this.uiFlowLayoutPanel1.Text = null;
            this.uiFlowLayoutPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quoteButton
            // 
            this.quoteButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.quoteButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quoteButton.Location = new System.Drawing.Point(78, 77);
            this.quoteButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.quoteButton.Name = "quoteButton";
            this.quoteButton.Size = new System.Drawing.Size(30, 30);
            this.quoteButton.Style = Sunny.UI.UIStyle.Custom;
            this.quoteButton.TabIndex = 16;
            this.quoteButton.Text = "\'";
            this.quoteButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // nullButton
            // 
            this.nullButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.nullButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nullButton.Location = new System.Drawing.Point(113, 111);
            this.nullButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.nullButton.Name = "nullButton";
            this.nullButton.Size = new System.Drawing.Size(30, 30);
            this.nullButton.Style = Sunny.UI.UIStyle.Custom;
            this.nullButton.TabIndex = 15;
            this.nullButton.Text = "null";
            this.nullButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // inButton
            // 
            this.inButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.inButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inButton.Location = new System.Drawing.Point(77, 111);
            this.inButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.inButton.Name = "inButton";
            this.inButton.Size = new System.Drawing.Size(30, 30);
            this.inButton.Style = Sunny.UI.UIStyle.Custom;
            this.inButton.TabIndex = 14;
            this.inButton.Text = "in";
            this.inButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // isButton
            // 
            this.isButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.isButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.isButton.Location = new System.Drawing.Point(41, 111);
            this.isButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.isButton.Name = "isButton";
            this.isButton.Size = new System.Drawing.Size(30, 30);
            this.isButton.Style = Sunny.UI.UIStyle.Custom;
            this.isButton.TabIndex = 13;
            this.isButton.Text = "is";
            this.isButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // likeButton
            // 
            this.likeButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.likeButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.likeButton.Location = new System.Drawing.Point(6, 111);
            this.likeButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.likeButton.Name = "likeButton";
            this.likeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.likeButton.Size = new System.Drawing.Size(30, 30);
            this.likeButton.Style = Sunny.UI.UIStyle.Custom;
            this.likeButton.TabIndex = 12;
            this.likeButton.Text = "like";
            this.likeButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // notButton
            // 
            this.notButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.notButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.notButton.Location = new System.Drawing.Point(185, 77);
            this.notButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.notButton.Name = "notButton";
            this.notButton.Size = new System.Drawing.Size(30, 30);
            this.notButton.Style = Sunny.UI.UIStyle.Custom;
            this.notButton.TabIndex = 12;
            this.notButton.Text = "not";
            this.notButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // orButton
            // 
            this.orButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.orButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.orButton.Location = new System.Drawing.Point(149, 77);
            this.orButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.orButton.Name = "orButton";
            this.orButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orButton.Size = new System.Drawing.Size(30, 30);
            this.orButton.Style = Sunny.UI.UIStyle.Custom;
            this.orButton.TabIndex = 12;
            this.orButton.Text = "or";
            this.orButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // andButton
            // 
            this.andButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.andButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.andButton.Location = new System.Drawing.Point(113, 77);
            this.andButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.andButton.Name = "andButton";
            this.andButton.Size = new System.Drawing.Size(30, 30);
            this.andButton.Style = Sunny.UI.UIStyle.Custom;
            this.andButton.TabIndex = 12;
            this.andButton.Text = "and";
            this.andButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // rightPButton
            // 
            this.rightPButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rightPButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rightPButton.Location = new System.Drawing.Point(41, 77);
            this.rightPButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.rightPButton.Name = "rightPButton";
            this.rightPButton.Size = new System.Drawing.Size(30, 30);
            this.rightPButton.Style = Sunny.UI.UIStyle.Custom;
            this.rightPButton.TabIndex = 12;
            this.rightPButton.Text = ")";
            this.rightPButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // leftPButton
            // 
            this.leftPButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.leftPButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.leftPButton.Location = new System.Drawing.Point(5, 77);
            this.leftPButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.leftPButton.Name = "leftPButton";
            this.leftPButton.Size = new System.Drawing.Size(30, 30);
            this.leftPButton.Style = Sunny.UI.UIStyle.Custom;
            this.leftPButton.TabIndex = 12;
            this.leftPButton.Text = "(";
            this.leftPButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // percentButton
            // 
            this.percentButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.percentButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.percentButton.Location = new System.Drawing.Point(185, 5);
            this.percentButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.percentButton.Name = "percentButton";
            this.percentButton.Size = new System.Drawing.Size(30, 30);
            this.percentButton.Style = Sunny.UI.UIStyle.Custom;
            this.percentButton.TabIndex = 12;
            this.percentButton.Text = "%";
            this.percentButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // leButton
            // 
            this.leButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.leButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.leButton.Location = new System.Drawing.Point(185, 41);
            this.leButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.leButton.Name = "leButton";
            this.leButton.Size = new System.Drawing.Size(30, 30);
            this.leButton.Style = Sunny.UI.UIStyle.Custom;
            this.leButton.TabIndex = 12;
            this.leButton.Text = "<=";
            this.leButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // lessButton
            // 
            this.lessButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lessButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lessButton.Location = new System.Drawing.Point(149, 41);
            this.lessButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.lessButton.Name = "lessButton";
            this.lessButton.Size = new System.Drawing.Size(30, 30);
            this.lessButton.Style = Sunny.UI.UIStyle.Custom;
            this.lessButton.TabIndex = 12;
            this.lessButton.Text = "<";
            this.lessButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // equalButton
            // 
            this.equalButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.equalButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.equalButton.Location = new System.Drawing.Point(5, 41);
            this.equalButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(30, 30);
            this.equalButton.Style = Sunny.UI.UIStyle.Custom;
            this.equalButton.TabIndex = 8;
            this.equalButton.Text = "=";
            this.equalButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // geButton
            // 
            this.geButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.geButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.geButton.Location = new System.Drawing.Point(113, 41);
            this.geButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.geButton.Name = "geButton";
            this.geButton.Size = new System.Drawing.Size(30, 30);
            this.geButton.Style = Sunny.UI.UIStyle.Custom;
            this.geButton.TabIndex = 11;
            this.geButton.Text = ">=";
            this.geButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // greatButton
            // 
            this.greatButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.greatButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.greatButton.Location = new System.Drawing.Point(77, 41);
            this.greatButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.greatButton.Name = "greatButton";
            this.greatButton.Size = new System.Drawing.Size(30, 30);
            this.greatButton.Style = Sunny.UI.UIStyle.Custom;
            this.greatButton.TabIndex = 10;
            this.greatButton.Text = ">";
            this.greatButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // notEqualButton
            // 
            this.notEqualButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.notEqualButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.notEqualButton.Location = new System.Drawing.Point(41, 41);
            this.notEqualButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.notEqualButton.Name = "notEqualButton";
            this.notEqualButton.Size = new System.Drawing.Size(30, 30);
            this.notEqualButton.Style = Sunny.UI.UIStyle.Custom;
            this.notEqualButton.TabIndex = 9;
            this.notEqualButton.Text = "<>";
            this.notEqualButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // powButton
            // 
            this.powButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.powButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.powButton.Location = new System.Drawing.Point(149, 5);
            this.powButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.powButton.Name = "powButton";
            this.powButton.Size = new System.Drawing.Size(30, 30);
            this.powButton.Style = Sunny.UI.UIStyle.Custom;
            this.powButton.TabIndex = 7;
            this.powButton.Text = "^";
            this.powButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // divideButton
            // 
            this.divideButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.divideButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.divideButton.Location = new System.Drawing.Point(113, 5);
            this.divideButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(30, 30);
            this.divideButton.Style = Sunny.UI.UIStyle.Custom;
            this.divideButton.TabIndex = 6;
            this.divideButton.Text = "/";
            this.divideButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // timeButton
            // 
            this.timeButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.timeButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.timeButton.Location = new System.Drawing.Point(77, 5);
            this.timeButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.timeButton.Name = "timeButton";
            this.timeButton.Size = new System.Drawing.Size(30, 30);
            this.timeButton.Style = Sunny.UI.UIStyle.Custom;
            this.timeButton.TabIndex = 5;
            this.timeButton.Text = "×";
            this.timeButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // minusButton
            // 
            this.minusButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.minusButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.minusButton.Location = new System.Drawing.Point(41, 5);
            this.minusButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(30, 30);
            this.minusButton.Style = Sunny.UI.UIStyle.Custom;
            this.minusButton.TabIndex = 4;
            this.minusButton.Text = "-";
            this.minusButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // plusButton
            // 
            this.plusButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.plusButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.plusButton.Location = new System.Drawing.Point(5, 5);
            this.plusButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(30, 30);
            this.plusButton.Style = Sunny.UI.UIStyle.Custom;
            this.plusButton.TabIndex = 3;
            this.plusButton.Text = "+";
            this.plusButton.Click += new System.EventHandler(this.OperatorButtons_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox.FillColor = System.Drawing.Color.White;
            this.searchTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchTextBox.Location = new System.Drawing.Point(331, 202);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 0, 5);
            this.searchTextBox.Maximum = 2147483647D;
            this.searchTextBox.Minimum = -2147483648D;
            this.searchTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.searchTextBox.Size = new System.Drawing.Size(138, 44);
            this.searchTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.searchTextBox.TabIndex = 11;
            this.searchTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchTextBox.Watermark = "搜索唯一值";
            // 
            // searchValueButton
            // 
            this.searchValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchValueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchValueButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchValueButton.Location = new System.Drawing.Point(472, 202);
            this.searchValueButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.searchValueButton.Name = "searchValueButton";
            this.searchValueButton.Size = new System.Drawing.Size(24, 26);
            this.searchValueButton.Style = Sunny.UI.UIStyle.Custom;
            this.searchValueButton.Symbol = 61442;
            this.searchValueButton.TabIndex = 12;
            this.searchValueButton.Click += new System.EventHandler(this.searchValueButton_Click);
            // 
            // okButton
            // 
            this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.okButton.Location = new System.Drawing.Point(413, 537);
            this.okButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(81, 35);
            this.okButton.Style = Sunny.UI.UIStyle.Custom;
            this.okButton.TabIndex = 13;
            this.okButton.Text = "选择";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(2, 35);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(75, 34);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 15;
            this.uiLabel5.Text = "当前图层";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layerNameText
            // 
            this.layerNameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.layerNameText.FillColor = System.Drawing.Color.White;
            this.layerNameText.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.layerNameText.Location = new System.Drawing.Point(84, 40);
            this.layerNameText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layerNameText.Maximum = 2147483647D;
            this.layerNameText.Minimum = -2147483648D;
            this.layerNameText.MinimumSize = new System.Drawing.Size(1, 1);
            this.layerNameText.Name = "layerNameText";
            this.layerNameText.Padding = new System.Windows.Forms.Padding(5);
            this.layerNameText.ReadOnly = true;
            this.layerNameText.Size = new System.Drawing.Size(412, 50);
            this.layerNameText.Style = Sunny.UI.UIStyle.Custom;
            this.layerNameText.TabIndex = 16;
            this.layerNameText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboboxEx1
            // 
            this.uiComboboxEx1.BackColor = System.Drawing.Color.White;
            this.uiComboboxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.uiComboboxEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiComboboxEx1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboboxEx1.FormattingEnabled = true;
            this.uiComboboxEx1.Items.AddRange(new object[] {
            "创建新选择内容",
            "添加选择内容到当前选择",
            "删除选择内容"});
            this.uiComboboxEx1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboboxEx1.Location = new System.Drawing.Point(6, 537);
            this.uiComboboxEx1.Name = "uiComboboxEx1";
            this.uiComboboxEx1.Size = new System.Drawing.Size(224, 45);
            this.uiComboboxEx1.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboboxEx1.TabIndex = 17;
            // 
            // SelectedByExpressionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 581);
            this.Controls.Add(this.uiComboboxEx1);
            this.Controls.Add(this.layerNameText);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.searchValueButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.uiFlowLayoutPanel1);
            this.Controls.Add(this.expressionTextBox);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.getUniqueValueButton);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.valueListBox);
            this.Controls.Add(this.fieldsListBox);
            this.Name = "SelectedByExpressionForm";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "按表达式选择";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.TitleForeColor = System.Drawing.Color.Black;
            this.uiFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIListBox fieldsListBox;
        private Sunny.UI.UIListBox valueListBox;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton getUniqueValueButton;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIRichTextBox expressionTextBox;
        private Sunny.UI.UIPanel uiFlowLayoutPanel1;
        private Sunny.UI.UIButton nullButton;
        private Sunny.UI.UIButton inButton;
        private Sunny.UI.UIButton isButton;
        private Sunny.UI.UIButton likeButton;
        private Sunny.UI.UIButton notButton;
        private Sunny.UI.UIButton orButton;
        private Sunny.UI.UIButton andButton;
        private Sunny.UI.UIButton rightPButton;
        private Sunny.UI.UIButton leftPButton;
        private Sunny.UI.UIButton percentButton;
        private Sunny.UI.UIButton leButton;
        private Sunny.UI.UIButton lessButton;
        private Sunny.UI.UIButton equalButton;
        private Sunny.UI.UIButton geButton;
        private Sunny.UI.UIButton greatButton;
        private Sunny.UI.UIButton notEqualButton;
        private Sunny.UI.UIButton powButton;
        private Sunny.UI.UIButton divideButton;
        private Sunny.UI.UIButton timeButton;
        private Sunny.UI.UIButton minusButton;
        private Sunny.UI.UIButton plusButton;
        private Sunny.UI.UITextBox searchTextBox;
        private Sunny.UI.UISymbolButton searchValueButton;
        private Sunny.UI.UIButton okButton;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox layerNameText;
        private Sunny.UI.UIComboboxEx uiComboboxEx1;
        private Sunny.UI.UIButton quoteButton;
    }
}