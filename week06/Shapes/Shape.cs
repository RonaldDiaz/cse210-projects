public abstract class Shape
{
    private string _color;
    private string _shapeName;

    public Shape(string color, string shapeName)
    {
        _color = color;
        _shapeName = shapeName;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public string GetName()
    {
        return _shapeName;
    }

    public abstract double GetArea();
}