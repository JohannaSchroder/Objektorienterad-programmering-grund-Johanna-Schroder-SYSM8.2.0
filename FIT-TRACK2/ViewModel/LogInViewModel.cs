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

        public RelayCommand LogInCommand { get; set; }
        public RelayCommand SignUpCommand { get; set; }

        public LogInViewModel()
        {
            LogInCommand = new RelayCommand(SignIn);
            SignUpCommand = new RelayCommand(OpenRegisterWindow);
        }
        private void SignIn()
        {
            if (_userService.RegistreradeUser(UserNameBox, PasswordBox))
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

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

    }
    public class UserService//klass för att lägga till nya användare och kontrollera så inte användaren redan finns
    {
        private List<User> ListaUsers = new List<User>();//en lista

        public bool RegistreradeUser(string username, string password)
        {
            foreach (var user in ListaUsers)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public void RegisterUser(string username, string password, string country)
        {
            foreach (var user in ListaUsers)
            {
                if (user.UserName == username)
                {
                    MessageBox.Show("Användarnamnet är upptaget");
                }
            }
            ListaUsers.Add(new User("admin", "password", "sweden") { UserName = username, Password = password, Country = country });
        }
    }

}
