using System;
using InventoryApp.Data;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class ProductDialog : Form
    {
        private readonly ProductManager productManager;
        private readonly int itemId;

        public ProductDialog(ProductManager manager)
        {
            InitializeComponent();
            productManager = manager;

            comboBox1.Items.AddRange(productManager.GetCategoryItems());
            Text = "Add New Product";
        }

        public ProductDialog(ProductManager manager, int id, string name, int price, int stock, int unit, string category)
        {
            InitializeComponent();
            productManager = manager;
            itemId = id;

            textBox1.Text = name;
            textBox2.Text = price.ToString();
            textBox3.Text = stock.ToString();
            textBox4.Text = "default.jpg";
            comboBox1.Text = category;

            comboBox1.Items.AddRange(productManager.GetCategoryItems());
            Text = "Edit Product";
        }

        private void SaveProduct()
        {
            string imagePath = string.IsNullOrWhiteSpace(textBox4.Text)
                ? "default.jpg"
                : textBox4.Text;

            if (itemId == 0)
            {
                productManager.InsertProduct(
                    textBox1.Text,
                    Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox3.Text),
                    comboBox1.Text,
                    imagePath
                );
            }
            else
            {
                productManager.UpdateProduct(
                    itemId,
                    textBox1.Text,
                    Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox3.Text),
                    comboBox1.Text,
                    imagePath
                );
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) { }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) { }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) { }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e) { }
    }
}