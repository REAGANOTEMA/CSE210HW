using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class ListingActivity : Activity
    {
        private readonly List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        public override void Run()
        {
            Start();

            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine($"\n{prompt}");
            Console.WriteLine("You may begin listing items. Press Enter after each item.");

            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            List<string> responses = new List<string>();

            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    string item = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        responses.Add(item.Trim());
                    }
                }
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nYou listed {responses.Count} items!");
            End();
        }
    }
}
