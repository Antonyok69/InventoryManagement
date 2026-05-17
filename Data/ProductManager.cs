using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.IO;

namespace InventoryApp.Data
{
    public class ProductManager
    {
        private readonly HttpClient client;

        public ProductManager()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
        }

        public DataTable GetProducts()
        {
            string json = client.GetStringAsync("products").Result;
            dynamic result = JsonConvert.DeserializeObject(json);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("price", typeof(int));
            dt.Columns.Add("stock", typeof(int));
            dt.Columns.Add("unit", typeof(int));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("image", typeof(string));

            foreach (var p in result.products)
            {
                dt.Rows.Add(
                    (int)p.id,
                    (string)p.name,
                    Convert.ToInt32(Convert.ToDecimal(p.price)),
                    p.stock == null ? 0 : Convert.ToInt32(p.stock),
                    0,
                    (string)p.category,
                    (string)p.image
                );
            }

            return dt;
        }

        public DataTable SearchProducts(string searchTerm)
        {
            DataTable allProducts = GetProducts();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return allProducts;

            var filteredRows = allProducts.AsEnumerable()
                .Where(row =>
                    row.Field<string>("name").ToLower().Contains(searchTerm.ToLower()) ||
                    row.Field<string>("category").ToLower().Contains(searchTerm.ToLower())
                );

            if (!filteredRows.Any())
                return allProducts.Clone();

            return filteredRows.CopyToDataTable();
        }

        public string[] GetCategoryItems()
        {
            return new string[]
            {
                "Men",
                "Women"
            };
        }

        public void InsertProduct(string name, int price, int stock, string category, string image)
        {
            var product = new
            {
                name = name,
                price = price,
                stock = stock,
                category = category,
                image = string.IsNullOrWhiteSpace(image) ? "default.jpg" : Path.GetFileName(image)
            };

            string json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("products", content).Result;
            response.EnsureSuccessStatusCode();
        }
        public void UpdateProduct(int id, string name, int price, int stock, string category, string image)
        {
            var product = new
            {
                name = name,
                price = price,
                stock = stock,
                category = category,
                image = string.IsNullOrWhiteSpace(image) ? "default.jpg" : Path.GetFileName(image)
            };

            string json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync("products/" + id, content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage response = client.DeleteAsync("products/" + id).Result;
            response.EnsureSuccessStatusCode();
        }

        public void InsertCategory(string categoryItem)
        {
            // No need database category table for now.
            // Category is sent directly to Laravel API.
        }

        public static bool AddItemToCart(string name, int price)
        {
            return true;
        }
    }
}