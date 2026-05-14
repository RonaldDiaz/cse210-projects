public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private string _loadedJournal;

    public void AddEntry(string prompt)
    {
        Console.WriteLine(prompt);
        string content = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(content))
        {
            Entry entry = new(prompt, content);
            _entries.Add(entry);            
        }
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.DisplayEntry());
            Console.WriteLine(new string('-', 40)); 
        }
        Console.WriteLine($"Total entries: {_entries.Count}");        
    }

    public void LoadJournal()
    {
        Console.Write("Write the name of the journal you want to load (example: journal.csv): ");
        string filename = Console.ReadLine();
        
        // To load the file from the program directory instead of compiled directory
        string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        string fullPath = Path.Combine(rootPath, filename);
        if (File.Exists(fullPath))
        {
            _loadedJournal = filename;
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                _entries.AddRange(Entry.FromCsv(line));
            }
            Console.WriteLine($"File {filename} loaded sucessfully.");
            
        }
        else
        {
            Console.WriteLine($"File {filename} not found in {rootPath}");            
        }    
    }

    public void SaveJournal()
    {
        string filename;
        if (string.IsNullOrWhiteSpace(_loadedJournal))
        {
            Console.Write("Write the filename to save (example: journal.csv): ");
            filename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Invalid filename. Save canceled.");
                return;
            }
        } 
        else
        {
            filename = _loadedJournal;
        }
        
        // To save the file in the program directory instead of compiled directory
        string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        string fullPath = Path.Combine(rootPath, filename);
        List<string> lines = new List<string>();
        foreach (Entry entry in _entries)
        {
            lines.Add(entry.ToCsv());
        }
        File.WriteAllLines(fullPath, lines);
        Console.WriteLine($"File {filename} saved sucessfully in {fullPath}");        
    }
}