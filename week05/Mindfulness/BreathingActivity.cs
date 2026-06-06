public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();
        SetDuration();
        DateTime currentTime = DateTime.Now;
        DateTime finishTime = currentTime.AddSeconds(Duration);
        while (currentTime < finishTime)
        {
            // Original code with countdown (As in original requirements)
            // Console.Write("Breathe in... ");
            // ShowCountDown(5);
            // Console.WriteLine();
            // Console.Write("Now breathe out... ");
            // ShowCountDown(5);
            ShowBreathingAnimation("Breathe in...  ", 5, expanding: true);
            ShowBreathingAnimation("Breathe out... ", 5, expanding: false);
            Console.WriteLine();
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
        DisplayEndingMessage();
    }
    
    private void ShowBreathingAnimation(string message, int seconds, bool expanding)
    {
        Console.Write(message);
        int totalSteps = seconds * 2;

        if (expanding)
        {
            for (int i = 1; i <= totalSteps; i++)
            {
                Console.Write("█");
                Thread.Sleep(500);
            }
        }
        else
        {
            Console.Write(new string('█', totalSteps - 1));
            Thread.Sleep(500);
            for (int i = totalSteps; i > 0; i--)
            {
                Console.Write("\b \b");
                Thread.Sleep(500);
            }
        }
        Console.WriteLine();
    }
}