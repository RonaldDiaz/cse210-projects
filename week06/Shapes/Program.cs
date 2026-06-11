using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new("blue", 2.0);
        Rectangle rectangle = new("red", 3.0, 6.0);
        Circle circle = new("yellow", 5.0);
        Console.WriteLine($"The color of the square is {square.GetColor()} and its area is {square.GetArea()}");
        Console.WriteLine($"The color of the rectangle is {rectangle.GetColor()} and its area is {rectangle.GetArea()}");
        Console.WriteLine($"The color of the circle is {circle.GetColor()} and its area is {circle.GetArea()}");
        List<Shape> shapes = [square, rectangle, circle];
        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"The color of the {shape.GetName()} is {shape.GetColor()} and its area is {shape.GetArea()}");        
        }
    }
}