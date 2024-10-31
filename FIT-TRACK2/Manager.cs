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

        public bool UserNameTaken(string username)
        {
            foreach (var user in ListaUsers)
            {
                if (user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public bool RegisterUser(string username, string password, string country)
        {
            if (UserNameTaken(username))
            {
                MessageBox.Show("Användarnamnet är upptaget!");
                return false;
            }

            var newUser = new User(username, password, country);
            ListaUsers.Add(newUser);
            return true;
        }

        public bool loggain(string username, string password)
        {
            foreach (var user in ListaUsers)
            {
                if (user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return user.Password == password;
                }
            }
            return false;
        }
    }



    internal class WorkoutService
    {
        private List<Workout> _workouts = new List<Workout>();

        public IEnumerable<Workout> GetWorkouts() => _workouts;

        public void AddWorkout(Workout workout)
        {
            _workouts.Add(workout);
        }

        public void RemoveWorkout(Workout workout)
        {
            _workouts.Remove(workout);
        }
    }
}
