public class PromptManager
{
    public List<string> _prompts = LoadPrompts();

    private static List<string> LoadPrompts()
    {
        // To load the file from the program directory instead of compiled directory
        string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        string fileName = "prompts.csv";
        string fullPath = Path.Combine(rootPath, fileName);
        List<string> prompts = [];
        if (File.Exists(fullPath))
        {
            string[] lines = File.ReadAllLines(fullPath);
            prompts.AddRange(lines);
        }
        else
        {
            prompts = [
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "Who was the most interesting person I interacted with today?"
                ];
        }
        return prompts;         
    }

    public string GetRandomPrompt()
    {
        Random random = new();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    public string PromptsMenu()
    {
        while (true)
        {
            int quantity = _prompts.Count;
            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine($"{i + 1}. {_prompts[i]}");            
            }
            int addOption = quantity + 1;
            int editOption = quantity + 2;
            int deleteOption = quantity + 3;
            int quitOption = quantity + 4;
            Console.WriteLine(new string('-', 20));        
            Console.WriteLine($"{addOption}. Add new prompt");
            Console.WriteLine($"{editOption}. Edit prompt");
            Console.WriteLine($"{deleteOption}. Delete prompt");
            Console.WriteLine($"{quitOption}. Return to main menu");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40)); 
            if (option >0 && option <= quantity)
            {
                return _prompts[option - 1];
            }
            else if (option == addOption)
            {
                AddPrompt();
            }
            else if (option == editOption)
            {
                EditPrompt();
            }
            else if (option == deleteOption)
            {
                DeletePrompt();
            }
            else if (option == quitOption)
            {
                return null;
            }
            else
            {
                Console.WriteLine("Invalid prompt selection.");
            }  
        }
    }

    private void AddPrompt()
    {
        Console.WriteLine("Write your new prompt and press Enter to add it or Write 0 to cancel: ");
        string newPrompt = Console.ReadLine();
        if (newPrompt != "0" && !string.IsNullOrWhiteSpace(newPrompt))
        {
            _prompts.Add(newPrompt);
            SavePrompts();
        }
    }
    private void EditPrompt()
    {
        Console.Write("Enter the number of the prompt you want to edit: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _prompts.Count)
        {
            Console.WriteLine($"Selected prompt: {_prompts[index]}");
            Console.WriteLine("Write your new prompt and press Enter to change it or Write 0 to cancel: ");
            string newPrompt = Console.ReadLine();
            if (newPrompt != "0" && !string.IsNullOrWhiteSpace(newPrompt))
            {
                _prompts[index] = newPrompt;
                SavePrompts();
            }
        }        
    }

    private void DeletePrompt()
    {
        Console.WriteLine("Enter the number of the prompt you want to delete: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _prompts.Count)
        {
            Console.WriteLine($"Selected prompt: {_prompts[index]}");
            Console.WriteLine("Write 1 to confirm deletion or Write 0 to cancel: "); 
            string confirmation = Console.ReadLine();
            if (confirmation == "1")
            {
                _prompts.RemoveAt(index);
                SavePrompts();
            }
        }
    }
    private void SavePrompts()
    {
        // To save the file in the program directory instead of compiled directory
        string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        string fileName = "prompts.csv";
        string fullPath = Path.Combine(rootPath, fileName);
        File.WriteAllLines(fullPath, _prompts);
    }
}