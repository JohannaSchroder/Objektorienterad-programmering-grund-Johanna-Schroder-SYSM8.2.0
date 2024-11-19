using FIT_TRACK2.Klasser;
using FIT_TRACK2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FIT_TRACK2.ViewModel
{
    class WorkoutDetailsViewModel : baseViewModel
    {
        //egenskaper
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _type;
        public string WorkoutType
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private int _caloriesburned;
        public int CaloriesBurned
        {
            get => _caloriesburned;
            set
            {
                _caloriesburned = value;
                OnPropertyChanged();
            }
        }

        private string _notes;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        private Workout _workout;
        public Workout Workout
        {
            get { return _workout; }
            set { _workout = value; OnPropertyChanged(); }
        }

        private bool _isReadOnly = true;
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { _isReadOnly = value; OnPropertyChanged(nameof(IsReadOnly)); }
        }

        public ICommand SaveCommand { get; set; }//kommandon
        public ICommand EditCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public WorkoutDetailsViewModel(Workout workout)//konstruktor
        {
            _workoutService = WorkoutService.Instance;
            Workout = workout;
            Date = workout.Date;
            WorkoutType = workout.Type;
            Duration = workout.Duration;
            CaloriesBurned = workout.CaloriesBurned;
            Notes = workout.Notes;
            SaveCommand = new RelayCommand(Save);
            EditCommand = new RelayCommand(Edit);
            GoBackCommand = new RelayCommand(GoBack);
        }


        private readonly WorkoutService _workoutService;

        private void Save() //metod för att spara
        {
            if (Date == default || //kollar så alla fält är ifyllda
                string.IsNullOrWhiteSpace(WorkoutType) ||
                Duration == default ||
                CaloriesBurned <= 0 ||
                string.IsNullOrWhiteSpace(Notes))
            {
                MessageBox.Show("Du måste fylla i alla fält!");
                return;
            }
               _workout.Date = Date;//lägger in de nya värderna
               _workout.Type = WorkoutType;
               _workout.Duration = Duration;
               _workout.CaloriesBurned = CaloriesBurned;
               _workout.Notes = Notes;
               IsReadOnly = true;
               _workoutService.SaveWorkout(_workout);//uppdaterar träningspasset i WorkoutService
               MessageBox.Show("Ditt träningspass är sparat! Du återgår nu till träningssidan.");
               WorkoutsWindow workoutsWindow = new WorkoutsWindow();
               workoutsWindow.Show();
               CloseCurrentWindow();
        }

        private void Edit()//en metod för att ändra
        {
                IsReadOnly = false;
        }

        private void GoBack()//metod för att gå tillbaka
        {
            WorkoutsWindow workoutsWindow = new WorkoutsWindow(); 
            workoutsWindow.Show();
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
