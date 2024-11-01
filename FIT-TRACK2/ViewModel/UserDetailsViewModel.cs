using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
    class UserDetailsViewModel : baseViewModel
    {
        private readonly UserService _userService;//hämtar UserService

		//egenskaper
        private string _username;
		public string NewUserNameInput
        {
			get { return _username; }
			set { _username = value; OnPropertyChanged(); }
		}

		private string _newpassword;
		public string NewPasswordInput
		{
			get { return _newpassword; }
			set { _newpassword = value; OnPropertyChanged(); }
		}

		private string _cofirmpassword;
		public string NewConfirmedPassword
        {
			get { return _cofirmpassword; }
			set { _cofirmpassword = value; OnPropertyChanged(); }
		}

		private string _selectedcountry;
		public string NewValtLand
        {
			get { return _selectedcountry; }
			set { _selectedcountry = value; }
		}

        public ObservableCollection<string> Land { get; set; }	//Lista
        public ICommand UptadeUserCommand { get; }//kommandon
        public ICommand GoBackCommand { get; }
        public UserDetailsViewModel()//konstruktor
		{
            _userService = UserService.Instance;//UserService
            NewUserNameInput = _userService.CurrentUser.UserName; 
			NewValtLand = _userService.CurrentUser.Country;
            Land = new ObservableCollection<string> { "Sweden", "Denmark", "Norway", "Finland", "Iceland" };//lista med land
            UptadeUserCommand = new RelayCommand(Spara); 
			GoBackCommand = new RelayCommand(GoBack);
        }

		private void Spara()//metod för att spara ntt användarnamn och läsenord
		{ 
			
		}

		private void GoBack()//metod för att gå tillbaka
		{ 
			WorkoutsWindow workoutsWindow = new WorkoutsWindow();
			workoutsWindow.Show();
		}



	}
}
