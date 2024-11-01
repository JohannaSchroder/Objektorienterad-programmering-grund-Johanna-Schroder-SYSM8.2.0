using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FIT_TRACK2.ViewModel
{
    class WorkoutDetailsViewModel : baseViewModel    
    {
        //egenskaper
        public DateTime Date
        {
            get => _workout.Date; 
            set
            {
                _workout.Date = value;
                OnPropertyChanged();
            }
        }
        public string WorkoutType
        {
            get => _workout.Type;
            set
            {
                _workout.Type = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan Duration
        {
            get => _workout.Duration;
            set
            {
                _workout.Duration = value;
                OnPropertyChanged();
            }
        }
        public string CaloriesBurned
        {
            get => _workout.CaloriesBurned.ToString();
            set
            {
                if (int.TryParse(value, out var calories))
                {
                    _workout.CaloriesBurned = calories;
                    OnPropertyChanged();
                }
            }
        }
        public string Notes
        {
            get => _workout.Notes;
            set
            {
                _workout.Notes = value;
                OnPropertyChanged();
            }
        }

        private Workout _workout;
        public WorkoutDetailsViewModel(Workout workout)
        {
            _workout = workout;
        }

        private WorkoutService _workoutService;//hämtar WorkoutService

        //konstruktor
        public WorkoutDetailsViewModel()
        {

        }
    }
}
