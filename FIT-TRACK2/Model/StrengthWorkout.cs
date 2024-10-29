using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_TRACK2.Klasser
{
    class StrengthWorkout : Workout//ärver från Workout
    {
        //egenskaper
        public int Distance { get; set; }
        //konstruktor
        public StrengthWorkout(DateTime Date, string Type, TimeSpan Duration, int CaloriesBurned, string Notes, int Distance) 
            : base(Date, Type, Duration, CaloriesBurned, Notes)
        { 
            this.Duration = Duration;
        }
        //metoder
        public override int CalculateCaloriesBurned()
        {
            throw new NotImplementedException();
        }
    }
}
