using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Repositorys;

public class CommentRepository : RepositoryBase<Comment,BlogDbContext>, ICommentRepository
{
    public CommentRepository(BlogDbContext context) : base(context)
    {
    }

    public Comment AddComment(Comment comment)
    {
        return Add(comment);
    }

    public List<Comment> GetDisplayComments(List<int> displayCommentIds)
    {
        var results = new List<Comment>();
        displayCommentIds.ForEach(x => results.Add(Get(x)));
        return results;
    }
}