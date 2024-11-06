using FIT_TRACK2.Klasser;
using FIT_TRACK2.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FIT_TRACK2.Windows
{
    /// <summary>
    /// Interaction logic for WorkoutDetailWindow.xaml
    /// </summary>
    public partial class WorkoutDetailWindow : Window, INotifyPropertyChanged
    {
        public WorkoutDetailWindow(Workout selectedWorkout)
        {
            InitializeComponent();
            this.DataContext = new WorkoutDetailsViewModel(selectedWorkout);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
