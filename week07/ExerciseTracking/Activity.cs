using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private string date;
        private int lengthInMinutes;

        public Activity(string date, int lengthInMinutes)
        {
            this.date = date;
            this.lengthInMinutes = lengthInMinutes;
        }

        public string Date => date;
        public int LengthInMinutes => lengthInMinutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{date} {this.GetType().Name} ({lengthInMinutes} min) - " +
                   $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, " +
                   $"Pace: {GetPace():0.0} min per mile";
        }
    }
}
