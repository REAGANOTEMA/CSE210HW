using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> goals = new List<Goal>();
        private int score = 0;

        public void CreateGoal()
        {
            Console.WriteLine("What type of goal? (1=Simple, 2=Eternal, 3=Checklist)");
            string choice = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, desc, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, desc, points));
                    break;
                case "3":
                    Console.Write("Target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        public void ListGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
            }
        }

        public void RecordEvent()
        {
            ListGoals();
            Console.Write("Which goal did you accomplish? (enter number) ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < goals.Count)
            {
                goals[index].RecordEvent(ref score);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public void ShowScore()
        {
            Console.WriteLine($"Current score: {score}");
        }

        public void SaveGoals()
        {
            using (StreamWriter sw = new StreamWriter("goals.txt"))
            {
                sw.WriteLine(score);
                foreach (Goal g in goals)
                {
                    sw.WriteLine(g.SaveString());
                }
            }
            Console.WriteLine("Goals saved!");
        }

        public void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                string[] lines = File.ReadAllLines("goals.txt");
                score = int.Parse(lines[0]);
                goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    switch (parts[0])
                    {
                        case "SimpleGoal":
                            SimpleGoal sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                            if (bool.Parse(parts[4])) sg.RecordEvent(ref score);
                            goals.Add(sg);
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "ChecklistGoal":
                            ChecklistGoal cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                int.Parse(parts[4]), int.Parse(parts[5]));
                            typeof(ChecklistGoal).GetField("currentCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .SetValue(cg, int.Parse(parts[6]));
                            goals.Add(cg);
                            break;
                    }
                }

                Console.WriteLine("Goals loaded!");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
    }
}
