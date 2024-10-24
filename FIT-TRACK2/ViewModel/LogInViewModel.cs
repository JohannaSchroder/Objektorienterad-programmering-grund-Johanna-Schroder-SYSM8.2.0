using FIT_TRACK2.Klasser;
using FIT_TRACK2.ViewModel;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FIT_TRACK2
{
    class LogInViewModel : baseViewModel//har gjort en klass så jag ska slippa lägga in Inotify..
    {
        private string _username;
            public string UserNameBox
        {
            get { return _username; }
            set 
            { 
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string PasswordBox
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged();
            }
        }
        //metoder
        AdminUser AdminAdmin = new AdminUser("admin", "password", "Sweden");
        User UserUser = new User("viva", "hamster", "Sweden");
        public void SignIn()
        {
            if (UserNameBox == "admin" && PasswordBox == "password")
            {
                AdminAdmin.MenageAllWorkouts();
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

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

    }
}
