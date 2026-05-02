using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Guess My Number Game!");
        string play;        
        do
        {
            Random random = new();
            int secret = random.Next(1,101);
            int guesses = 0;      
            int guess = 0;      
            while (guess != secret)
            {
                guesses += 1;
                Console.Write("What is your guess?: ");
                guess = int.Parse(Console.ReadLine());

                if (guess > secret)
                {
                    Console.WriteLine("Lower.");
                }
                else if (guess < secret)
                {
                    Console.WriteLine("Higher");
                }
            }
            Console.WriteLine("Congratulations! You guessed the number!");
            Console.WriteLine($"It took you {guesses} guesses.");
            Console.Write("Would you like to play again? ");
            play = Console.ReadLine();            
        }
        while (play == "yes");
        Console.WriteLine("Thank you for playing. Goodbye!");      
    }
}