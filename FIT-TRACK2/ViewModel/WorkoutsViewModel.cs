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
            set { _username = value; OnPropertyChanged(nameof(UserName));}
        }

        //Kommandon
        public ICommand AddWorkoutCommand { get; }
        public ICommand RemoveWorkoutCommand { get; set; }
        public ICommand SignOutCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand ShowUserCommand { get; }
        public ICommand ShowInfoCommand { get; }
        public ICommand OpenUserDetailWindow { get; }

        //konstruktor
        public WorkoutsViewModel()
        {
            _workoutService= WorkoutService.Instance; //hämta instansen av WorkoutService och UserService
            _userService = UserService.Instance;
            UserName = _userService.CurrentUser.UserName;// hämtar användarnamnet för den inloggade användaren
            AddWorkoutCommand = new RelayCommand(AddWorkout);//bindning till metoder
            RemoveWorkoutCommand = new RelayCommand(RemoveWorkout, CanExecuteWorkoutCommand);
            ShowDetailsCommand = new RelayCommand(ViewDetails, CanExecuteWorkoutCommand);
            SignOutCommand = new RelayCommand(SignOut);
            ShowInfoCommand = new RelayCommand(ShowInfo);
            OpenUserDetailWindow = new RelayCommand(OpenUserDetail);
            Workouts = new ObservableCollection<Workout>//lista med workouts
            {
                cardio, strength                
            };
            SelectedWorkouts = new ObservableCollection<Workout>();
        }
        CardioWorkout cardio = new CardioWorkout(DateTime.Today, "Cardio", TimeSpan.Zero, 200, "Cardio träning", 5);
        StrengthWorkout strength = new StrengthWorkout(DateTime.Today, "Strength", TimeSpan.Zero, 200, "Strength träning", 1000);
        
        public ObservableCollection<Workout> Workouts { get; set; }//listor
        public ObservableCollection<Workout> SelectedWorkouts { get; set; }

        private void AddWorkout()//metod för att lägga till träningspass i listan
        {
            if (SelectedWorkout != null && !SelectedWorkouts.Contains(SelectedWorkout)) 
            { SelectedWorkouts.Add(SelectedWorkout); }
        }

        private void RemoveWorkout()//ta bort tränings pass i listan
        {
            if (SelectedWorkout == null) 
            { 
                MessageBox.Show("Markera ett träningspass först."); 
                return; 
            }
            SelectedWorkouts.Remove(SelectedWorkout);
        }

        private void ViewDetails()//kolla information om träningspasset
        {
            if (SelectedWorkout == null) 
            { 
                MessageBox.Show("Markera ett träningspass först."); 
                return; 
            }
            WorkoutDetailWindow workoutDetailWindow = new WorkoutDetailWindow(); 
            workoutDetailWindow.Show();
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
            UserDetailWindow userDetailWindow = new UserDetailWindow();
            userDetailWindow.Show();
        }

        private void SignOut() //metod för att logga ut
        {
            MainWindow mainWindow = new MainWindow(); 
            mainWindow.Show();
        }
    }
}
