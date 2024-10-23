using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        //metoder
        public override void SignIn()
        {

        }

    }
}
