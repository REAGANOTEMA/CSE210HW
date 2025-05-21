using System;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override void Run()
        {
            Start();

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.WriteLine("\nBreathe in...");
                Countdown(4);

                Console.WriteLine("Breathe out...");
                Countdown(6);
            }

            End();
        }
    }
}
