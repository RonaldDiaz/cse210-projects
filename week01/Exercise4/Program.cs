using System;

class Program
{
    static void Main(string[] args)
    {
        int number = -1;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers. Type 0 when finished.");
        
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);                
            }
        }
        Console.WriteLine($"The sum is: {numbers.Sum()}");        
        Console.WriteLine($"The average is: {numbers.Average()}");
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");
        int positive_min = max;
        foreach (int numero in numbers)
        {
            if (numero > 0 && numero < positive_min)
            {
                positive_min = numero;
            }
        }
        Console.WriteLine($"The smallest positive number is: {positive_min}");
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach(int numero in numbers)
        {
            Console.WriteLine(numero);            
        }
        
    }
}