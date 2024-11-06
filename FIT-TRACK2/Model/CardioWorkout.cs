using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_TRACK2.Klasser
{
    class CardioWorkout : Workout //ärver från Workout
    {
        //egenskaper
        public int Distance { get; set; }

        //konstruktor
        public CardioWorkout(DateTime Date, string Type, TimeSpan Duration, int CaloriesBurned, string Notes, int Distance)
        : base(Date, Type, Duration, CaloriesBurned, Notes)
        {
            this.Distance = Distance;
        }
        //metoder
        public override int CalculateCaloriesBurned()//räkna ut kalorier
        {
            CaloriesBurned = 8; 
            int distance = Distance; 
            return CaloriesBurned * distance;
        }
    }
}
