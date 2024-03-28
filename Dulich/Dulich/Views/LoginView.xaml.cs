using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dulich.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Thêm mã kiểm tra thông tin đăng nhập ở đây
            if (username == "1" && password == "1")
            {
                lblMessage.Visibility = Visibility.Collapsed;
                MessageBox.Show("Login successful!");
                // Add logic to navigate to next page or perform actions after successful login
                TrangChuView tc = new TrangChuView();
                tc.Show();
            }
            else
            {
                lblMessage.Visibility = Visibility.Visible;
                lblMessage.Text = "Invalid username or password!";
            }
        }
    }
}
