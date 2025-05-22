using System;
using System.Collections.Generic;

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        var usedQuestions = new HashSet<int>();

        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            int index;
            do { index = rand.Next(questions.Count); } while (usedQuestions.Contains(index));
            usedQuestions.Add(index);

            Console.WriteLine(questions[index]);
            ShowSpinner(5);
            elapsed += 5;

            if (usedQuestions.Count == questions.Count)
                usedQuestions.Clear();
        }
    }
}