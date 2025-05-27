public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent(Player player)
    {
        _currentCount++;
        player.AddPoints(Points);
        Console.WriteLine($"Checklist Goal '{Name}': Progress {_currentCount}/{_targetCount} (+{Points} points).");
        if (_currentCount == _targetCount)
        {
            player.AddPoints(_bonusPoints);
            Console.WriteLine($"Bonus! Checklist Goal '{Name}' completed! +{_bonusPoints} bonus points.");
        }
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() => $"[{_currentCount}/{_targetCount}]";

    public override string Serialize()
        => $"ChecklistGoal|{Name}|{Description}|{Points}|{_currentCount}|{_targetCount}|{_bonusPoints}";
}
