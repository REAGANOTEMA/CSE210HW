using Newtonsoft.Json;

namespace EternalQuest
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Goal
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        protected int points;

        protected Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            this.points = points;
        }

        public abstract int RecordEvent();

        public abstract bool IsComplete();

        public abstract string DisplayStatus();
    }
}
