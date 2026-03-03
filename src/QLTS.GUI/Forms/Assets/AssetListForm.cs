using Mapster;
using QLTS.BLL.Assets;
using QLTS.BLL.Transactions;
using QLTS.DTO.DTOs;
using QLTS.DTO.Models;
using QLTS.GUI.Forms.Statistics;
using QLTS.GUI.Forms.Transactions;
using QLTS.GUI.Helpers;
using QLTS.GUI.Models;
using QLTS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLTS.GUI.Forms.Assets
{
    public partial class AssetListForm : Form
    {
        private readonly AssetBLL _assetBLL = new AssetBLL();
        private readonly TransactionBLL _transactionBLL = new TransactionBLL();
        private readonly AssetFilter _filter = new AssetFilter();

        public AssetListForm()
        {
            InitializeComponent();
        }

        private void AssetListForm_Load(object sender, System.EventArgs e)
        {
            SetupGrid();
            SetupFilter();
            LoadAssetQuantityTypes();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvAssets.AutoGenerateColumns = false;
            dgvAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssets.MultiSelect = false;
            dgvAssets.AllowUserToAddRows = false;
            dgvAssets.AllowUserToResizeRows = false;
            dgvAssets.RowHeadersVisible = false;

            dgvAssets.Columns.Clear();

            dgvAssets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã",
                Width = 60
            });

            dgvAssets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Tên tài sản",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAssets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitName",
                HeaderText = "Đơn vị",
                Width = 80
            });

            dgvAssets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng hiện có",
                Width = 150
            });

            dgvAssets.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Ghi chú",
                Width = 150
            });
        }

        private void SetupFilter()
        {
            txtKeyword.TextChanged += txtKeyword_TextChanged;
        }

        private void LoadAssetQuantityTypes()
        {
            var items = new List<ComboItem>
            {
                new ComboItem { Text = "Tất cả", Value = null }
            };

            foreach (AssetQuantityType type in Enum.GetValues(typeof(AssetQuantityType)))
            {
                items.Add(new ComboItem
                {
                    Text = EnumHelper.GetEnumDescription(type),
                    Value = type.ToString()
                });
            }

            cboQuantity.DataSource = items;
            cboQuantity.DisplayMember = "Text";
            cboQuantity.ValueMember = "Value";
            cboQuantity.SelectedIndexChanged += cboQuantity_SelectedIndexChanged;
        }

        private void LoadData()
        {
            var data = _assetBLL.GetAssets(_filter);
            bdsAssets.DataSource = data;
        }

        private void tsbtnAdd_Click(object sender, System.EventArgs e)
        {
            using (var form = new AssetEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var asset = form.GetAsset();
                    _assetBLL.Create(asset);
                    LoadData();
                }
            }
        }

        private void tsbtnEdit_Click(object sender, System.EventArgs e)
        {
            var current = bdsAssets.Current as AssetItemDTO;
            if (current == null) return;

            using (var form = new AssetEditForm(current.Adapt<Asset>()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var asset = form.GetAsset();
                    _assetBLL.Update(asset);
                    LoadData();
                }
            }
        }

        private void tsbtnDelete_Click(object sender, System.EventArgs e)
        {
            var current = bdsAssets.Current as AssetItemDTO;
            if (current == null) return;

            var confirm = MessageBox.Show(
                "Bạn có muốn xóa thông tin tài sản này?\r\n" +
                "Lưu ý: Tất cả giao dịch tương ứng cũng sẽ bị xóa",
                "Xóa thông tin tài sản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                _assetBLL.Delete(current.Id);
                LoadData();
            }
        }

        private void tsbtnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void tsbtnCreateTransaction_Click(object sender, System.EventArgs e)
        {
            var current = bdsAssets.Current as AssetItemDTO;
            if (current == null) return;

            var transaction = new Transaction { AssetId = current.Id };

            using (var form = new TransactionEditForm(transaction))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    transaction = form.GetTransaction();
                    _transactionBLL.Create(transaction);
                    LoadData();
                }
            }
        }

        private void tsbtnTransactionHistory_Click(object sender, System.EventArgs e)
        {
            var current = bdsAssets.Current as AssetItemDTO;
            if (current == null) return;

            using (var form = new TransactionListForm(current.Id))
            {
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ShowDialog();
            }
        }

        private void tsbtnProfitLoss_Click(object sender, System.EventArgs e)
        {
            var current = bdsAssets.Current as AssetItemDTO;
            if (current == null) return;

            using (var form = new ProfitLossForm(current.Id))
            {
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ShowDialog();
            }
        }

        private void txtKeyword_TextChanged(object sender, System.EventArgs e)
        {
            _filter.Keyword = txtKeyword.Text;
        }

        private void cboQuantity_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _filter.QuantityType = (AssetQuantityType)Enum.Parse(typeof(AssetQuantityType), cboQuantity.SelectedValue.ToString());
        }
    }
}
