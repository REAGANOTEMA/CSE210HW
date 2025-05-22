using System;
using System.Collections.Generic;

class GratitudeActivity : MindfulnessActivity
{
    protected override string GetDescription()
    {
        return "This activity will help you journal your gratitude to cultivate a positive mindset.";
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Start writing things you're grateful for:");
        List<string> entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < end)
        {
            Console.Write("Grateful for: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                entries.Add(input);
        }

        Console.WriteLine($"\nYou wrote down {entries.Count} gratitude entries.");
    }
}