using System;
using System.Collections.Generic;

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        HashSet<int> usedPrompts = new();
        int promptIndex;
        do { promptIndex = rand.Next(prompts.Count); } while (usedPrompts.Contains(promptIndex));
        usedPrompts.Add(promptIndex);

        Console.WriteLine(prompts[promptIndex]);
        ShowSpinner(3);

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}