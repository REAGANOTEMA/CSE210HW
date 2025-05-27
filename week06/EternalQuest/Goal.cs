public abstract class Goal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract void RecordEvent(Player player);
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string Serialize();
}
