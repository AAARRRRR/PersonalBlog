using Microsoft.AspNetCore.Identity;

namespace PersonalBlog.Auth;

public interface ITokenService
{
    public string CreateToken(IdentityUser user);
}