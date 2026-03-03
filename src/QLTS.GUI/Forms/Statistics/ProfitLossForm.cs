using QLTS.BLL.Assets;
using QLTS.BLL.Statistics;
using QLTS.GUI.Helpers;
using QLTS.GUI.Models;
using QLTS.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLTS.GUI.Forms.Statistics
{
    public partial class ProfitLossForm : Form
    {
        private readonly AssetBLL _assetBLL = new AssetBLL();
        private readonly StatisticBLL _statisticBLL = new StatisticBLL();
        private readonly ProfitLossFilter _filter = new ProfitLossFilter();

        public ProfitLossForm(int? assetId = null)
        {
            InitializeComponent();

            _filter = new ProfitLossFilter
            {
                AssetId = assetId
            };

            if (assetId.HasValue)
            {
                cboAssetId.Enabled = false;
            }
        }

        private void ProfitLossForm_Load(object sender, System.EventArgs e)
        {
            SetupGrid();
            LoadAssets();
            LoadTransactionTypes();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvProfitLoss.AutoGenerateColumns = false;
            dgvProfitLoss.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfitLoss.MultiSelect = false;
            dgvProfitLoss.AllowUserToAddRows = false;
            dgvProfitLoss.AllowUserToResizeRows = false;
            dgvProfitLoss.RowHeadersVisible = false;

            dgvProfitLoss.Columns.Clear();

            dgvProfitLoss.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AssetName",
                HeaderText = "Tên tài sản",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvProfitLoss.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalBuyQuantity",
                HeaderText = "Số lượng mua",
                Width = 100
            });

            dgvProfitLoss.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalBuyCost",
                HeaderText = "Giá vốn mua",
                Width = 100
            });

            dgvProfitLoss.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalSellQuantity",
                HeaderText = "Số lượng bán",
                Width = 100
            });

            dgvProfitLoss.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalSellRevenue",
                HeaderText = "Doanh thu",
                Width = 100
            });

            dgvProfitLoss.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RealizedProfit",
                HeaderText = "Lợi nhuận",
                Width = 100
            });
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

            foreach (ProfitLossType type in Enum.GetValues(typeof(ProfitLossType)))
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
            var profitLoss = _statisticBLL.GetAssetProfitLoss(_filter);
            bdsProfitLoss.DataSource = profitLoss.Items;

            lblTotalBuyCost.Text = DecimalHelper.FormatVND(profitLoss.TotalBuyCost);
            lblSellRevenue.Text = DecimalHelper.FormatVND(profitLoss.TotalSellRevenue);
            lblTotalProfit.Text = DecimalHelper.FormatVND(profitLoss.TotalProfit);

            if (profitLoss.TotalProfit > 0)
            {
                lblTotalProfit.ForeColor = Color.Green;
            }
            else if (profitLoss.TotalProfit < 0)
            {
                lblTotalProfit.ForeColor = Color.Red;
            }
        }

        private void tsbtnFilter_Click(object sender, EventArgs e)
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
                _filter.Type = (ProfitLossType)Enum.Parse(typeof(ProfitLossType), cboType.SelectedValue.ToString());
            }
        }

        private void dgvProfitLoss_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var propertyName = dgvProfitLoss.Columns[e.ColumnIndex].DataPropertyName;

            if (propertyName == "TotalBuyCost" || propertyName == "TotalSellRevenue")
            {
                var number = Convert.ToDecimal(e.Value);
                e.Value = DecimalHelper.FormatVND(number);
                e.FormattingApplied = true;
            }

            if (propertyName == "RealizedProfit")
            {
                var profit = Convert.ToDecimal(e.Value);

                if (profit < 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }

                e.Value = DecimalHelper.FormatVND(profit);
                e.FormattingApplied = true;
            }
        }
    }
}
