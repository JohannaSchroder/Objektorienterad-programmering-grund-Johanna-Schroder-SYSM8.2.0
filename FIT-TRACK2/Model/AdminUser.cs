using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FIT_TRACK2.Klasser
{
    class AdminUser : User
    {
        //Egenskap

        //Konstruktor
        public AdminUser(string UserName, string Password, string Country)
            : base(UserName, Password, Country)
        {
            this.Country = Country;
            this.UserName = UserName;
            this.Password = Password;
        }

        //Metod

        public void MenageAllWorkouts()//HÄR BEHÖVER DU FYLLA I KOD!!
        {
            MessageBox.Show("Hej Admin! Här kan du lägga till och ändra träningspass");
        }
    }
}
