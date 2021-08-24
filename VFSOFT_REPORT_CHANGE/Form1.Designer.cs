
namespace VFSOFT_REPORT_CHANGE
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Report_DataView = new System.Windows.Forms.DataGridView();
            this.gp1 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataBaseFileLoad = new System.Windows.Forms.Button();
            this.OpenAccessFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartChangeSql = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FillPepoleKindBox = new System.Windows.Forms.ComboBox();
            this.ItemReverseBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProcessBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Report_DataView)).BeginInit();
            this.gp1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Report_DataView
            // 
            this.Report_DataView.BackgroundColor = System.Drawing.Color.White;
            this.Report_DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Report_DataView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.Report_DataView.Location = new System.Drawing.Point(4, 19);
            this.Report_DataView.Margin = new System.Windows.Forms.Padding(2);
            this.Report_DataView.Name = "Report_DataView";
            this.Report_DataView.RowHeadersWidth = 51;
            this.Report_DataView.RowTemplate.Height = 27;
            this.Report_DataView.Size = new System.Drawing.Size(591, 360);
            this.Report_DataView.TabIndex = 0;
            // 
            // gp1
            // 
            this.gp1.Controls.Add(this.Report_DataView);
            this.gp1.Location = new System.Drawing.Point(9, 10);
            this.gp1.Margin = new System.Windows.Forms.Padding(2);
            this.gp1.Name = "gp1";
            this.gp1.Padding = new System.Windows.Forms.Padding(2);
            this.gp1.Size = new System.Drawing.Size(602, 384);
            this.gp1.TabIndex = 1;
            this.gp1.TabStop = false;
            this.gp1.Text = "报表信息展示";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataBaseFileLoad);
            this.groupBox1.Location = new System.Drawing.Point(14, 398);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(142, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件加载";
            // 
            // DataBaseFileLoad
            // 
            this.DataBaseFileLoad.Location = new System.Drawing.Point(18, 37);
            this.DataBaseFileLoad.Margin = new System.Windows.Forms.Padding(2);
            this.DataBaseFileLoad.Name = "DataBaseFileLoad";
            this.DataBaseFileLoad.Size = new System.Drawing.Size(104, 50);
            this.DataBaseFileLoad.TabIndex = 3;
            this.DataBaseFileLoad.Text = "选择数据库...";
            this.DataBaseFileLoad.UseVisualStyleBackColor = true;
            // 
            // OpenAccessFile
            // 
            this.OpenAccessFile.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.StartChangeSql);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.FillPepoleKindBox);
            this.groupBox2.Controls.Add(this.ItemReverseBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(160, 398);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(444, 110);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改区";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 23);
            this.label3.TabIndex = 6;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartChangeSql
            // 
            this.StartChangeSql.Location = new System.Drawing.Point(358, 71);
            this.StartChangeSql.Name = "StartChangeSql";
            this.StartChangeSql.Size = new System.Drawing.Size(81, 34);
            this.StartChangeSql.TabIndex = 5;
            this.StartChangeSql.Text = "执行";
            this.StartChangeSql.UseVisualStyleBackColor = true;
            this.StartChangeSql.Click += new System.EventHandler(this.StartChangeSql_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(212, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "评测主体：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FillPepoleKindBox
            // 
            this.FillPepoleKindBox.FormattingEnabled = true;
            this.FillPepoleKindBox.Items.AddRange(new object[] {
            "不修改（没有评测主体）",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.FillPepoleKindBox.Location = new System.Drawing.Point(285, 34);
            this.FillPepoleKindBox.Name = "FillPepoleKindBox";
            this.FillPepoleKindBox.Size = new System.Drawing.Size(154, 20);
            this.FillPepoleKindBox.TabIndex = 2;
            // 
            // ItemReverseBox
            // 
            this.ItemReverseBox.FormattingEnabled = true;
            this.ItemReverseBox.Items.AddRange(new object[] {
            "不修改",
            "该人得票数",
            "该人得票率",
            "该人得分",
            "该人得分率"});
            this.ItemReverseBox.Location = new System.Drawing.Point(80, 34);
            this.ItemReverseBox.Name = "ItemReverseBox";
            this.ItemReverseBox.Size = new System.Drawing.Size(116, 20);
            this.ItemReverseBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "计算项：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessBar
            // 
            this.ProcessBar.Location = new System.Drawing.Point(13, 515);
            this.ProcessBar.Name = "ProcessBar";
            this.ProcessBar.Size = new System.Drawing.Size(143, 23);
            this.ProcessBar.TabIndex = 5;
            this.ProcessBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(618, 542);
            this.Controls.Add(this.ProcessBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gp1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VFSOFT-V2.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report_DataView)).EndInit();
            this.gp1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gp1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.OpenFileDialog OpenAccessFile;
        public System.Windows.Forms.Button DataBaseFileLoad;
        public System.Windows.Forms.DataGridView Report_DataView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartChangeSql;
        public System.Windows.Forms.ComboBox FillPepoleKindBox;
        public System.Windows.Forms.ComboBox ItemReverseBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ProgressBar ProcessBar;
    }
}

