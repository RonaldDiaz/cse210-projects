public class Comment
{
    private string _poster;
    private string _text;

    public Comment(string poster, string text)
    {
        _poster = poster;
        _text = text;
    }

    public string GetDisplayText()
    {
        return $"@{_poster}: {_text}";
    }
}