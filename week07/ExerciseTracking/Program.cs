using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            RunningActivity running = new RunningActivity("03 Nov 2022", 30, 3.0);
            CyclingActivity cycling = new CyclingActivity("03 Nov 2022", 45, 15.0);
            SwimmingActivity swimming = new SwimmingActivity("03 Nov 2022", 40, 20);

            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
