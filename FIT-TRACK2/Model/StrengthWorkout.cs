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
            this.Distance = Distance;
        }
        //metoder
        public override int CalculateCaloriesBurned()//metod för att räkna ut kalorier
        {
            CaloriesBurned = 6;
            int distance = Distance;
            return CaloriesBurned * distance;
        }
    }
}
