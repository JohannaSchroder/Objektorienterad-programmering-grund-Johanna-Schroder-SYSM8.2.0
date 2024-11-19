using FIT_TRACK2.Klasser;
using FIT_TRACK2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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
            ListaUsers = new List<User>
            {
                new User("admin","password","Sweden") {UserName = "admin",
                Password = "password", Country = "Sweden", IsAdmin = true }
            };//en sparad admin-användare från start
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
            var user = ListaUsers.SingleOrDefault(u => u.UserName == username && u.Password == password); 
            if (user != null) 
            { 
                CurrentUser = user; 
                return true; 
            }
            return false; //kollar så avnändarnamn och lösenord matchar
        }

        public List<User> GetUsers()//metod för att kolla alla användare
        {
            return ListaUsers;
        }

        public void Logout()
        {
            CurrentUser = null; // tar bort användaren vid utloggning
        }

        public bool currentAdmin()//kollar om den inloggade är admin
        {
            return CurrentUser != null && CurrentUser.IsAdmin;
        }

    }



    internal class WorkoutService
    {
        private static WorkoutService _instance;
        public static WorkoutService Instance => _instance ??= new WorkoutService();


        private WorkoutService()
        {
            _workouts = new ObservableCollection<Workout>();
        }
        
        public ObservableCollection<Workout> _workouts; //lista som sparar träningspass
        public void StartWorkouts()//lägger till träningspass i listan som ska finnas från start
        {
            var strengthWorkout = new StrengthWorkout(new DateTime(), "Strength", TimeSpan.FromMinutes(60), 100, "Strenght träning", 10);

            var cardioWorkout = new CardioWorkout(new DateTime(), "Cardio", TimeSpan.FromMinutes(60), 100, "Cardio träning", 10000);

            _workouts.Add(strengthWorkout);
            _workouts.Add(cardioWorkout);
        }
        public void AddWorkout(Workout workout) //medtod för att lägga till nytt träningspass
        {
            _workouts.Add(workout);
        }
        public void RemoveWorkout(Workout workout) //metod för att ta bort träningspass
        {
            _workouts.Remove(workout);
        }

        public void SaveWorkout(Workout workout)//metod för att spara ny data i ett befintligt träningspass
        {
            var CurrentWorkout = _workouts.FirstOrDefault(w => w.Date == workout.Date && w.Type == workout.Type);
            if (CurrentWorkout != null)
            {
                CurrentWorkout.Date = workout.Date;
                CurrentWorkout.Type = workout.Type;
                CurrentWorkout.Duration = workout.Duration;
                CurrentWorkout.CaloriesBurned = workout.CaloriesBurned;
                CurrentWorkout.Notes = workout.Notes;
            }
        }
        public IEnumerable<Workout> GetWorkouts() //metod för att visa alla träningspass
        { 
             return _workouts; 
        }
        public IEnumerable<Workout> GetWorkouts(IEnumerable<User> users)
        {
            return _workouts.Where(w => users.Any(u => u.UserName == w.Type));
        }
    }
}
