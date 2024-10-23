using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_TRACK2.Klasser
{
    abstract class Person//abstrakt basklass
    {
        //egenskaper
        public string UserName { get; set; }
        public string Password { get; set; }

        //konstruktor
        public Person(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        //metoder
        public abstract void SignIn();//abstrakt metod som måste användas i de klasser som ärver från Person

    }
}
