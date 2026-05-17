using System.Data;

namespace InventoryApp.Data
{
    public class StockManager
    {
        public int GetProductIdByName(string itemName)
        {
            return 0;
        }

        public int GetCurrentStock(int productId)
        {
            return 0;
        }

        public void AddStock(int productId, int addedStock)
        {
            // Disabled for API integration testing
        }

        public void InsertHistory(int productId, int addedStock)
        {
            // Disabled for API integration testing
        }
    }
}