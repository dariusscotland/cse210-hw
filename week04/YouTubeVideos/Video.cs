public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments = new List<Comment>(); 

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine($"TITLE: {_title}");
        Console.WriteLine($"AUTHOR: {_author}");
        Console.WriteLine($"LENGTH: {_lengthSeconds} seconds");
        Console.WriteLine($"COMMENT COUNT: {GetNumberOfComments()}");
        Console.WriteLine("--- Comments ---");

        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine("=======================================\n");
    }
}