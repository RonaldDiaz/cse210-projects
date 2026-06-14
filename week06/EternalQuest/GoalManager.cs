public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = [];
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        Console.Clear();
        bool running = true;
        while (running)
        {
            ShowColorMessage($"You have {_score} points accumulated. You are level {_level}: {GetRank()}", "blue");
            UpdateLevel();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("\nThank you for playing Eternal Quest. Keep seeking your path! Goodbye.");
                    break;
                default:
                    ShowColorMessage("Invalid choice. Press Enter to try again.", "red");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("\nWhich type of goal would you like to create? ");
        int.TryParse(Console.ReadLine(), out int choice);

        if (choice < 1 || choice > 3)
        {
            ShowColorMessage("Invalid selection. Goal creation aborted. Press any key to continue.", "red");
            Console.ReadLine();
            return;
        }

        string name;
        do
        {
            Console.Write("What is the name of your goal? ");
            name = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(name));
        string description;
        do
        {
            Console.Write("What is a short description of it? ");
            description = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(description));
        Console.Write("What is the amount of points associated with this goal? ");
        int.TryParse(Console.ReadLine(), out int points);

        Goal newGoal = null;

        switch (choice)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int.TryParse(Console.ReadLine(), out int target);
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int.TryParse(Console.ReadLine(), out int bonus);
                newGoal = new ChecklistGoal(name, description, points, bonus, target);
                break;
        }

        _goals.Add(newGoal);
        ShowColorMessage($"\nSuccess! The goal '{name}' has been created. Press Enter to return to main menu.", "green");
        Console.ReadLine();
    }

    private void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("\nThe goals are:");

        if (_goals.Count == 0)
        {
            ShowColorMessage("No goals loaded or created yet.", "yellow");
        }
        else
        {
            int i = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{i}. {goal.GetDetailsString()}");
                i++;
            }
        }
        Console.WriteLine("\nPress Enter to return to main menu.");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        Console.Clear();
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            ShowColorMessage("Invalid file name. Save canceled", "red");
            return;
        }

        using (StreamWriter writer = new(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        ShowColorMessage($"\nSuccessfully saved current goals and score to '{filename}'! Press Enter to continue.", "green");
        Console.ReadLine();
    }

    private void LoadGoals()
    {
        Console.Clear();
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            ShowColorMessage($"\nFile '{filename}' does not exist!", "red");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length > 0)
        {
            int.TryParse(lines[0], out _score);

            List<Goal> loadedGoals = [];

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                Goal goal = CreateGoalFromLine(line);
                if (goal != null) loadedGoals.Add(goal);
            }

            _goals = loadedGoals;
            UpdateLevel();
            ShowColorMessage($"\nSuccessfully loaded {loadedGoals.Count} goals.", "green");
        }
        else ShowColorMessage("\nThe file is empty.", "yellow");
    }

    private void RecordEvent()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            ShowColorMessage("No goals available to record events! Create a goal first.", "yellow");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].Name}");
        }

        Console.WriteLine("\nWhich goal did you accomplish? ");
        int.TryParse(Console.ReadLine(), out int index);

        if (index < 1 || index > _goals.Count)
        {
            ShowColorMessage("\nInvalid goal index. Recording cancelled.", "red");
            return;
        }
        
        Goal selectedGoal = _goals[index - 1];
        int pointsGained = selectedGoal.RecordEvent();
        _score += pointsGained;

        ShowColorMessage(pointsGained > 0 ? $"\n🎉 Congratulations! You earned {pointsGained} points!" : $"\nThis goal was already completed.", pointsGained > 0 ? "green" : "yellow");

        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }

    private Goal CreateGoalFromLine(string line)
    {
        int goalTypeDelimiter = line.IndexOf(':');
        string goalType = line.Substring(0, goalTypeDelimiter);
        string details = line.Substring(goalTypeDelimiter + 1);
        string[] parts = details.Split(',');

        // [0] name, [1] description, [2] points        
        string name = parts[0];
        string description = parts[1];
        int.TryParse(parts[2], out int points);
    
        switch (goalType)
        {
            case "SimpleGoal":
                // [3] isComplete
                bool.TryParse(parts[3], out bool isComplete);
                return new SimpleGoal(name, description, points, isComplete);
            case "EternalGoal":
                return new EternalGoal(name, description, points);
            case "ChecklistGoal":
                // [3] bonus, [4] target, [5] amountCompleted
                int.TryParse(parts[3], out int bonus);
                int.TryParse(parts[4], out int target);
                int.TryParse(parts[5], out int completed);
                return new ChecklistGoal(name, description, points, bonus, target, completed);
            default:
                return null;
        }
    }
    
    private void UpdateLevel()
    {       
        int newLevel = 1;
        int currentScore = _score;

        if (currentScore >= 21000) newLevel = 7;
        else if (currentScore >= 15000) newLevel = 6;
        else if (currentScore >= 10000) newLevel = 5;
        else if (currentScore >= 6000) newLevel = 4;
        else if (currentScore >= 3000) newLevel = 3;
        else if (currentScore >= 1000) newLevel = 2;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.Clear();
            Console.ForegroundColor = GetColor();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("                   ✨   L E V E L   U P !   ✨");
            Console.WriteLine($"         Congratulations! You have ascended to Level {_level}!");
            Console.WriteLine($"             You have obtained the rank of {GetRank()}!");
            Console.WriteLine("**************************************************************************");
            Console.ResetColor();
        }
        else _level = newLevel;
    }

    private void ShowColorMessage(string message, string color)
    {
        switch (color)
        {
            case "green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            default:
                Console.ResetColor();
                break;
        }
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private string GetRank()
    {
        string[] ranks = ["Spark", "Striver", "Achiever", "Catalyst", "Vanguard", "Architect", "Mastermind"];
        return ranks[_level - 1];
    }

    private ConsoleColor GetColor()
    {
        ConsoleColor[] colors = [ConsoleColor.Gray, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow];
        return colors[_level - 1];
    }
}