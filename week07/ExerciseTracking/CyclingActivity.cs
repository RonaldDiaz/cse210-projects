public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, double time, double speed) : base(date, time, "Cycling")
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return Time / 60.0 * _speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return Time / GetDistance();
    }
}