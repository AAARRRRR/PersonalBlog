using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface ICommentService
{
    public Task<List<Comment>> GetDisplayComments();
    public Task AddComment(Comment comment);
}