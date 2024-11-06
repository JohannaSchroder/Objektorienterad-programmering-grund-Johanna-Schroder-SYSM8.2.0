using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
    
    class AddWorkoutViewModel : baseViewModel
    {

        private readonly WorkoutService _workoutService;//hämtar WorkoutService

        //egenskaper
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        private string _workoutType;
        public string WorkoutType
        {
            get { return _workoutType; }
            set { _workoutType = value; OnPropertyChanged(); }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged(); }
        }

        private int _calorier;
        public int Calorier
        {
            get { return _calorier; }
            set { _calorier = value; OnPropertyChanged(); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged(); }
        }


        public ICommand SaveCommand { get; set; }//kommandon
        public ICommand GoBackCommand { get; set; }
        
        //konstruktor
        public AddWorkoutViewModel()//konstruktor
        {
            _workoutService = WorkoutService.Instance;
            SaveCommand = new RelayCommand(Save);
            GoBackCommand = new RelayCommand(GoBack);
        }

        private void Save()//en metod för att spara träningspass
        {
            Workout nyWorkout;
            if (Date == default || //man behöver fylla i alla rutor
                string.IsNullOrWhiteSpace(WorkoutType) ||
               Duration == default || 
               Calorier <= 0 || 
               string.IsNullOrWhiteSpace(Notes))
            {
                MessageBox.Show("Du måste fylla i alla rutor!");
            }
            if (WorkoutType == WorkoutType)//kollar vad som srivs i rutan
            {
                nyWorkout = new StrengthWorkout(DateTime.Today, "Strength", TimeSpan.Zero, 0, "Styrka", 10)
                {//lägger in de nya värderna
                    Date = Date,
                    Type = WorkoutType,
                    Duration = Duration,
                    CaloriesBurned = Calorier,
                    Notes = Notes,
                };
            }
            else
            {
                MessageBox.Show("Något gick fel!");
                return;
            }
            // sparar träningspasset i listan
            WorkoutService.Instance.AddWorkout(nyWorkout);
            MessageBox.Show("Träningspasset är sparat och du återgår nu till träningssidan!");
            WorkoutsWindow workoutsWindow = new WorkoutsWindow();
            workoutsWindow.Show();
        }
        private void GoBack()//metod för att gå tillbaka till WorkoutWindow
        { 
            WorkoutsWindow workoutsWindow = new WorkoutsWindow();
            workoutsWindow.Show();
        }


    }
}
