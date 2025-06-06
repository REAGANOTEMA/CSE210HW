namespace ExerciseTracking
{
    public class RunningActivity : Activity
    {
        private double distance;

        public RunningActivity(string date, int lengthInMinutes, double distance)
            : base(date, lengthInMinutes)
        {
            this.distance = distance;
        }

        public override double GetDistance() => distance;

        public override double GetSpeed() => (distance / LengthInMinutes) * 60;

        public override double GetPace() => LengthInMinutes / distance;
    }
}
