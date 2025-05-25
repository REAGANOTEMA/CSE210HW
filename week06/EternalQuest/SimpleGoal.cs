namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool isComplete;

        public SimpleGoal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            isComplete = false;
        }

        public override void RecordEvent(ref int score)
        {
            if (!isComplete)
            {
                isComplete = true;
                score += Points;
                Console.WriteLine($"Goal completed! You earned {Points} points.");
            }
            else
            {
                Console.WriteLine("This goal has already been completed.");
            }
        }

        public override string GetStatus()
        {
            return $"[{(isComplete ? "X" : " ")}] {Name} ({Description})";
        }

        public override string SaveString()
        {
            return $"SimpleGoal|{Name}|{Description}|{Points}|{isComplete}";
        }
    }
}
