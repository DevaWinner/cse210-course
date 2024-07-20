public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public NegativeGoal() : base() { }

    public override void RecordEvent()
    {
        // Negative goals do not get completed, just to record the event
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
        return $"NegativeGoal:{ShortName},{Description},{Points}";
    }

    public static NegativeGoal FromString(string data)
    {
        var parts = data.Split(',');
        return new NegativeGoal
        {
            ShortName = parts[0],
            Description = parts[1],
            Points = int.Parse(parts[2])
        };
    }
}
