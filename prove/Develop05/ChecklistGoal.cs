public class ChecklistGoal : Goal
{
    public int AmountCompleted { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        AmountCompleted = 0;
        Target = target;
        Bonus = bonus;
    }

    public ChecklistGoal() : base() { }

    public override void RecordEvent()
    {
        AmountCompleted++;
    }

    public override bool IsComplete()
    {
        return AmountCompleted >= Target;
    }

    public override string GetDetailsString()
    {
        return $"[{(AmountCompleted >= Target ? "X" : " ")}] {ShortName}: {Description} - Points: {Points}, Target: {Target}, Bonus: {Bonus}, Completed: {AmountCompleted}/{Target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName},{Description},{Points},{Target},{Bonus},{AmountCompleted}";
    }

    public static ChecklistGoal FromString(string data)
    {
        var parts = data.Split(',');
        return new ChecklistGoal
        {
            ShortName = parts[0],
            Description = parts[1],
            Points = int.Parse(parts[2]),
            Target = int.Parse(parts[3]),
            Bonus = int.Parse(parts[4]),
            AmountCompleted = int.Parse(parts[5])
        };
    }
}
