namespace PersonalBlog.Exceptions;

public class ArticleNullException : Exception
{
    public ArticleNullException(string? message) : base(message)
    {
    }
}