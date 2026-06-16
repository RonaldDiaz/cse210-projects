public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(string date, double time, double distance) : base(date, time, "Running")
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / (Time / 60.0);
    }

    public override double GetPace()
    {
        return Time / GetDistance();
    }
}