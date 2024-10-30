using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
    class AddWorkoutViewModel : baseViewModel
    {
        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        private WorkoutService _workoutService;

        private Workout _newWorkout;
            public Workout NewWorkout
            {
                get { return _newWorkout; }
                set { _newWorkout = value; OnPropertyChanged(); }
            }
            public ICommand SaveCommand { get; }
        public AddWorkoutViewModel()
        {
            _workoutService= new WorkoutService();
            NewWorkout = new Workout();
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            _workoutService.AddWorkout(NewWorkout);
            Application.Current.Windows.OfType<AddWorkoutWindow>().FirstOrDefault()?.DialogResult = true;
        }
    }
}
