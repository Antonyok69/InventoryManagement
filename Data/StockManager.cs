using System.Data;

namespace InventoryApp.Data
{
    public class StockManager
    {
        public int GetProductIdByName(string itemName)
        {
            return 0;
        }

        // FIXED NAME
        public int GetCurrentStockById(int productId)
        {
            return 0;
        }

        // FIXED METHOD
        public void UpdateStock(int productId, int addedStock)
        {
            // Disabled for API integration testing
        }

        // FIXED METHOD
        public int GetProductStock(int productId)
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