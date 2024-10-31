using FIT_TRACK2.Klasser;
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

        public WorkoutService _workoutService;
        public Workout NewWorkout { get; set; }


            public ICommand SaveCommand { get; set; }
        public AddWorkoutViewModel()
        {

        }

        private void Save()
        {

        }

    }
}
