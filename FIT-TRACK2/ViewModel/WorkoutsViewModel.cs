﻿using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private User _currentUser; 
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value; 
                OnPropertyChanged(nameof(CurrentUser)); 
                OnPropertyChanged(nameof(Username)); //Username uppdateras
            } 
        }

        //Kommandon
        public ICommand RemoveWorkoutCommand { get; set; }
        public ICommand SignOutCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand ShowUserCommand { get; } 
        public ICommand ShowInfoCommand { get; }
        public ICommand OpenUserDetailWindow { get; }
        public ICommand OpenAddWorkoutCommand { get; }

        public bool IsAdmin => _userService.CurrentUser?.IsAdmin ?? false;
        public string Username => _userService.CurrentUser.UserName;//sätter användarnamn uppe i vänstra hörnet
        //konstruktor
        public WorkoutsViewModel()
        {
            _workoutService = WorkoutService.Instance; //hämta instansen av WorkoutService och UserService
            _userService = UserService.Instance;
            CurrentUser = _userService.CurrentUser;
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
        }

        public ObservableCollection<Workout> Workouts { get; set; }//listor
        public ObservableCollection<Workout> SelectedWorkouts { get; set; }//listor


        private void ShowWorkoutsAdmin()//visar alla träningspass i listan som användare lagt till
        {
            if (IsAdmin)
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
            _userService.CurrentUser = null;
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
