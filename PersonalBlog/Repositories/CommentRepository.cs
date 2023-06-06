using LinqKit;
using PersonalBlog.Data;
using PersonalBlog.Infrastruture;
using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public class CommentRepository : RepositoryBase<Comment,BlogDbContext>, ICommentRepository
{
    public CommentRepository(BlogDbContext context) : base(context)
    {
    }

    public async Task<Comment> AddComment(Comment comment)
    {
        return await Add(comment);
    }

    public async Task<List<Comment>> GetDisplayComments()
    {
        var predicate = PredicateBuilder.False<Comment>();
        var displayCommentPredicate = predicate.Or(comment => comment.IsDisplay);
        var displayComments = await Where(displayCommentPredicate);
        return displayComments;
    }
}