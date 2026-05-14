// Enhancements: Added functionality to select, create, edit and delete prompts.
// Added prompt persistence by saving and reading from a file.
// Selected CSV as file format, and included custom separator to allow quotes and commas.
// Learning Resources:
// https://codemia.io/knowledge-hub/path/best_way_to_repeat_a_character_in_c
// https://stackoverflow.com/questions/4220993/c-sharp-how-to-convert-file-readlines-into-string-array
// https://www.reddit.com/r/csharp/comments/1gpowzd/how_to_check_if_user_has_not_given_any_char_input/
// https://ironpdf.com/es/blog/net-help/csharp-string-split/
// https://www.youtube.com/watch?v=2V86at4ivLs#:~:text=El%20video%20trata%20sobre%20la%20elecci%C3%B3n%20entre,se%20podr%C3%ADa%20preferir%20este%20tipo%20de%20bucle.
// https://www.tutorialspoint.com/article/how-to-read-a-csv-file-and-store-the-values-into-an-array-in-chash

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new();
        PromptManager promptManager = new();
        bool run = true;

        Console.WriteLine("Welcome to your personal journal.");

        while (run)
        {
            Console.WriteLine(new string('-', 40));       
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write (Random Prompt)");
            Console.WriteLine("2. Write (Specific Prompt)");
            Console.WriteLine("3. Display");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string option = Console.ReadLine();
            Console.WriteLine(new string('-', 40)); 

            switch (option)
            {
                case "1":
                    journal.AddEntry(promptManager.GetRandomPrompt());
                    break;                
                case "2":
                    string prompt = promptManager.PromptsMenu();
                    if (prompt != null)
                    {
                        journal.AddEntry(prompt);
                    }
                    break;
                case "3":
                    journal.DisplayAll();
                    break;
                case "4":
                    journal.LoadJournal();
                    break;
                case "5":
                    journal.SaveJournal();
                    break;
                case "6":
                    run = false;
                    break;
                default:
                Console.WriteLine("Invalid option, try again.");                
                    break;
            }
        }   
    }
}