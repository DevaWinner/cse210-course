public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public EternalGoal() : base() { }

    public override void RecordEvent()
    {
        // Eternal goals do not get completed, just record the event
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[_] {ShortName}: {Description} - Points: {Points}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName},{Description},{Points}";
    }

    public static EternalGoal FromString(string data)
    {
        var parts = data.Split(',');
        return new EternalGoal
        {
            ShortName = parts[0],
            Description = parts[1],
            Points = int.Parse(parts[2])
        };
    }
}
