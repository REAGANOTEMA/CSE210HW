public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent(Player player)
    {
        player.AddPoints(Points);
        Console.WriteLine($"Eternal Goal '{Name}' recorded! +{Points} points.");
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => "[∞]";

    public override string Serialize()
        => $"EternalGoal|{Name}|{Description}|{Points}";
}
