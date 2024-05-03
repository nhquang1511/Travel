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
using Traveloka.ViewModel;
using Traveloka.views.admin;

namespace Traveloka.views.user
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
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

                // Add logic to navigate to next page or perform actions after successful login
                TrangChu tc = new TrangChu();
                tc.Show();
            }
            else if (username == "2" && password == "2")
            {
                lblMessage.Visibility = Visibility.Collapsed;

                // Add logic to navigate to next page or perform actions after successful login
                QuanLyKhachSan tc = new QuanLyKhachSan();
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

