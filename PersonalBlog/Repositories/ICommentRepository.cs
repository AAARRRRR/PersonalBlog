using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface ICommentRepository
{
    public Task<Comment> AddComment(Comment comment);

    public Task<List<Comment>> GetDisplayComments();

}