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
        private WorkoutService _workoutService;
        public ObservableCollection<Workout> Workouts { get;set; } = new ObservableCollection<Workout>();

        public ICommand AddWorkoutCommand { get; set; }
        public ICommand RemoveWorkoutCommand { get;set; }

        public WorkoutsViewModel(WorkoutService workoutService)
        {
            _workoutService= workoutService;
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
            var addWorkoutWindow = new AddWorkoutWindow();
            if (addWorkoutWindow.ShowDialog() == true)
            {
                var workout = addWorkoutWindow.NeWWorkout;
                _workoutService.AddWorkout(workout);
                Workouts.Add(workout);
            }
        }

        private void RemoveWorkout()
        {
            
        }
    }

    public class WorkoutService
    {
        private List<Workout> _workout = new List<Workout>();

        public IEnumerable<Workout> GetWorkouts() => _workout;

        public void AddWorkout(Workout workout)
        {
            _workout.Add(workout);
        }

        public void RemoveWorkout(Workout workout)
        {
            _workout.Remove(workout);
        }
    }
}
