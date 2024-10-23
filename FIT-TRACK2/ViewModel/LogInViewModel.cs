using FIT_TRACK2.Klasser;
using FIT_TRACK2.ViewModel;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FIT_TRACK2
{
    class LogInViewModel : baseViewModel
    {
        private string _username;
            public string Username
        {
            get { return _username; }
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        AdminUser AdminAdmin = new AdminUser("admin", "password", "Sweden");
        User UserUser = new User("viva", "hamster", "Sweden");

        //metoder
        public void SignIn()
        {
            if (Username == "admin" && Password == "password")
            {
                AdminAdmin.SignIn();
                AddWorkoutWindow AddWindow= new AddWorkoutWindow();
                AddWindow.Show();
            }
            else
            {
                UserUser.SignIn();
                UserDetailWindow UserWindow = new UserDetailWindow();
                UserWindow.Show();
            }

        }


        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
