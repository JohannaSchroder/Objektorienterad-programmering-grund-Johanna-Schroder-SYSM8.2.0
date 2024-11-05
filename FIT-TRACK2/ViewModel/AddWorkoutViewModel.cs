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

        private readonly WorkoutService _workoutService;//hämtar WorkoutService
        private Workout NewWorkout;//lagrar träningspass
        private bool _editworkout;//kollar ifall användaren är i redigeringsläge, en loop


        public ICommand SaveCommand { get; set; }//kommandon
        public ICommand GoBackCommand { get; set; }
        public ICommand EditCommand { get; set; }
        
        //konstruktor
        public AddWorkoutViewModel()
        {
            _workoutService = WorkoutService.Instance;
            SaveCommand = new RelayCommand(Save);
            GoBackCommand = new RelayCommand(GoBack);
            EditCommand = new RelayCommand(Edit);
        }

        private void Save()//en metod för att spara träningspass
        {

        }

        private void GoBack()//metod för att gå tillbaka till WorkoutWindow
        { 
            WorkoutsWindow workoutsWindow = new WorkoutsWindow();
            workoutsWindow.Show();
        }

        private void Edit()//en metod för att ändra
        {

        }

    }
}
