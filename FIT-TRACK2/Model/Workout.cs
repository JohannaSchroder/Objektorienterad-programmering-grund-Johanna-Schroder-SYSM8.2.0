using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_TRACK2.Klasser
{
    public abstract class Workout//abstrakt basklass
    {
        //egenskaper
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public TimeSpan Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }


        //konstruktor
        public Workout(DateTime Date, string Type, TimeSpan Duration, int CaloriesBurned, string Notes)
        { 
            this.Date = Date;
            this.Type = Type;
            this.Duration = Duration;
            this.CaloriesBurned = CaloriesBurned;
            this.Notes = Notes;
        }


        //abstrakt metod som måste användas i de klasser som ärver här i från.
        public abstract int CalculateCaloriesBurned();
    }
}
