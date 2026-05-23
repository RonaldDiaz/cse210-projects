public class Scripture 
{
    private Reference _reference;
    private List<Word> _words = [];

    private Scripture(Reference reference, string text) 
    {
        _reference = reference;
        _words.AddRange(from word in text.Split(' ') select new Word(word));
    }

    public void HideRandomWords(int quantity)
    {
        Word[] visibleWords = [.. from word in _words where !word.IsHidden() select word];
        Word[] wordsToHide = Random.Shared.GetItems(visibleWords, quantity);
        foreach (Word word in wordsToHide)
        {
            word.Hide();
        }        
    }

    public string GetDisplayText()
    {
        string[] text = [.. from word in _words select word.GetDisplayText()];
        return $"\n\n{_reference.GetDisplayText()}\n{new string('=', 20)}\n'{string.Join(' ', text)}'";
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public static Scripture GetScripture(int index)
    {
        // If a vslid index is passed, return that index's (-1) Scripture, otherwise return a random Scripture.
        return scripturesList[index > 0 && index <= scripturesList.Count ? index - 1 : new Random().Next(scripturesList.Count)];
    }

    public static string GetScripturesMenu()
    {
        string menu = "";
        for (int i = 0; i < scripturesList.Count; i++)
        {
            menu += $"{i + 1}. {scripturesList[i]._reference.GetDisplayText()}\n";
        }
        return menu;
    }
    private static List<Scripture> scripturesList =
    [
        new Scripture(new Reference("Matthew", 5, 16), "Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."),
        new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
        new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
        new Scripture(new Reference("James", 1, 5),"If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him."),
        new Scripture(new Reference("Proverbs", 3, 5, 6),"Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
        new Scripture(new Reference("Joshua", 1, 9),"Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."),
        new Scripture(new Reference("Isaiah", 1, 18),"Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."),
        new Scripture(new Reference("1 Nephi", 3, 7),"And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
        new Scripture(new Reference("2 Nephi", 2, 25),"Adam fell that men might be; and men are, that they might have joy."),
        new Scripture(new Reference("2 Nephi", 31, 20),"Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, and a love of God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life."),
        new Scripture(new Reference("Alma", 37,35),"O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God."),
        new Scripture(new Reference("Moroni", 10, 4),"And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.")
    ];
    
}