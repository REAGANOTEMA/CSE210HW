namespace ExerciseTracking
{
    public class SwimmingActivity : Activity
    {
        private int numberOfLaps;

        public SwimmingActivity(string date, int lengthInMinutes, int numberOfLaps)
            : base(date, lengthInMinutes)
        {
            this.numberOfLaps = numberOfLaps;
        }

        public override double GetDistance()
        {
            double distanceKm = (numberOfLaps * 50) / 1000.0;
            double distanceMiles = distanceKm * 0.62;
            return distanceMiles;
        }

        public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;

        public override double GetPace() => LengthInMinutes / GetDistance();
    }
}
