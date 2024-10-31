using FIT_TRACK2.Klasser;
using System;
using System.Collections.Generic;
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
        private List<User> ListaUsers = new List<User>();//en lista
        public User CurrentUser { get; private set; }

        public void RegisterUser(User user)
        {
            if (!ListaUsers.Any(u => u.UserName == user.UserName))
            {
                ListaUsers.Add(user);
            }
            else
            {
                throw new System.Exception("Användarnamnet är redan upptaget.");
            }
            CurrentUser = user;
        }
        public bool Login(string username, string password)
        { 
            return ListaUsers.Any(u => u.UserName == username && u.Password == password); 
        }

        public List<User> GetUsers()
        {
            return ListaUsers;
        }


    }



        internal class WorkoutService
        {
            private List<Workout> _workouts = new List<Workout>(); 
            public void AddWorkout(Workout workout) 
            { 
                _workouts.Add(workout); 
            }
            public void RemoveWorkout(Workout workout) 
            { 
                _workouts.Remove(workout); 
            }
            public List<Workout> GetWorkouts() 
            { 
                return _workouts; 
            }
        }
}
