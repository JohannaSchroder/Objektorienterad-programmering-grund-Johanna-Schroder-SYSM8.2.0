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

        public WorkoutService _workoutService;//hämtar WorkoutService

        public Workout NewWorkout { get; set; }//egenskap för att det nya träningspasset som ska läggas till


        public ICommand SaveCommand { get; set; }//kommando för att spara det nya träningspasset
        public AddWorkoutViewModel()
        {
            _workoutService = WorkoutService.Instance;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()//en metod för att spara träningspass
        {

        }

    }
}
