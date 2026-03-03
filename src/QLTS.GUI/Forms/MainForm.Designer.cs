namespace QLTS.GUI.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAssets = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAssetList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransactionList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProfit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAssets,
            this.tsmiTransaction,
            this.tsmiStatistics});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAssets
            // 
            this.tsmiAssets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAssetList});
            this.tsmiAssets.Name = "tsmiAssets";
            this.tsmiAssets.Size = new System.Drawing.Size(67, 24);
            this.tsmiAssets.Text = "Tài sản";
            // 
            // tsmiAssetList
            // 
            this.tsmiAssetList.Name = "tsmiAssetList";
            this.tsmiAssetList.Size = new System.Drawing.Size(207, 26);
            this.tsmiAssetList.Text = "Danh sách tài sản";
            this.tsmiAssetList.Click += new System.EventHandler(this.tsmiAssetList_Click);
            // 
            // tsmiTransaction
            // 
            this.tsmiTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTransactionList});
            this.tsmiTransaction.Name = "tsmiTransaction";
            this.tsmiTransaction.Size = new System.Drawing.Size(86, 24);
            this.tsmiTransaction.Text = "Giao dịch";
            // 
            // tsmiTransactionList
            // 
            this.tsmiTransactionList.Name = "tsmiTransactionList";
            this.tsmiTransactionList.Size = new System.Drawing.Size(226, 26);
            this.tsmiTransactionList.Text = "Danh sách giao dịch";
            this.tsmiTransactionList.Click += new System.EventHandler(this.tsmiTransactionList_Click);
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProfit});
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.Size = new System.Drawing.Size(84, 24);
            this.tsmiStatistics.Text = "Thống kê";
            // 
            // tsmiProfit
            // 
            this.tsmiProfit.Name = "tsmiProfit";
            this.tsmiProfit.Size = new System.Drawing.Size(130, 26);
            this.tsmiProfit.Text = "Lãi/lỗ";
            this.tsmiProfit.Click += new System.EventHandler(this.tsmiProfit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 551);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài sản & đầu tư cá nhân";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAssets;
        private System.Windows.Forms.ToolStripMenuItem tsmiAssetList;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransaction;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransactionList;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics;
        private System.Windows.Forms.ToolStripMenuItem tsmiProfit;
    }
}