using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositories;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class CommentRepository : RepositoryBase<Comment,BlogDbContext>, ICommentRepository
{
    public CommentRepository(BlogDbContext context) : base(context)
    {
    }

    public Comment AddComment(Comment comment)
    {
        return Add(comment);
    }

    public List<Comment>? GetDisplayComments()
    {
        return All().Where(x => x.IsDisplay).ToList();
    }
}