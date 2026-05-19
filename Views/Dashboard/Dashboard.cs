using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using InventoryApp.Data;

namespace InventoryApp.Views.Dashboard
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            ProductManager productManager = new ProductManager();
            OrderManager orderManager = new OrderManager();

            DataTable products = productManager.GetProducts();
            DataTable orders = orderManager.GetOrders();

            label3.Text = products.Rows.Count.ToString();

            decimal totalRevenue = orders.AsEnumerable()
                .Sum(row => row.Field<decimal>("Total"));

            label2.Text = "$" + totalRevenue.ToString("N0");

            label7.Text = orders.Rows.Count.ToString();

            int totalCategories = products.AsEnumerable()
                .Select(row => row.Field<string>("category"))
                .Distinct()
                .Count();

            label5.Text = totalCategories.ToString();
        }
    }
}