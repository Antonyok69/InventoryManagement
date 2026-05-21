using System;
using System.Data;
using System.Windows.Forms;
using InventoryApp.Data;

namespace InventoryApp.InventoryApp.Views
{
    public partial class Sale : Form
    {
        private readonly OrderManager orderManager;

        public Sale()
        {
            InitializeComponent();
            orderManager = new OrderManager();
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = true;

            DataTable dt = orderManager.GetOrders();
            dataGridView1.DataSource = dt;

            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 120;
            }

            if (dataGridView1.Columns["Address"] != null)
            {
                dataGridView1.Columns["Address"].Width = 220;
            }

            if (dataGridView1.Columns["Date"] != null)
            {
                dataGridView1.Columns["Date"].Width = 160;
            }
        }
         // CHECK BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order checked successfully.", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayOrders();
        }

        // REMOVE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                if (MessageBox.Show("Remove this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    orderManager.DeleteOrder(id);
                    DisplayOrders();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayOrders();
        }
    }
}