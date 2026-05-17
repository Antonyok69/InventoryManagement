using System.Data;

namespace InventoryApp.Data
{
    public class CategoryManager
    {
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("CategoryItem", typeof(string));

            dt.Rows.Add(1, "Running");
            dt.Rows.Add(2, "Basketball");
            dt.Rows.Add(3, "Casual");
            dt.Rows.Add(4, "Sneakers");
            dt.Rows.Add(5, "Men");
            dt.Rows.Add(6, "Women");

            return dt;
        }

        public void AddCategory(string categoryItem)
        {
            // Disabled for API integration testing
        }

        public void UpdateCategory(int id, string categoryItem)
        {
            // Disabled for API integration testing
        }

        public void DeleteCategory(int id)
        {
            // Disabled for API integration testing
        }
    }
}