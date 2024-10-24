using FIT_TRACK2.Klasser;
using System;
using System.Collections.Generic;
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

        public List<string> Country { get; set; }//en lista med land
		User.Användare _användare = new User.Användare();//hämtar från klassen Användare i modellen User

		public void SignUp()
		{
            Country = new List<string> { "Sweden", "Denmark", "Norway", "Finland", "Iceland" };//en ifylld lista med land
            if (string.IsNullOrEmpty(UserNameInput))//så inte användaren lämnar tomt
			{
				MessageBox.Show("Du måste välja ett användarnamn");
				return;
			}
			if (string.IsNullOrEmpty(PasswordInput) || string.IsNullOrEmpty(ConfirmedPassword))//så inte användaren lämnar tomt
            {
				MessageBox.Show("Du måste välja ett lösenord");
				return;
			}
			if (PasswordInput != ConfirmedPassword)//kontrollerar så lösenorden är samma
			{
				MessageBox.Show("Lösenordet överrenstämmer inte");
				return;
			}
			if (string.IsNullOrEmpty(ValtLand))//man måste välja ett land
			{
				MessageBox.Show("Du måste välja ett land");
			}

			User NewUser = new User("admin", "password", "Sweden")
			{ 
				UserName = UserNameInput, Password = PasswordInput, Country = ValtLand
			};

			_användare.RegistreradeUsers(NewUser);

			MessageBox.Show("Registreringen är färdig! Du tas tillbaka till inloggningssidan.");
		}
    }
}

