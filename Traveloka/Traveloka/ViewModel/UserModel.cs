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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { Set(ref _confirmPassword, value); }
        }
        public RelayCommand RegisterCommand { get; private set; }
        public RelayCommand RegisterCommand1 { get; }
        public RelayCommand LoginCommand { get; private set; }

        public UserModel()
        {
            
            RegisterCommand = new RelayCommand(Register1);
            RegisterCommand1 = new RelayCommand(Register);
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

        private void Register()
        {
            
            using (var context = new DuLichEntities())
            {
                // Check if username already exists
                var existingUser = context.Users.FirstOrDefault(u => u.Ten == Username);
                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists. Please choose a different one.");
                    return;
                }

                // Create a new user
                var newUser = new User
                {
                    Ten = Username,
                    MatKhau = Password,
                    Role = 0
                    // Set default role here if needed
                };

                // Add user to database
                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("Registration successful. You can now log in.");
            }
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

        }



    }
}
