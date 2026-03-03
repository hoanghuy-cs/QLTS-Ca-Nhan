using QLTS.BLL.Assets;
using QLTS.DTO.Models;
using QLTS.GUI.Helpers;
using QLTS.GUI.Models;
using QLTS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLTS.GUI.Forms.Transactions
{
    public partial class TransactionEditForm : Form
    {
        private readonly Transaction _transaction;
        private readonly AssetBLL _assetBLL = new AssetBLL();

        public TransactionEditForm(Transaction transaction = null)
        {
            InitializeComponent();
            _transaction = transaction ?? new Transaction();
        }

        private void TransactionEditForm_Load(object sender, System.EventArgs e)
        {
            LoadAssets();
            LoadTransactionTypes();

            cboAssetId.SelectedValue = _transaction.AssetId.ToString();

            if (_transaction.Id != 0)
            {
                cboType.SelectedValue = _transaction.Type.ToString();
                nudQuantity.Value = _transaction.Quantity;
                nudUnitPrice.Value = _transaction.UnitPrice;
                nudFee.Value = _transaction.Fee;
                dtpTransactionDate.Value = _transaction.TransactionDate;
                txtNote.Text = _transaction.Note;
                Text = "Cập nhật giao dịch";
            }
            else
            {
                Text = "Tạo giao dịch";
            }
        }

        private void LoadAssets()
        {
            var assets = _assetBLL.GetAssets();
            var comboItems = new List<ComboItem>();

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

            if (comboItems.Count > 0)
            {
                cboAssetId.SelectedIndex = 0;
            }
        }

        private void LoadTransactionTypes()
        {
            var items = new List<ComboItem>();

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
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (cboAssetId.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _transaction.AssetId = Convert.ToInt32(cboAssetId.SelectedValue);
            _transaction.Type = (TransactionType)Enum.Parse(typeof(TransactionType), cboType.SelectedValue.ToString());
            _transaction.Quantity = (int)nudQuantity.Value;
            _transaction.UnitPrice = nudUnitPrice.Value;
            _transaction.Fee = nudFee.Value;
            _transaction.TransactionDate = dtpTransactionDate.Value;
            _transaction.Note = txtNote.Text;

            this.DialogResult = DialogResult.OK;
        }

        public Transaction GetTransaction()
        {
            return _transaction;
        }
    }
}
