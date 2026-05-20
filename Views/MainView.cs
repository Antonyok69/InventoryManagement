using System;
using System.Drawing;
using InventoryApp.Data;
using System.Windows.Forms;
using InventoryApp.InventoryApp.dlg;
using InventoryApp.InventoryApp.Views;
using InventoryApp.Views;
using InventoryApp.Views.Dashboard;

namespace InventoryApp.InventoryApp
{
    public partial class MainView : Form
    {
        private Form currentForm;
        public MainView(string username)
        {
            InitializeComponent();
            ApplyModernLayout();
            SwitchForm(new Dashboard());

            button1.Text = "Logout (" + username + ")";

            // Initialize Cart item counter
            itemCountTimer = new Timer
            {
                Interval = 10000
            };
            itemCountTimer.Tick += itemCountTimer_Tick;
            itemCountTimer.Start();
        }

        //NAVIGATION CONTROL
        private void SwitchForm(Form newForm)
        {
            currentForm?.Hide();
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            // Check if panel2 already contains a form
            if (panel2.Controls.Count > 0)
            {
                Control currentFormControl = panel2.Controls[0];
                currentFormControl.Hide();
                panel2.Controls.Remove(currentFormControl);
            }
            panel2.Controls.Add(newForm);
            newForm.Show();

            currentForm = newForm;
        }

        // DASHBOARD
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                SwitchForm(new Dashboard());
            }
        }

        private void ApplyModernLayout()
        {
            this.Text = "Anton Shoe Store Sales and Inventory System";
            this.BackColor = Color.WhiteSmoke;

            panel1.BackColor = Color.FromArgb(33, 37, 41);
            panel2.BackColor = Color.FromArgb(248, 249, 250);

            radioButton5.Appearance = Appearance.Button;
            radioButton1.Appearance = Appearance.Button;
            radioButton2.Appearance = Appearance.Button;
            radioButton3.Appearance = Appearance.Button;

            RadioButton[] menuButtons =
            {
        radioButton5,
        radioButton1,
        radioButton2,
        radioButton3
    };

            foreach (RadioButton btn in menuButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(52, 58, 64);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Height = 48;
            }

            button1.BackColor = Color.FromArgb(220, 53, 69);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        //HOME TAB
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                SwitchForm(new Product());
            }
        }

        //CATEGORY TAB
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                SwitchForm(new Category());
            }
        }

        //CART TAB
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                SwitchForm(new Sale());
            }
        }

        //TRANSACTION TAB
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                SwitchForm(new Transaction());
            }
        }

        // LOGOUT BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to logout?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                UserAuth userauth = new UserAuth();
                userauth.FormClosed += (s, args) => this.Close();
                userauth.Show();
                Hide();
            }
        }

        // CART COUNTER
        private void itemCountTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                OrderManager orderManager = new OrderManager();
                int totalSales = orderManager.GetOrders().Rows.Count;

                radioButton3.Text = "Sale (" + totalSales.ToString() + ")";
            }
            catch
            {
                radioButton3.Text = "Sale";
            }
        }
    }
}
