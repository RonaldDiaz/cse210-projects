public class ListingActivity : Activity
{
    private List<string> _prompts;
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
    }
    public void Run()
    {
        DisplayStartingMessage();
        SetDuration();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        DisplayPrompt(GetRandomPrompt());     
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine($"You listed {GetListFromUser().Count} items!");
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = [];
        DateTime currentTime = DateTime.Now;
        DateTime finishTime = currentTime.AddSeconds(Duration);
        while (currentTime < finishTime)
        {
            Console.Write("> ");
            // ?? operator to avoid null entries
            responses.Add(Console.ReadLine() ?? "");
            currentTime = DateTime.Now;
        }
        return responses;
    }
}