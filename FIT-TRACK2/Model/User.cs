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


        public class Användare//en klass för att spara och lagra användare
        {

            private List<User> ListaUsers;//en tom lista

            public Användare()//Konstruktor till listan med användare
            {
                ListaUsers = new List<User>();//en lista att fylla med användare
                //lägg in användare här.
            }

            public void RegistreradeUsers(User newUser)//metod för att lägga till en ny användare
            {
                ListaUsers.Add(newUser);
            }
            public bool UsernameUpptaget(string userName)//en metod för att kolla om användarnamn är upptaget vid registrering
            {
                foreach (var user in ListaUsers)
                {
                    if (user.UserName == userName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
