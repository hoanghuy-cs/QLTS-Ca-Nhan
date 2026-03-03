using Mapster;
using QLTS.BLL.Assets;
using QLTS.BLL.Transactions;
using QLTS.DTO.DTOs;
using QLTS.DTO.Models;
using QLTS.GUI.Helpers;
using QLTS.GUI.Models;
using QLTS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLTS.GUI.Forms.Transactions
{
    public partial class TransactionListForm : Form
    {
        private readonly TransactionBLL _transactionBLL = new TransactionBLL();
        private readonly AssetBLL _assetBLL = new AssetBLL();
        private readonly TransactionFilter _filter;

        public TransactionListForm(int? assetId = null)
        {
            InitializeComponent();

            _filter = new TransactionFilter
            {
                AssetId = assetId,
                TransactionDateFrom = new DateTime(2000, 1, 1),
                TransactionDateTo = DateTime.Now
            };

            if (assetId.HasValue)
            {
                cboAssetId.Enabled = false;
            }
        }

        private void TransactionListForm_Load(object sender, System.EventArgs e)
        {
            SetupGrid();
            SetupDateTimePickers();
            LoadAssets();
            LoadTransactionTypes();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.RowHeadersVisible = false;

            dgvTransactions.Columns.Clear();

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã",
                Width = 60
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AssetName",
                HeaderText = "Tên tài sản",
                Width = 200
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Loại",
                Width = 80
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Width = 80
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Width = 120
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fee",
                HeaderText = "Phí giao dịch",
                Width = 120
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TransactionDate",
                HeaderText = "Ngày giao dịch",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm"
                }
            });

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Note",
                HeaderText = "Ghi chú",
                Width = 150
            });
        }

        private void SetupDateTimePickers()
        {
            dtpTransactionDateFrom.Value = _filter.TransactionDateFrom ?? new DateTime(2000, 1, 1);
            dtpTransactionDateFrom.ValueChanged += dtpTransactionDateFrom_ValueChanged;

            dtpTransactionDateTo.Value = _filter.TransactionDateTo ?? DateTime.Now;
            dtpTransactionDateTo.ValueChanged += dtpTransactionDateTo_ValueChanged;
        }

        private void LoadAssets()
        {
            var assets = _assetBLL.GetAssets();
            var comboItems = new List<ComboItem>
            {
                new ComboItem { Text = "Tất cả", Value = null }
            };

            foreach (var ass in assets)
            {
                comboItems.Add(new ComboItem
                {
                    Text = $"{ass.Name} (Đơn vị: {ass.UnitName})",
                    Value = ass.Id.ToString()
                });
            }

            cboAssetId.DataSource = comboItems;
            cboAssetId.DisplayMember = "Text";
            cboAssetId.ValueMember = "Value";

            if (_filter.AssetId.HasValue)
            {
                cboAssetId.SelectedValue = _filter.AssetId.Value.ToString();
            }

            cboAssetId.SelectedIndexChanged += cboAssetId_SelectedIndexChanged;
        }

        private void LoadTransactionTypes()
        {
            var items = new List<ComboItem>
            {
                new ComboItem { Text = "Tất cả", Value = null }
            };

            foreach (TransactionType type in Enum.GetValues(typeof(TransactionType)))
            {
                items.Add(new ComboItem
                {
                    Text = EnumHelper.GetEnumDescription(type),
                    Value = type.ToString()
                });
            }

            cboType.DataSource = items;
            cboType.DisplayMember = "Text";
            cboType.ValueMember = "Value";
            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
        }

        private void LoadData()
        {
            var data = _transactionBLL.GetTransactions(_filter);
            bdsTransactions.DataSource = data;
        }

        private void tsbtnAdd_Click(object sender, System.EventArgs e)
        {
            using (var form = new TransactionEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var transaction = form.GetTransaction();
                    _transactionBLL.Create(transaction);
                    LoadData();
                }
            }
        }

        private void tsbtnEdit_Click(object sender, System.EventArgs e)
        {
            var current = bdsTransactions.Current as TransactionItemDTO;
            if (current == null) return;

            using (var form = new TransactionEditForm(current.Adapt<Transaction>()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var transaction = form.GetTransaction();
                    _transactionBLL.Update(transaction);
                    LoadData();
                }
            }
        }

        private void tsbtnDelete_Click(object sender, System.EventArgs e)
        {
            var current = bdsTransactions.Current as TransactionItemDTO;
            if (current == null) return;

            var confirm = MessageBox.Show(
                "Bạn có muốn xóa thông tin giao dịch này?",
                "Xóa thông tin giao dịch",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _transactionBLL.Delete(current.Id);
                LoadData();
            }
        }

        private void dgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var propertyName = dgvTransactions.Columns[e.ColumnIndex].DataPropertyName;

            if (propertyName == "UnitPrice" || propertyName == "Fee")
            {
                var number = Convert.ToDecimal(e.Value);
                e.Value = DecimalHelper.FormatVND(number);
                e.FormattingApplied = true;
            }

            if (propertyName == "Type")
            {
                var enumValue = (Enum)e.Value;
                e.Value = EnumHelper.GetEnumDescription(enumValue);
                e.FormattingApplied = true;
            }

            if (propertyName == "AssetName")
            {
                var row = dgvTransactions.Rows[e.RowIndex].DataBoundItem as TransactionItemDTO;
                e.Value = $"{row.AssetName} (Đơn vị: {row.AssetUnitName})";
                e.FormattingApplied = true;
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboAssetId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAssetId.SelectedIndex == 0)
            {
                _filter.AssetId = null;
            }
            else
            {
                _filter.AssetId = Convert.ToInt32(cboAssetId.SelectedValue);
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                _filter.Type = null;
            }
            else
            {
                _filter.Type = (TransactionType)Enum.Parse(typeof(TransactionType), cboType.SelectedValue.ToString());
            }
        }

        private void dtpTransactionDateFrom_ValueChanged(object sender, EventArgs e)
        {
            _filter.TransactionDateFrom = dtpTransactionDateFrom.Value;
        }

        private void dtpTransactionDateTo_ValueChanged(object sender, EventArgs e)
        {
            _filter.TransactionDateTo = dtpTransactionDateTo.Value;
        }
    }
}
