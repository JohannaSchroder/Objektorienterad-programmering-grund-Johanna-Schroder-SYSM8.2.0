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
        public ObservableCollection<string> Workouts { get; set; }//lista för träningspass

        public string UserName { get; set; }

        private string _selectedWorkout;

        public string SelectedWorkout
        {
            get { return _selectedWorkout; }
            set { _selectedWorkout = value; }
        }

        public ICommand OpenUserDetailsCommand { get; set; }
        public ICommand AddWorkoutCommand { get; set; }
        public ICommand ShowDetailsCommand { get; set; }
        public ICommand RemoveWorkoutCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand ShowInfoCommand { get; set; }

        public WorkoutsViewModel()
        { 
            Workouts = new ObservableCollection<string>();

            OpenUserDetailsCommand = new RelayCommand(OpenUserDetails);
            AddWorkoutCommand = new RelayCommand(AddWorkout);
            ShowDetailsCommand = new RelayCommand(ShowDetails, CanShowDetailsOrRemove);
            RemoveWorkoutCommand = new RelayCommand(RemoveWorkout, CanShowDetailsOrRemove);
            SignOutCommand = new RelayCommand(SignOut);
            ShowInfoCommand = new RelayCommand(ShowInfo);
        }

        private void OpenUserDetails()
        { 
            UserDetailWindow UserDetail = new UserDetailWindow();
            UserDetail.Show();
        }

        private void AddWorkout()
        {
            AddWorkoutWindow addWorkout = new AddWorkoutWindow();
            addWorkout.Show();
        }

        private void ShowDetails() 
        {
            if (SelectedWorkout == null)
            {
                MessageBox.Show("Du måste välja ett träningspass");
                return;
            }
            WorkoutDetailWindow WorkoutDetail = new WorkoutDetailWindow();
            WorkoutDetail.Show();
        }

        private void RemoveWorkout()
        {
            if (SelectedWorkout == null)
            {
                MessageBox.Show("Du måste välja ett träningspass");
                return;
            }
            Workouts.Remove(SelectedWorkout);
        }
        private bool CanShowDetailsOrRemove() => SelectedWorkout != null;
        private void SignOut()
        {
            MainWindow LogIn = new MainWindow();
            LogIn.Show();
        }
        private void ShowInfo()
        {
            MessageBox.Show("Här kan du lägga till, ändra och ta bort träningspass. Du kan även ändra dina inställningar.");
        }
    }
}
