using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_TRACK2.Klasser
{
    class AdminUser : User
    {
        //Egenskap


        //Konstruktor
        public AdminUser(string UserName, string Password, string Country)
            : base(UserName, Password, Country)
        {
        }

        //Metod
        public override void SignIn()//HÄR BEHÖVER DU FYLLA I KOD!!
        {

        }

        public void MenageAllWorkouts()//HÄR BEHÖVER DU FYLLA I KOD!!
        {

        }
    }
}
