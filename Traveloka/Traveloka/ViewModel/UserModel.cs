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
            LoginCommand = new RelayCommand(Login1);
            RegisterCommand = new RelayCommand(Register1);
             
        }
        private void Register1()
        {
            // Navigate to the registration form
            RegisterForm rg = new RegisterForm();
            rg.ShowDialog();
             
        }
            private void Login1()
            {
                using (var context = new DuLichEntities())
                {
                    var user = context.Users.FirstOrDefault(u => u.Ten == Username && u.MatKhau == Password);
                    if (user != null)
                    {
                        CurrentUser.LoggedInUser = user;
                        
                        TrangChu tc = new TrangChu();
                        tc.ShowDialog();
                   
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }

       
    }
}
