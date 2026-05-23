// Enhancements: Added functionality to allow the user select a scripture from a list.
// Added a choice to select game dificulty (number of words hidden per turn).
// Added the class Game Manager to handle new functionality.
// Aditional Resources consulted:
// https://www.quora.com/How-do-I-generate-a-list-of-random-integers-without-repeating-in-C
// https://imaginaformacion.com/tutoriales/strings-en-c-sharp
// https://codemia.io/knowledge-hub/path/best_way_to_repeat_a_character_in_c
// https://www.aprendeaprogramar.com/referencia/view.php?f=Console.Clear&leng=Csharp
// https://code-maze.com/csharp-print-elements-of-an-array/
// https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/operators/conditional-operator
// https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/where-clause
// https://www.geeksforgeeks.org/c-sharp/c-sharp-adding-the-elements-of-the-specified-collection-to-the-end-of-the-list/
// https://learn.microsoft.com/en-us/dotnet/api/system.random.getitems?view=net-10.0#:~:text=In%20this%20article,length%20Int32
// https://www.geeksforgeeks.org/c-sharp/c-sharp-boolean-tryparse-method/
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer");
        Console.WriteLine(new string('=', 40));
        
        GameManager game = new();
        game.StartGame();

        Console.WriteLine("Thank you for playing Scripture Memorizer!");
    }
}