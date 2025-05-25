using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Author: Reagan Otema
            // Eternal Quest Program (Week 06 Project)
            // Creativity: Bonus awards, leveling system, modular design

            GoalManager manager = new GoalManager();
            manager.LoadGoals();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEternal Quest Menu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.CreateGoal();
                        break;
                    case "2":
                        manager.ListGoals();
                        break;
                    case "3":
                        manager.RecordEvent();
                        break;
                    case "4":
                        manager.ShowScore();
                        break;
                    case "5":
                        manager.SaveGoals();
                        break;
                    case "6":
                        manager.LoadGoals();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }
            }

            Console.WriteLine("Thanks for playing Eternal Quest!");
        }
    }
}
