using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FIT_TRACK2.ViewModel
{
	class RegisterViewModel : baseViewModel
	{

		private string _userNameInput;
		public string UserNameInput
		{
			get { return _userNameInput; }
			set
			{
				_userNameInput = value;
				OnPropertyChanged();
			}
		}

		private void OnPropertyChanged()
		{
			throw new NotImplementedException();
		}

		private string _passwordInput;
		public string PasswordInput
		{
			get { return _passwordInput; }
			set
			{
				_passwordInput = value;
				OnPropertyChanged();
			}
		}

		private string _confirmedPassword;
		public string ConfirmedPassword
		{
			get { return _confirmedPassword; }
			set
			{
				_confirmedPassword = value;
				OnPropertyChanged();
			}
		}

		private string _valtLand;
		public string ValtLand
		{
			get { return _valtLand; }
			set
			{
				_valtLand = value;
				OnPropertyChanged();
			}
		}
		private UserService _userService;
        public RelayCommand SignUpCommand { get; } 

		public RegisterViewModel()
		{
            _userService = new UserService();
            SignUpCommand = new RelayCommand(SignUp);
		}
        public ObservableCollection<string> Land { get; } = new ObservableCollection<string> { "Sweden", "Denmark", "Norway", "Finland", "Iceland" };


        private void SignUp()
		{
			if (string.IsNullOrWhiteSpace(UserNameInput) ||
				string.IsNullOrWhiteSpace(PasswordInput) ||
				string.IsNullOrWhiteSpace(ConfirmedPassword) ||
				string.IsNullOrWhiteSpace(ValtLand))
			{
				MessageBox.Show("Du måste fylla i alla fält!");
				return;
			}
			if (PasswordInput != ConfirmedPassword)
			{
				MessageBox.Show("Dina lösenord matchar inte");
				return;
			}
			try
			{
				_userService.RegisterUser(UserNameInput, PasswordInput, ValtLand);
				MessageBox.Show($"Du är registrerad {UserNameInput} och kan logga in!");
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
                Application.Current.Windows.OfType<RegisterWindow>().First().Close();
            }
			catch			
			{ 
				MessageBox.Show("Gör ett nytt försök, något gick fel!");
				return;
			}
        }
    }
}

