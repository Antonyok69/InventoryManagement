using System.Data;

namespace InventoryApp.Data
{
    public class StockManager
    {
        public int GetProductIdByName(string itemName)
        {
            return 0;
        }

        public int GetCurrentStockById(int productId)
        {
            return 0;
        }

        public void UpdateStock(int productId, int addedStock)
        {
            // Temporary disabled
        }

        public int GetProductStock(int productId)
        {
            return 0;
        }

        public void AddStock(int productId, int addedStock)
        {
            // Temporary disabled
        }

        public void InsertHistory(int productId, int addedStock)
        {
            // Temporary disabled
        }
    }
}