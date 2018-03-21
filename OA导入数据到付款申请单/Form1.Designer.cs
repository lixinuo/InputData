namespace InputData
{
    partial class Form1
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
            this.TextBoxNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DataGridViewPayment = new System.Windows.Forms.DataGridView();
            this.DataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.ButtonChosefile = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.LabelRemarks = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxNum
            // 
            this.TextBoxNum.Location = new System.Drawing.Point(113, 44);
            this.TextBoxNum.Name = "TextBoxNum";
            this.TextBoxNum.Size = new System.Drawing.Size(210, 25);
            this.TextBoxNum.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "付款单号：";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonSearch.Location = new System.Drawing.Point(366, 43);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 28);
            this.ButtonSearch.TabIndex = 2;
            this.ButtonSearch.Text = "查询";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "单据信息";
            // 
            // DataGridViewPayment
            // 
            this.DataGridViewPayment.AllowUserToAddRows = false;
            this.DataGridViewPayment.AllowUserToDeleteRows = false;
            this.DataGridViewPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewPayment.Location = new System.Drawing.Point(20, 96);
            this.DataGridViewPayment.Name = "DataGridViewPayment";
            this.DataGridViewPayment.ReadOnly = true;
            this.DataGridViewPayment.RowTemplate.Height = 27;
            this.DataGridViewPayment.Size = new System.Drawing.Size(715, 63);
            this.DataGridViewPayment.TabIndex = 5;
            // 
            // DataGridViewExcel
            // 
            this.DataGridViewExcel.AllowUserToAddRows = false;
            this.DataGridViewExcel.AllowUserToDeleteRows = false;
            this.DataGridViewExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewExcel.Location = new System.Drawing.Point(20, 215);
            this.DataGridViewExcel.Name = "DataGridViewExcel";
            this.DataGridViewExcel.ReadOnly = true;
            this.DataGridViewExcel.RowTemplate.Height = 27;
            this.DataGridViewExcel.Size = new System.Drawing.Size(715, 332);
            this.DataGridViewExcel.TabIndex = 6;
            // 
            // ButtonChosefile
            // 
            this.ButtonChosefile.Location = new System.Drawing.Point(20, 176);
            this.ButtonChosefile.Name = "ButtonChosefile";
            this.ButtonChosefile.Size = new System.Drawing.Size(95, 33);
            this.ButtonChosefile.TabIndex = 7;
            this.ButtonChosefile.Text = "选择文件";
            this.ButtonChosefile.UseVisualStyleBackColor = true;
            this.ButtonChosefile.Click += new System.EventHandler(this.ButtonChosefile_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(443, 176);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(95, 33);
            this.ButtonUpdate.TabIndex = 8;
            this.ButtonUpdate.Text = "更新覆盖";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // LabelRemarks
            // 
            this.LabelRemarks.AutoSize = true;
            this.LabelRemarks.Location = new System.Drawing.Point(132, 188);
            this.LabelRemarks.Name = "LabelRemarks";
            this.LabelRemarks.Size = new System.Drawing.Size(0, 15);
            this.LabelRemarks.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 580);
            this.Controls.Add(this.LabelRemarks);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ButtonChosefile);
            this.Controls.Add(this.DataGridViewExcel);
            this.Controls.Add(this.DataGridViewPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxNum);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "付款申请单身导入数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DataGridViewPayment;
        private System.Windows.Forms.DataGridView DataGridViewExcel;
        private System.Windows.Forms.Button ButtonChosefile;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Label LabelRemarks;
    }
}

