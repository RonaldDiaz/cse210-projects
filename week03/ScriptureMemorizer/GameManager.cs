public class GameManager
{
    private int _level;
    private Scripture _scripture;

    public GameManager()
    {
        _scripture = GetScripture();
        _level = SetLevel();
    }

    public void StartGame()
    {
        Console.Clear();
        Console.WriteLine(_scripture.GetDisplayText());
        bool quit = false;
        while (!_scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish.");
            string input = Console.ReadLine().Trim().ToLower();
            if (input.Equals("quit"))
            {
                quit = true;
                break;
            }
            else
            {
                _scripture.HideRandomWords(_level);
                Console.Clear();
                Console.WriteLine(_scripture.GetDisplayText());
            }
        }
        Console.WriteLine(quit ? "\nSee you next time!" : "\nCongratulations, you finish the exercise!");
    }

    private static Scripture GetScripture()
    {
        Console.Write("Press 1 if you want to select an Scripture from a list, or Enter if you want a random Scripture: ");
        string choice = Console.ReadLine();
        int index = 0;
        if (choice == "1")
        {
            Console.WriteLine(Scripture.GetScripturesMenu());
            Console.WriteLine("Enter the number of the Scripture you want to memorize: ");
            // If input is an integer, set it as the index, otherwise set the index as 0.
            index = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
        }
        return Scripture.GetScripture(index);
    }
    
    private static int SetLevel()
    {
        Console.WriteLine("Select the difficulty level by choosing the number of words to hide each turn: ");
        Console.WriteLine("1. Easy.");
        Console.WriteLine("2. Moderate.");
        Console.WriteLine("3. Hard.");
        string input = Console.ReadLine();
        // If input is an integer (TryParse) and is between 1 and 3, take the value. Otherwise, take 2 (Moderate).
        return int.TryParse(input, out int result) && result > 0 && result < 4 ? result : 2;
    }
}