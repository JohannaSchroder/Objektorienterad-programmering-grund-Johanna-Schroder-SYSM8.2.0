using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_TRACK2.ViewModel
{
    class RegisterViewModel : baseViewModel
    {
        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

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

		private string _land;
		public string Land
		{
			get { return _land; }
			set 
			{ 
				_land = value; 
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
                OnPropertyChanged(nameof(Land));
            }
		}

        public List<string> LandLista { get; set; }
		LandLista = new List<string> {"Sweden", "Denmark", "Norway", "Finland", "Iceland"}


}

