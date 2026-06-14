using System;
// Enhancements: Added a player level attribute. When total points reach certain amounts, the player will level-up.
// Added a rank system linked to the level. Added a colorful level-up celebration, based on the rank/level.

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}