using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
    class WorkoutsViewModel : baseViewModel
    {
        //för att komma åt det som ligger i manager
        private readonly WorkoutService _workoutService;
        private readonly UserService _userService;

        //egenskaper
        private Workout _selectedWorkout;
        public Workout SelectedWorkout
        {
            get { return _selectedWorkout; }
            set { _selectedWorkout = value; OnPropertyChanged(); }
        }

        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(UserName)); }
        }

        //Kommandon
        public ICommand RemoveWorkoutCommand { get; set; }
        public ICommand SignOutCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand ShowUserCommand { get; }
        public ICommand ShowInfoCommand { get; }
        public ICommand OpenUserDetailWindow { get; }
        public ICommand OpenAddWorkoutCommand { get; }


        //konstruktor
        public WorkoutsViewModel()
        {
            _workoutService = WorkoutService.Instance; //hämta instansen av WorkoutService och UserService
            _userService = UserService.Instance;
            UserName = _userService.CurrentUser?.UserName;// hämtar användarnamnet för den inloggade användaren
            AdminOnline = _userService.currentAdmin();
            ShowWorkoutsAdmin();
            //bindning till metoder
            RemoveWorkoutCommand = new RelayCommand(RemoveWorkout, CanExecuteWorkoutCommand);
            ShowDetailsCommand = new RelayCommand(ViewDetails, CanExecuteWorkoutCommand);
            SignOutCommand = new RelayCommand(SignOut);
            ShowInfoCommand = new RelayCommand(ShowInfo);
            OpenUserDetailWindow = new RelayCommand(OpenUserDetail);
            OpenAddWorkoutCommand = new RelayCommand(OpenAddWorkout);
            Workouts = new ObservableCollection<Workout>(_workoutService.GetWorkouts());//lista med workouts
            SelectedWorkouts = new ObservableCollection<Workout>();
            AddWorkouts();//lägga till träningspass
        }


        public ObservableCollection<Workout> Workouts { get; set; }//listor
        public ObservableCollection<Workout> SelectedWorkouts { get; set; }
        public bool AdminOnline { get; set; }

        private void AddWorkouts()//läger till träningspass i listan
        {
            var strengthWorkout = new StrengthWorkout(DateTime.Now, "Strength", TimeSpan.Zero, 100, "Strenght träning", 10)
            {
            };

            var cardioWorkout = new CardioWorkout(DateTime.Now, "Cardio", TimeSpan.Zero, 100, "Cardio träning", 10000)
            {
            };

            Workouts.Add(strengthWorkout);
            Workouts.Add(cardioWorkout);
        }


        private void ShowWorkoutsAdmin()//visar alla träningspass i listan som användare lagt till
        {
            if (AdminOnline)
            {
                Workouts = new ObservableCollection<Workout>(_workoutService.GetWorkouts());
            }
            else
            {    
                Workouts = new ObservableCollection<Workout>(_workoutService.GetWorkouts(_userService.GetUsers()));
            }
        }
        private void OpenAddWorkout()//metod som öppnar AddworkoutWindow
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow();
            addWorkoutWindow.Show();
            CloseCurrentWindow();
        }

        private void RemoveWorkout()//ta bort tränings pass i listan
        {
            if (SelectedWorkout == null) 
            { 
                MessageBox.Show("Markera ett träningspass först."); 
                return; 
            }
            Workouts.Remove(SelectedWorkout);
        }

        private void ViewDetails()//kolla information om träningspasset
        {
            if (SelectedWorkout == null) 
            { 
                MessageBox.Show("Markera ett träningspass först."); 
                return; 
            }
            WorkoutDetailWindow workoutDetailWindow = new WorkoutDetailWindow(SelectedWorkout); 
            workoutDetailWindow.Show();
            CloseCurrentWindow();
        }
        private bool CanExecuteWorkoutCommand()
        {
            return SelectedWorkouts != null;
        }

        private void ShowInfo()//metod med lite info
        {
            MessageBox.Show("Här kan du lägga till och ta bort träningspass. Du kan även ändra i dina inställningar");
        }

        private void OpenUserDetail()//metod för att komma till UserDetail
        {
            var userDetailWindow = new UserDetailWindow();
            userDetailWindow.Show();
            CloseCurrentWindow();
        }

        private void SignOut() //metod för att logga ut
        {
            var mainWindow = new MainWindow(); 
            mainWindow.Show();
            CloseCurrentWindow();
        }

        private void CloseCurrentWindow()//metod för att stänga fönster
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
