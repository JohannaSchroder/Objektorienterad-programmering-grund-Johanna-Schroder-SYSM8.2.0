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
        }
        private void SignIn()
        {
            if (_userService.loggain(UserNameBox, PasswordBox))
            {
                WorkoutsWindow workoutsWindow = new WorkoutsWindow();
                workoutsWindow.Show();
                Application.Current.MainWindow.Close(); 
            }
            if (UserNameBox == "admin" && PasswordBox == "password")
            { 
                AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow();
                addWorkoutWindow.Show();
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
        private readonly List<User> ListaUsers = new List<User>();//en lista

        public bool loggain(string username, string password)
        {
            var user = ListaUsers.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
            return user != null && user.Password == password;
        }
        public bool UserNameTaken(string username)
        {
            return ListaUsers.Exists(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
        public void RegisterUser(string username, string password, string country)
        {
            if(UserNameTaken(username))
            {
                MessageBox.Show("Användarnamnet är upptaget!");
            }
            var newUser = new User("admin","password","Sweden")
            {
                UserName = username,
                Password = password,
                Country = country
            };
            ListaUsers.Add(newUser);
        }
    }

}
