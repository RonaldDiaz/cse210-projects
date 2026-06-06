using System.IO.Compression;

public class Activity
{
    private string _name;
    private string _description;
    private int _activityDuration;

    // Using a Property instead of a getter:
    protected int Duration => _activityDuration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name} activity.\n\n{_description}\n");
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_name} Activity.");
        ShowSpinner(5);
    }

    protected void SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _activityDuration = int.TryParse(Console.ReadLine(), out int result) ? result : 30;
        Console.Clear();
        Console.WriteLine($"Get Ready... ");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected static void ShowSpinner(int seconds)
    {
        char[] chars = ['|', '/', '-', '\\'];
        for (int i = 0; i < seconds * 4; i++)
        {            
            Console.Write(chars[i % chars.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");            
        }
    }

    protected static void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            int digits = (i / 10) + 1;
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write($"{new string('\b', digits)}{new string(' ', digits)}{new string('\b', digits)}");
        }
    }
    
    protected static void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"--- {prompt} ---");
    }
}