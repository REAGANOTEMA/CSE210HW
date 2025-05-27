using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>();
        Player player = new Player();
        string filename = "goals.txt";

        LoadGoals(filename, goals, player);

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Player Status");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(goals); break;
                case "2": RecordEvent(goals, player); break;
                case "3": ShowGoals(goals); break;
                case "4": player.ShowStatus(); break;
                case "5":
                    SaveGoals(filename, goals, player);
                    quit = true;
                    break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist 4) Negative");
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target Count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void RecordEvent(List<Goal> goals, Player player)
    {
        ShowGoals(goals);
        Console.Write("Enter goal number to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent(player);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    static void ShowGoals(List<Goal> goals)
    {
        Console.WriteLine("\n=== Goals ===");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name} ({goals[i].Description})");
        }
    }

    static void SaveGoals(string filename, List<Goal> goals, Player player)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(player.TotalPoints);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    static void LoadGoals(string filename, List<Goal> goals, Player player)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            player.AddPoints(int.Parse(lines[0])); // Load points

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) sg.RecordEvent(player);
                        goals.Add(sg);
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        for (int j = 0; j < int.Parse(parts[4]); j++)
                            cg.RecordEvent(player);
                        goals.Add(cg);
                        break;
                    case "NegativeGoal":
                        goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                }
            }
            Console.WriteLine("Goals loaded.");
        }
    }
}
