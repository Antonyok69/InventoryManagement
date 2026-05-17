using System;
using System.Data;
using System.Windows.Forms;

namespace InventoryApp.InventoryApp.dlg
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
            DisplayTransaction();
        }

        // TEMPORARY TRANSACTION DISPLAY
        private void DisplayTransaction()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Date");
            dt.Columns.Add("Subtotal");
            dt.Columns.Add("DiscountPercent");
            dt.Columns.Add("DiscountAmount");
            dt.Columns.Add("Total");
            dt.Columns.Add("Change");
            dt.Columns.Add("TransactionId");

            // SAMPLE DATA
            dt.Rows.Add(
                DateTime.Now.ToString("yyyy-MM-dd"),
                "4500",
                "0",
                "0",
                "4500",
                "500",
                "TRX001"
            );

            dataGridView1.DataSource = dt;
        }

        // CELL DOUBLE CLICK EVENT
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(
                "Transaction details temporarily disabled for API integration testing.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}