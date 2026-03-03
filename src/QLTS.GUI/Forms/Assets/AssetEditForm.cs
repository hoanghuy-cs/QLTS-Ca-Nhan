using QLTS.BLL.Units;
using QLTS.DTO.Models;
using System;
using System.Windows.Forms;

namespace QLTS.GUI.Forms.Assets
{
    public partial class AssetEditForm : Form
    {
        private readonly Asset _asset;
        private readonly UnitBLL _unitBLL = new UnitBLL();

        public AssetEditForm(Asset asset = null)
        {
            InitializeComponent();
            _asset = asset ?? new Asset();
        }

        private void AssetEditForm_Load(object sender, System.EventArgs e)
        {
            LoadUnits();

            if (_asset.Id != 0)
            {
                txtName.Text = _asset.Name;
                cboUnitId.SelectedValue = _asset.UnitId;
                txtNote.Text = _asset.Note;
                Text = "Cập nhật tài sản";
            }
            else
            {
                Text = "Thêm tài sản";
            }
        }

        private void LoadUnits()
        {
            var units = _unitBLL.GetUnits();

            cboUnitId.DataSource = units;
            cboUnitId.DisplayMember = "Name";
            cboUnitId.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _asset.Name = txtName.Text.Trim();
            _asset.UnitId = Convert.ToInt32(cboUnitId.SelectedValue);
            _asset.Note = txtNote.Text.Trim();

            this.DialogResult = DialogResult.OK;
        }

        public Asset GetAsset()
        {
            return _asset;
        }
    }
}
