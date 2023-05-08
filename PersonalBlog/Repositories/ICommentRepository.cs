using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface ICommentRepository
{
    public Comment AddComment(Comment comment);

    public List<Comment>? GetDisplayComments();

}