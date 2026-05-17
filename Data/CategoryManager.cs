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

            dt.Rows.Add(1 , "Men");
            dt.Rows.Add(2, "Women");

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