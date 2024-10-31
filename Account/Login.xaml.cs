using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Account.src;

namespace Account
{
    public partial class Login : Window
    {
        Register acc = new ();
        public Login()
        {
            InitializeComponent();
        }

        private void toSignup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            acc.Username = usernameBox.Text;
            acc.Password = passwordBox.Text;

            string username = acc.login(acc);

            if (string.IsNullOrEmpty(username)) {
                MessageBox.Show("Username or password incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                resetField();
                return; 
            }

            if (username == "admin") {
                Admin a = new();
                a.Show();
                this.Close();
            } else if (username == acc.Username) {
                User u = new();
                u.Show();
                this.Close();
            } 
        }

        private void resetField() {
            acc.Username = string.Empty;
            acc.Password = string.Empty;
        }
    }
}