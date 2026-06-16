public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, double time, int laps) : base(date, time, "Swimming")
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Time / 60.0);
    }

    public override double GetPace()
    {
        return Time / GetDistance();
    }
}