namespace EternalQuest
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
        }

        public override void RecordEvent(ref int score)
        {
            score += Points;
            Console.WriteLine($"Eternal goal recorded! You earned {Points} points.");
        }

        public override string GetStatus()
        {
            return $"[∞] {Name} ({Description})";
        }

        public override string SaveString()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }
    }
}
