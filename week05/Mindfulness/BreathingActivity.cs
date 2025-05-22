using System;

class BreathingActivity : MindfulnessActivity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("\nBreathe in: ");
            BreathingVisual(4);
            Console.Write("\nBreathe out: ");
            BreathingVisual(4);
            elapsed += 8;
        }
    }

    private void BreathingVisual(int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Console.Write("*".PadLeft(i));
            Thread.Sleep(1000);
            Console.Write("\r".PadLeft(20));
        }
        Console.WriteLine();
    }
}