public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent(Player player)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            player.AddPoints(Points);
            Console.WriteLine($"Goal '{Name}' completed! +{Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed.");
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() => _isComplete ? "[X]" : "[ ]";

    public override string Serialize()
        => $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
}
