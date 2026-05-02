using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What score did you get on the test?: ");
        int score = int.Parse(Console.ReadLine());

        string letter = "";

        if (score >= 90) 
        {
            letter = "A";
        }
        else if (score >= 80) 
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }

        int remainder = score % 10;
        if (score >= 60 && score < 97)
        {
            if (remainder < 3)
            {
                letter = letter + "-";
            }
            else if (remainder >= 7)
            {
                letter = letter + "+";
            }
        }

        Console.WriteLine($"Your grade is {letter}");
        if (score >= 70)
        {
            Console.WriteLine("Congratulations! You pass!");
        }
        else
        {
            Console.WriteLine("We're sorry, you didn't pass. Keep trying!");
        }
    }
}