public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = [];

    public Video(string title, string author, int seconds)
    {
        _title = title;
        _author = author;
        _length = seconds;
    }

    public string GetDisplayText()
    {
        return $"Title: {_title} | Author: {_author} | Duration: {_length} seconds. | Total Comments: {GetTotalComments()}";
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public void AddComment(string poster, string content)
    {
        Comment comment = new(poster, content);
        _comments.Add(comment);
    }

    public int GetTotalComments()
    {
        return _comments.Count;
    }
}