namespace PersonalBlog.Auth;

public class AuthorizationResponse
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}