using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EternalQuest
{
    public class GoalManager
    {
        [JsonProperty]
        private List<Goal> goals = new List<Goal>();

        [JsonProperty]
        private int totalScore = 0;

        public void AddGoal(Goal goal) => goals.Add(goal);

        public void RecordGoalEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            int earnedPoints = goals[goalIndex].RecordEvent();
            if (earnedPoints > 0)
            {
                totalScore += earnedPoints;
                Console.WriteLine($"You earned {earnedPoints} points!");
            }
            else
            {
                Console.WriteLine("Goal already completed or no points earned.");
            }
        }

        public void DisplayGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()} {goals[i].Name} - {goals[i].Description}");
            }
        }

        public int GetScore() => totalScore;

        public void Save(string filename)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(filename, json);
            Console.WriteLine("Progress saved.");
        }

        public static GoalManager Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found. Starting with new progress.");
                return new GoalManager();
            }
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<GoalManager>(json,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
    }
}
