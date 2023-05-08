using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface ICommentService
{
    public List<Comment>? GetDisplayComments();
    public void AddComment(Comment comment);
}