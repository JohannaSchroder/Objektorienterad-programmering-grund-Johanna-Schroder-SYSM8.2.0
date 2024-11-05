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
        //egenskaper
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

        private readonly UserService _userService;//för att komma åt metoderna i klassen UserService

        //konstruktor
        public LogInViewModel()
        {
            LogInCommand = new RelayCommand(SignIn);
            SignUpCommand = new RelayCommand(OpenRegisterWindow);
            _userService = UserService.Instance;
        }

        //kommandon
        public ICommand LogInCommand { get; }
        public ICommand SignUpCommand { get; }
        private void SignIn()//metod för att logga in
        {
            /*if (UserNameBox == "admin" && PasswordBox == "password")
            {
                WorkoutsWindow workoutsWindow = new WorkoutsWindow();
                workoutsWindow.Show();
                Application.Current.MainWindow.Close();
            }*/
           if (_userService.Login(UserNameBox, PasswordBox))
           {
                User u = new User(UserNameBox, PasswordBox, "Sweden");
                u.SignIn();
                WorkoutsWindow workoutsWindow = new WorkoutsWindow();
                workoutsWindow.Show();
                Application.Current.MainWindow.Close(); 
           }
            else
            {
                MessageBox.Show("Fel användarnamn eller lösenord");
            }
        }
        public void OpenRegisterWindow()//metod för att öppna registreringsfönster
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Application.Current.MainWindow.Close();
        }

    }

}
