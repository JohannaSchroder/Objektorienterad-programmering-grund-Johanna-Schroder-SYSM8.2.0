using FIT_TRACK2.Klasser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FIT_TRACK2
{
    internal class Manager
    {
    }

    internal class UserService//klass för att lägga till nya användare och kontrollera så inte användaren redan finns
    {
        private static UserService _instance;//Singleton
        private static readonly object _lock = new object();

        private List<User> ListaUsers;//en lista för att lagra användare
        
        public User CurrentUser { get; set; }//egenskap för att hämta inloggad användare

        private UserService()
        {
            ListaUsers = new List<User>();
            ListaUsers.Add(new User ("admin", "password", "Sweden"));//en sparad användare från start
        }
        public static UserService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserService();
                    }
                    return _instance;
                }
            }
        }
        public bool UsernameExists(string username) //metod för att kolla om användaren redan finns
        { 
            return ListaUsers.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)); 
        }
        public void RegisterUser(User user)//metod för att registrera en användare
        {
            if (!ListaUsers.Any(u => u.UserName == user.UserName))//kollar om användaren finns i listan
            {
                ListaUsers.Add(user);
            }
            else
            {
                throw new System.Exception("Användarnamnet är redan upptaget.");//meddelande om användaren är upptagen
            }
            CurrentUser = user;
        }
        public bool Login(string username, string password)//metod för att logga in
        { 
            return ListaUsers.Any(u => u.UserName == username && u.Password == password); //kollar så avnändarnamn och lösenord matchar
        }

        public List<User> GetUsers()//metod för att kolla alla användare
        {
            return ListaUsers;
        }


    }



        internal class WorkoutService
        {
        private static WorkoutService _instance;//Singleton
        private static readonly object _lock = new object();
        private WorkoutService()
        { }
        public static WorkoutService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new WorkoutService();
                    }
                    return _instance;
                }
            }
        }

        private List<Workout> _workouts = new List<Workout>(); //lista som sparar träningspass
            public void AddWorkout(Workout workout) //medtod för att lägga till nytt träningspass
            { 
                _workouts.Add(workout); 
            }
            public void RemoveWorkout(Workout workout) //metod för att ta bort träningspass
            { 
                _workouts.Remove(workout); 
            }
            public List<Workout> GetWorkouts() //metod för att visa alla träningspass
            { 
                return _workouts; 
            }
        }
}
