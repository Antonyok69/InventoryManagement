using System;
using System.Data;
using System.Windows.Forms;

namespace InventoryApp.InventoryApp.dlg
{
    public partial class History : Form
    {
        private readonly int productId;

        public History(int id)
        {
            InitializeComponent();
            productId = id;
            DisplayHistory();
        }

        // TEMPORARY HISTORY DISPLAY
        private void DisplayHistory()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("Added Stocks", typeof(int));
            dt.Columns.Add("Date", typeof(string));

            // no stock history yet because SQL Server is disabled
            dataGridView1.DataSource = dt;
        }
    }
}