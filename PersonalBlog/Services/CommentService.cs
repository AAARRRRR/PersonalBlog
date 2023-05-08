using PersonalBlog.Exceptions;
using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class CommentService : ICommentService
{
    private ICommentRepository _commentRepository;
    
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public List<Comment>? GetDisplayComments()
    {
        return _commentRepository.GetDisplayComments().OrderByDescending(x => x.CreatedDate).ToList();
    }
    
    public void AddComment(Comment comment)
    {
        var addedComment = _commentRepository.AddComment(comment);
        if (addedComment == null) throw new CommentInvalidException("Comment is Invalid");
    }
}