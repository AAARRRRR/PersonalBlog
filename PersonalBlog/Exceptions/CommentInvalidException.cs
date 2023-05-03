namespace PersonalBlog.Exceptions;

public class CommentInvalidException : Exception
{
    public CommentInvalidException(string? message) : base(message)
    {
    }
}