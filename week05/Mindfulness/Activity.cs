using System;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class Activity
    {
        private int duration;
        private readonly string name;
        private readonly string description;

        public Activity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        protected int Duration
        {
            get => duration;
            set
            {
                if (value > 0) duration = value;
                else duration = 10;
            }
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("Mindfulness Program by Reagan Otema");
            Console.WriteLine("==================================");
            Console.WriteLine($"\nStarting {name} Activity");
            Console.WriteLine(description);
            Console.Write("\nEnter duration in seconds: ");

            while (!int.TryParse(Console.ReadLine(), out int input) || input <= 0)
            {
                Console.Write("Invalid input. Please enter a positive number for seconds: ");
            }

            Duration = input;

            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {name} activity for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "/", "-", "\\", "|" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[i++ % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}
