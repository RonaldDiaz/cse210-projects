public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
            ];
        _questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
            ];
    }
    
    public void Run()
    {
        DisplayStartingMessage();
        SetDuration();
        Console.WriteLine("Consider the following prompt:\n");
        DisplayPrompt(GetRandomPrompt());     
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("Now ponder on each of the following questions as they related to this experience.\nYou may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private static string GetRandomQuestion(List<string> questions)
    {
        Random random = new();
        int index = random.Next(questions.Count);
        string question = questions[index];
        questions.RemoveAt(index);
        return question;
    }
    
    private void DisplayQuestions()
    {
        int timePerQuestion = 15;
        DateTime currentTime = DateTime.Now;
        DateTime finishTime = DateTime.Now.AddSeconds(Duration);
        // Create a copy of the question's list. Selected questions will be removed
        List<string> questions = [.. _questions];
        while (currentTime < finishTime)
        {
            if (questions.Count == 0)
            {
                questions = [.. _questions];
            }
            Console.Write($"> {GetRandomQuestion(questions)} ");
            ShowSpinner(timePerQuestion);
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
    }
}