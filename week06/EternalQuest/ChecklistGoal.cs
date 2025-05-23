using Newtonsoft.Json;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        [JsonProperty]
        private int timesCompleted;

        [JsonProperty]
        private int requiredCompletions;

        [JsonProperty]
        private int bonusPoints;

        public ChecklistGoal(string name, string description, int pointsPerCompletion, int requiredCompletions, int bonusPoints)
            : base(name, description, pointsPerCompletion)
        {
            timesCompleted = 0;
            this.requiredCompletions = requiredCompletions;
            this.bonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (timesCompleted < requiredCompletions)
            {
                timesCompleted++;
                if (timesCompleted == requiredCompletions)
                {
                    return points + bonusPoints;
                }
                else
                {
                    return points;
                }
            }
            return 0;
        }

        public override bool IsComplete() => timesCompleted >= requiredCompletions;

        public override string DisplayStatus()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} Completed {timesCompleted}/{requiredCompletions} times";
        }
    }
}
