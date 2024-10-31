using FIT_TRACK2.Klasser;
using FIT_TRACK2.ViewModel;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        private UserService _userService;//för att komma åt metoderna i klassen UserService

        public RelayCommand LogInCommand { get; }
        public RelayCommand SignUpCommand { get; }

        public LogInViewModel()
        {
            LogInCommand = new RelayCommand(SignIn);
            SignUpCommand = new RelayCommand(OpenRegisterWindow);
            _userService = new UserService();
        }
        private void SignIn()
        {
            if (_userService.loggain(UserNameBox, PasswordBox))
            {
                WorkoutsWindow workoutsWindow = new WorkoutsWindow();
                workoutsWindow.Show();
                Application.Current.MainWindow.Close(); 
            }
            else
            {
                MessageBox.Show("Fel användarnamn eller lösenord");
            }
        }


        public void OpenRegisterWindow()
        { 
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Application.Current.MainWindow.Close();
        }

    }

}
