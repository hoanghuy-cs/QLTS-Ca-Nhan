namespace QLTS.GUI.Forms.Assets
{
    partial class AssetListForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetListForm));
            this.dgvAssets = new System.Windows.Forms.DataGridView();
            this.bdsAssets = new System.Windows.Forms.BindingSource(this.components);
            this.bdnAssets = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tsrOperation = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnTransactionHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCreateTransaction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnProfitLoss = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboQuantity = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnAssets)).BeginInit();
            this.bdnAssets.SuspendLayout();
            this.tsrOperation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAssets
            // 
            this.dgvAssets.AllowUserToAddRows = false;
            this.dgvAssets.AllowUserToDeleteRows = false;
            this.dgvAssets.AutoGenerateColumns = false;
            this.dgvAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssets.DataSource = this.bdsAssets;
            this.dgvAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssets.Location = new System.Drawing.Point(0, 112);
            this.dgvAssets.Name = "dgvAssets";
            this.dgvAssets.ReadOnly = true;
            this.dgvAssets.RowHeadersWidth = 51;
            this.dgvAssets.RowTemplate.Height = 24;
            this.dgvAssets.Size = new System.Drawing.Size(800, 307);
            this.dgvAssets.TabIndex = 0;
            // 
            // bdnAssets
            // 
            this.bdnAssets.AddNewItem = null;
            this.bdnAssets.BindingSource = this.bdsAssets;
            this.bdnAssets.CountItem = this.bindingNavigatorCountItem;
            this.bdnAssets.DeleteItem = null;
            this.bdnAssets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bdnAssets.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bdnAssets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bdnAssets.Location = new System.Drawing.Point(0, 419);
            this.bdnAssets.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnAssets.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnAssets.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnAssets.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnAssets.Name = "bdnAssets";
            this.bdnAssets.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnAssets.Size = new System.Drawing.Size(800, 31);
            this.bdnAssets.TabIndex = 1;
            this.bdnAssets.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // tsrOperation
            // 
            this.tsrOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsrOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnEdit,
            this.tsbtnDelete,
            this.toolStripSeparator1,
            this.tsbtnSearch,
            this.toolStripSeparator2,
            this.tsbtnTransactionHistory,
            this.tsbtnCreateTransaction,
            this.toolStripSeparator3,
            this.tsbtnProfitLoss});
            this.tsrOperation.Location = new System.Drawing.Point(0, 0);
            this.tsrOperation.Name = "tsrOperation";
            this.tsrOperation.Size = new System.Drawing.Size(800, 31);
            this.tsrOperation.TabIndex = 2;
            this.tsrOperation.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = global::QLTS.GUI.Properties.Resources.Add;
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(70, 24);
            this.tsbtnAdd.Text = "Thêm";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.Image = global::QLTS.GUI.Properties.Resources.Edit;
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(58, 24);
            this.tsbtnEdit.Text = "Sửa";
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = global::QLTS.GUI.Properties.Resources.Delete;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(59, 24);
            this.tsbtnDelete.Text = "Xóa";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.Image = global::QLTS.GUI.Properties.Resources.Search;
            this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.Size = new System.Drawing.Size(94, 24);
            this.tsbtnSearch.Text = "Tìm kiếm";
            this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbtnTransactionHistory
            // 
            this.tsbtnTransactionHistory.Image = global::QLTS.GUI.Properties.Resources.Transaction;
            this.tsbtnTransactionHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTransactionHistory.Name = "tsbtnTransactionHistory";
            this.tsbtnTransactionHistory.Size = new System.Drawing.Size(129, 24);
            this.tsbtnTransactionHistory.Text = "Xem giao dịch";
            this.tsbtnTransactionHistory.Click += new System.EventHandler(this.tsbtnTransactionHistory_Click);
            // 
            // tsbtnCreateTransaction
            // 
            this.tsbtnCreateTransaction.Image = global::QLTS.GUI.Properties.Resources.TransactionAdd;
            this.tsbtnCreateTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateTransaction.Name = "tsbtnCreateTransaction";
            this.tsbtnCreateTransaction.Size = new System.Drawing.Size(124, 24);
            this.tsbtnCreateTransaction.Text = "Tạo giao dịch";
            this.tsbtnCreateTransaction.Click += new System.EventHandler(this.tsbtnCreateTransaction_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbtnProfitLoss
            // 
            this.tsbtnProfitLoss.Image = global::QLTS.GUI.Properties.Resources.ProfitLoss;
            this.tsbtnProfitLoss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnProfitLoss.Name = "tsbtnProfitLoss";
            this.tsbtnProfitLoss.Size = new System.Drawing.Size(102, 24);
            this.tsbtnProfitLoss.Text = "Xem lãi/lỗ";
            this.tsbtnProfitLoss.Click += new System.EventHandler(this.tsbtnProfitLoss_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(800, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ lọc tìm kiếm";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKeyword, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboQuantity, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 46);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ khóa";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Location = new System.Drawing.Point(3, 19);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(384, 22);
            this.txtKeyword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số lượng";
            // 
            // cboQuantity
            // 
            this.cboQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuantity.FormattingEnabled = true;
            this.cboQuantity.Location = new System.Drawing.Point(393, 19);
            this.cboQuantity.Name = "cboQuantity";
            this.cboQuantity.Size = new System.Drawing.Size(384, 24);
            this.cboQuantity.TabIndex = 4;
            // 
            // AssetListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAssets);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsrOperation);
            this.Controls.Add(this.bdnAssets);
            this.Name = "AssetListForm";
            this.Text = "Danh sách tài sản";
            this.Load += new System.EventHandler(this.AssetListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnAssets)).EndInit();
            this.bdnAssets.ResumeLayout(false);
            this.bdnAssets.PerformLayout();
            this.tsrOperation.ResumeLayout(false);
            this.tsrOperation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssets;
        private System.Windows.Forms.BindingNavigator bdnAssets;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bdsAssets;
        private System.Windows.Forms.ToolStrip tsrOperation;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.ToolStripButton tsbtnEdit;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnCreateTransaction;
        private System.Windows.Forms.ToolStripButton tsbtnTransactionHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnProfitLoss;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboQuantity;
    }
}