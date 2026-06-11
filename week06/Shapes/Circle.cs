public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color, "circle")
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return 2 * Math.PI * _radius * _radius;
    }
}