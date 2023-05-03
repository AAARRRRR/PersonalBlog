using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface ICommentService
{
    public List<Comment> GetDisplayComments(List<int> displayCommentIds);
    public void AddComment(Comment comment);
}