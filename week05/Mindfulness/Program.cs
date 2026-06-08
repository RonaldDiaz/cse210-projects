// Enhancements: Added a Menu class. Added a way to avoid getting the same prompt.
// In the breathing activity, I commented out the contdown (original requirement), and changed it for a breathing animation.
using System;

class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        while (run)
        {
            Menu.Show();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    BreathingActivity breathingActivity = new();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new();
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new();
                    listingActivity.Run();
                    break;
                case "4":
                run = false;
                break;
                default:
                    Console.WriteLine("Not valid option. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
}