using System;

class Program
{
    static void Main(string[] args)
    {
        RunningActivity running = new("12 Jun 2026", 35, 5.2);
        CyclingActivity cycling = new("13 Jun 2026", 50, 18.5);
        SwimmingActivity swimming = new("15 Jun 2026", 25, 20);

        List<Activity> activities = [running, cycling, swimming];

        foreach(Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}