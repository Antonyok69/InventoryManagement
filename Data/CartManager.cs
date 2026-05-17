using System.Data;
using System.Windows.Forms;

namespace InventoryApp.Data
{
    public class CartManager
    {
        // Temporary cart table while SQL Server is disabled
        public DataTable GetCartItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("ProductId", typeof(int));

            return dt;
        }

        public void UpdateQuantityInCart(int itemId, string quantity)
        {
            // Disabled for API integration testing
        }

        public decimal GetTotalPrice()
        {
            return 0;
        }

        public void RemoveCartItem(int productId)
        {
            // Disabled for API integration testing
        }

        public int GetCartItemCount()
        {
            return 0;
        }

        public void LoadCartItems(ListBox listBox)
        {
            listBox.Items.Clear();
        }
    }
}