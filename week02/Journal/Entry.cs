public class Entry
{
    public string _date;
    public string _prompt;
    public string _content;

    public Entry(string prompt, string content)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _prompt = prompt;
        _content = content;
    }

    public string ToCsv()
    {
        return $"{_date}|{_prompt}|{_content}";
    }
    public static Entry FromCsv(string text)
    {
        string[] parts = text.Split("|");
        Entry entry = new(parts[1], parts[2]);
        entry._date = parts[0];
        return entry;
    }

    public string DisplayEntry()
    {
        return $"Date: {_date} \nPrompt: {_prompt} \nEntry: {_content}";
    }
}