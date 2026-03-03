using QLTS.GUI.Forms.Assets;
using QLTS.GUI.Forms.Statistics;
using QLTS.GUI.Forms.Transactions;
using System.Windows.Forms;

namespace QLTS.GUI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiAssetList_Click(object sender, System.EventArgs e)
        {
            var assetListForm = new AssetListForm();
            assetListForm.MdiParent = this;
            assetListForm.Show();
        }

        private void tsmiTransactionList_Click(object sender, System.EventArgs e)
        {
            var transactionListForm = new TransactionListForm();
            transactionListForm.MdiParent = this;
            transactionListForm.Show();
        }

        private void tsmiProfit_Click(object sender, System.EventArgs e)
        {
            var profitLossForm = new ProfitLossForm();
            profitLossForm.MdiParent = this;
            profitLossForm.Show();
        }
    }
}
