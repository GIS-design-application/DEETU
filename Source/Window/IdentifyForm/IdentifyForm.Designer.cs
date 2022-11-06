namespace DEETU.Source.Window
{
    partial class IdentifyForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.featureList = new System.Windows.Forms.ListView();
            this.detailTable = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.featureList);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detailTable);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(467, 415);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 1;
            // 
            // featureList
            // 
            this.featureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featureList.HideSelection = false;
            this.featureList.Location = new System.Drawing.Point(0, 0);
            this.featureList.MultiSelect = false;
            this.featureList.Name = "featureList";
            this.featureList.Size = new System.Drawing.Size(153, 415);
            this.featureList.TabIndex = 0;
            this.featureList.UseCompatibleStateImageBehavior = false;
            this.featureList.View = System.Windows.Forms.View.SmallIcon;
            this.featureList.SelectedIndexChanged += new System.EventHandler(this.featureList_SelectedIndexChanged);
            // 
            // detailTable
            // 
            this.detailTable.AutoScroll = true;
            this.detailTable.ColumnCount = 2;
            this.detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detailTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.detailTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailTable.Location = new System.Drawing.Point(0, 0);
            this.detailTable.Name = "detailTable";
            this.detailTable.RowCount = 2;
            this.detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.detailTable.Size = new System.Drawing.Size(310, 415);
            this.detailTable.TabIndex = 0;
            // 
            // IdentifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "IdentifyForm";
            this.Text = "识别";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView featureList;
        private System.Windows.Forms.TableLayoutPanel detailTable;
    }
}