using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
    class WorkoutsViewMode : baseViewModel
    {

        public ObservableCollection<string> Workouts { get; set; }

        public string Username { get; set; }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public ICommand OpenUserDetailsCommand { get; set; }
        public ICommand AddWorkoutCommand { get; set; }
        public ICommand ShowDetailsCommand { get; set; }
        public ICommand RemoveWorkoutCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand ShowInfoCommand { get; set; }

        public WorkoutsViewMode()
        { 
            Workouts = new ObservableCollection<string> {"Cardio", "Strength"};

            OpenUserDetailsCommand = new RelayCommand(OpenUserDetails);
            AddWorkoutCommand = new RelayCommand(AddWorkout);
            ShowDetailsCommand = new RelayCommand(ShowDetails);
            RemoveWorkoutCommand = new RelayCommand(RemoveWorkout);
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

        }

        private void ShowDetails() 
        {
        
        }

        private void RemoveWorkout()
        {

        }

        private void SignOut()
        {

        }
        private void ShowInfo()
        { 
        
        }
    }
}
