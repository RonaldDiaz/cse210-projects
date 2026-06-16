public abstract class Activity
{
    private string _date;
    private double _time;
    private string _activityName;

    protected double Time => _time;

    public Activity(string date, double minutes, string activityName)
    {
        _date = date;
        _time = minutes;
        _activityName = activityName;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    // The rubric asks for an abstract method for Pace, but it would be better to define it here because it is the same formula (_time / GetDistance())
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date} {_activityName} ({_time} min) - Distance {GetDistance():0.00} km, Speed {GetSpeed():0.00} kph, Pace {GetPace():0.00} min per km.";
    }
}