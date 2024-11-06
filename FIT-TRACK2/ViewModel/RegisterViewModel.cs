using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
	class RegisterViewModel : baseViewModel
	{
		//egenskaper
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
		private readonly UserService _userService;
        public ICommand SignUpCommand { get; }
        //konstruktor
        public RegisterViewModel()
		{
            _userService = UserService.Instance;
            SignUpCommand = new RelayCommand(SignUp);
        }
        public ObservableCollection<string> Land { get; } = new ObservableCollection<string> { "Sweden", "Denmark", "Norway", "Finland", "Iceland" };
		//lista med länder
		private void SignUp()//metod för att registrera sig
		{

			if (string.IsNullOrWhiteSpace(UserNameInput) ||
				string.IsNullOrWhiteSpace(PasswordInput) ||
				string.IsNullOrWhiteSpace(ConfirmedPassword) ||
				string.IsNullOrWhiteSpace(ValtLand))
			{
                MessageBox.Show("Du måste fylla i alla rutor!");
				return;
			}
			if (PasswordInput != (ConfirmedPassword))
			{
				MessageBox.Show("Lösenorden matchar inte!");
				return;
			}
			else
			{
				try
				{
					_userService.RegisterUser(new User("admin", "password", "Sweden")
					{ UserName = UserNameInput, Password = PasswordInput, Country = ValtLand });
					MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
				catch (System.Exception ex)
				{
					MessageBox.Show("Något gick fel, försök igen!");
				}
			}
		}
    }
}

