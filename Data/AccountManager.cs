using System.Windows.Forms;

namespace InventoryApp.Data
{
    class AccountManager
    {
        // Temporary login for API integration testing
        public int ValidateUserCredentials(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return 1; // valid user
            }

            return 0; // invalid user
        }

        // Temporary register disabled
        public void RegisterUser(string username, string password)
        {
            MessageBox.Show(
                "Registration disabled for API integration testing. Use admin/admin.",
                "Registration",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private bool IsUsernameExists(string username)
        {
            return false;
        }
    }
}