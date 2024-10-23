using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FIT_TRACK2.Klasser
{
    class User : Person
    {
        //egenskaper
        public string Country { get; set; }

        //konstruktor
        public User(string UserName, string Password, string Country) : base(UserName, Password)
        {
            this.Country = Country;
            this.UserName = UserName;
            this.Password = Password;
        }


        //metoder
        public override void SignIn()
        {
            MessageBox.Show($"Hej {UserName}! Nu är det dags att träna.");
        }

    }
}
