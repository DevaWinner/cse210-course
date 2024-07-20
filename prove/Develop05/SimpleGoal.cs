public class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        IsCompleted = false;
    }

    // Parameterless constructor for serialization
    public SimpleGoal() : base() { }

    public override void RecordEvent()
    {
        IsCompleted = true;
    }

    public override bool IsComplete()
    {
        return IsCompleted;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsCompleted ? "X" : " ")}] {ShortName}: {Description} - Points: {Points}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName},{Description},{Points},{IsCompleted}";
    }

    public static SimpleGoal FromString(string data)
    {
        var parts = data.Split(',');
        return new SimpleGoal
        {
            ShortName = parts[0],
            Description = parts[1],
            Points = int.Parse(parts[2]),
            IsCompleted = bool.Parse(parts[3])
        };
    }
}
