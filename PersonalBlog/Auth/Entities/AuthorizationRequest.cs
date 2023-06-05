namespace PersonalBlog.Auth;

public class AuthorizationRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}