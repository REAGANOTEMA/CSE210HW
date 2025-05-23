using Newtonsoft.Json;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        [JsonProperty]
        private bool completed;

        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            completed = false;
        }

        public override int RecordEvent()
        {
            if (!completed)
            {
                completed = true;
                return points;
            }
            return 0;
        }

        public override bool IsComplete() => completed;

        public override string DisplayStatus() => completed ? "[X]" : "[ ]";
    }
}
