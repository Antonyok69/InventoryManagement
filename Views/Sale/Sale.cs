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
            DataTable dt = orderManager.GetOrders();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayOrders();
            MessageBox.Show("Sales orders refreshed.", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayOrders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayOrders();
        }
    }
}