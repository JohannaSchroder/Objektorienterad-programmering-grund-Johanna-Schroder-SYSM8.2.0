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
        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        private WorkoutService _workoutService;
        private UserService _userService;
        public ObservableCollection<Workout> Workouts { get;set; } = new ObservableCollection<Workout>();

        private Workout _selectedWorkout;
        public Workout SelectedWorkout
        {
            get { return _selectedWorkout; }
            set { _selectedWorkout = value; OnPropertyChanged(); }
        }

        public ICommand AddWorkoutCommand { get; set; }
        public ICommand RemoveWorkoutCommand { get;set; }

        public WorkoutsViewModel(WorkoutService workoutService, UserService userService)
        {
            _workoutService= workoutService;
            _userService = new UserService();
            LoadWorkouts();
            AddWorkoutCommand = new RelayCommand(AddWorkout);
            RemoveWorkoutCommand = new RelayCommand(RemoveWorkout);
        }

        private void LoadWorkouts()
        {
            var workouts = _workoutService.GetWorkouts();
            Workouts.Clear();
            foreach (var workout in workouts)
            {
                Workouts.Add(workout);
            }
        }
        private void AddWorkout()
        {
        }

        private void RemoveWorkout()
        {
            if (SelectedWorkout != null)
            {
                _workoutService.RemoveWorkout(SelectedWorkout);
                Workouts.Remove(SelectedWorkout);
            }
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
