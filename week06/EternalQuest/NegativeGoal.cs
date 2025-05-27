public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent(Player player)
    {
        player.AddPoints(-Points);
        Console.WriteLine($"Negative Goal '{Name}' recorded. -{Points} points.");
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => "[-]";

    public override string Serialize()
        => $"NegativeGoal|{Name}|{Description}|{Points}";
}
