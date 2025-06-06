namespace ExerciseTracking
{
    public class CyclingActivity : Activity
    {
        private double speed;

        public CyclingActivity(string date, int lengthInMinutes, double speed)
            : base(date, lengthInMinutes)
        {
            this.speed = speed;
        }

        public override double GetSpeed() => speed;

        public override double GetDistance() => (speed * LengthInMinutes) / 60;

        public override double GetPace() => 60 / speed;
    }
}
