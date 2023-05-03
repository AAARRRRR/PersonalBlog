using PersonalBlog.Exceptions;
using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class CommentService : ICommentService
{
    protected ICommentRepository _CommentRepository;
    
    public CommentService(ICommentRepository commentRepository)
    {
        _CommentRepository = commentRepository;
    }
    public List<Comment> GetDisplayComments(List<int> displayCommentIds)
    {
        return _CommentRepository.GetDisplayComments(displayCommentIds);
    }
    
    public void AddComment(Comment comment)
    {
        var addedComment = _CommentRepository.AddComment(comment);
        if (addedComment == null) throw new CommentInvalidException("Comment is Invalid");
    }
}