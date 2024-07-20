public abstract class Activity
{
    private string date;
    private int length;

    public Activity(string date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public string Date => date;
    public int Length => length;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date} {GetType().Name} ({Length} min): Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
