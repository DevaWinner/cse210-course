public abstract class Goal
{
    public string ShortName { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    protected Goal(string name, string description, int points)
    {
        ShortName = name;
        Description = description;
        Points = points;
    }

    protected Goal() { }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
