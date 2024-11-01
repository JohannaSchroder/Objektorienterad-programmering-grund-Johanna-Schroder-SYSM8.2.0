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

        private readonly WorkoutService _workoutService;
        private readonly UserService _userService;

        private string _selectedWorkout;
        public string SelectedWorkouts
        {
            get { return _selectedWorkout; }
            set { _selectedWorkout = value; OnPropertyChanged(nameof(SelectedWorkouts)); }
        }

        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(nameof(UserName));}
        }


        public ICommand AddWorkoutCommand { get; set; }
        public ICommand RemoveWorkoutCommand { get; set; }
        public ICommand SignOutCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand ShowUserCommand { get; }
        public ICommand ShowInfoCommand { get; }

        public WorkoutsViewModel()
        {
            _workoutService= new WorkoutService();
            _userService = UserService.Instance;
            AddWorkoutCommand = new RelayCommand(AddWorkout);
            RemoveWorkoutCommand = new RelayCommand(RemoveWorkout, CanExecuteWorkoutCommand);
            ViewDetailsCommand = new RelayCommand(ViewDetails, CanExecuteWorkoutCommand);
            SignOutCommand = new RelayCommand(SignOut);
            ShowUserCommand = new RelayCommand(ShowUser);
            ShowInfoCommand = new RelayCommand(ShowInfo);
            
        }
        public ObservableCollection<string> Workouts { get; set; } = new ObservableCollection<string> { "Cardio Workout","Strength Workout"};

        public string UserName => _userService.CurrentUser.UserName;

        public void ShowUser()//här försöker jag skriva ut användarens namn uppe i vänstra hörnet
        {
           User = _userService.CurrentUser.UserName;
        }
        private void AddWorkout()
        {
            Workouts.Add(SelectedWorkouts);           
        }

        private void RemoveWorkout()
        {
            if (SelectedWorkouts == null) 
            { 
                MessageBox.Show("Markera ett träningspass först."); 
                return; 
            }
            Workouts.Remove(SelectedWorkouts);
        }

        private void ViewDetails()
        {
            if (SelectedWorkouts == null) 
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

        private void ShowInfo()
        {
            MessageBox.Show("Här kan du lägga till och ta bort träningspass. Du kan även ändra i dina inställningar");
        }

        private void SignOut() 
        {
            MainWindow mainWindow = new MainWindow(); 
            mainWindow.Show();
        }
    }
}
