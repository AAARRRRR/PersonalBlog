using PersonalBlog.Exceptions;
using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<List<Comment>> GetDisplayComments()
    {
        var comments = await _commentRepository.GetDisplayComments();
        return comments.OrderByDescending(x => x.CreatedDate).ToList();
    }
    
    public async Task AddComment(Comment comment)
    {
        var addedComment = await _commentRepository.AddComment(comment);
        if (addedComment == null) throw new CommentInvalidException("Comment is Invalid");
    }
}