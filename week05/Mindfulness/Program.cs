// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static ActivityLogger logger = new ActivityLogger();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Journaling");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "5") break;

            MindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => new GratitudeActivity(),
                _ => null
            };

            if (activity != null)
            {
                activity.Run();
                logger.Log(activity.GetType().Name, activity.Duration);
            }
        }

        logger.SaveLog();
    }
}

/*
Extra Credit:
- Added Gratitude Journaling as a fourth activity.
- Added ActivityLogger to track completed activities and save them to a file.
- Ensured no duplicate prompts/questions in a session for Reflection and Listing activities.
- Created advanced breathing animation in BreathingActivity.
- Student: Reagan Otema
*/