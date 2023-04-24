using PersonalBlog.Data;
using PersonalBlog.Models;

namespace PersonalBlog.Repositorys;

public class CommentRepository : RepositoryBase<Comment,BlogDbContext>
{
    public CommentRepository(BlogDbContext context) : base(context)
    {
    }

    public Comment AddComment(Comment comment)
    {
        return Add(comment);
    }
}