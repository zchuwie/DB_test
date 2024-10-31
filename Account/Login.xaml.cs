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

namespace Account
{
    public partial class Login : Window
    {
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
    }
}