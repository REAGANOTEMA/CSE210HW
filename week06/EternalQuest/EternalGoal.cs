using Newtonsoft.Json;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points) { }

        public override int RecordEvent() => points;

        public override bool IsComplete() => false;

        public override string DisplayStatus() => "[∞]";
    }
}
