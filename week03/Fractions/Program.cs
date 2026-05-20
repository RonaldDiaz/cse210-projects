using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);
        Fraction f4 = new Fraction();
        f4.setTop(4);
        f4.setBottom(5);
        Console.WriteLine($"Fraction 1: {f1.GetFractionString()}");
        Console.WriteLine($"Fraction 1 Decimal: {f1.GetDecimalValue()}");
        Console.WriteLine($"Fraction 2: {f2.GetFractionString()}");
        Console.WriteLine($"Fraction 2 Decimal: {f2.GetDecimalValue()}");
        Console.WriteLine($"Fraction 3: {f3.GetFractionString()}");
        Console.WriteLine($"Fraction 3 Decimal: {f3.GetDecimalValue()}");
        Console.WriteLine($"Fraction 4: {f4.getTop()}/{f4.getBottom()}");
        Console.WriteLine($"Fraction 4 Decimal: {f4.GetDecimalValue():F2}");
        
        
             
    }
}