using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Traveloka.Models;
using Traveloka.views.admin;
using Traveloka.views.user;

namespace Traveloka.ViewModel
{
    public class UserModel : ViewModelBase
    {
        
        private string _username;
        public string Username
        {
            get { return _username; }
            set { Set(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }

        public RelayCommand RegisterCommand { get; private set; }
        public RelayCommand LoginCommand { get; private set; }

        public UserModel()
        {
            
            RegisterCommand = new RelayCommand(Register1);
            LoginCommand = new RelayCommand(Login);
        }
        private void Register1()
        {
            // Navigate to the registration form
            RegisterForm rg = new RegisterForm();
            rg.ShowDialog();
             
        }
        private void Login()
        {
            using (var context = new DuLichEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.Ten == Username && u.MatKhau == Password);
                if (user != null)
                {
                    CurrentUser.LoggedInUser = user;
                    if (user.Role == 1)
                    {
                        // Redirect to admin interface
                        // You can implement navigation logic here
                        // For example, you can show admin view in a dialog or navigate to a different page
                        QuanLyKhachSan adminView = new QuanLyKhachSan();
                        adminView.ShowDialog();
                    }
                    else
                    {
                        // Redirect to home page
                        // Similarly, implement navigation logic here
                        TrangChu homePage = new TrangChu();
                        homePage.ShowDialog();
                    }
                }
                else
                {
                    // Show error message for invalid credentials
                    MessageBox.Show("Invalid username or password");
                }
            }
        }




    }
}
