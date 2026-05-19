using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;

namespace InventoryApp.Data
{
    public class OrderManager
    {
        private readonly HttpClient client;

        public OrderManager()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
        }

        public DataTable GetOrders()
        {
            string json = client.GetStringAsync("orders").Result;
            dynamic result = JsonConvert.DeserializeObject(json);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Customer", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Date", typeof(string));

            foreach (var o in result.orders)
            {
                dt.Rows.Add(
                    (int)o.id,
                    (string)o.customer_name,
                    (string)o.product_name,
                    (int)o.quantity,
                    Convert.ToDecimal(o.price),
                    Convert.ToDecimal(o.total),
                    (string)o.created_at
                );
            }

            return dt;
        }
    }
}