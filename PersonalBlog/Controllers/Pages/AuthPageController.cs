using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonalBlog.Auth;
using PersonalBlog.Authorization;
using Index = System.Index;

namespace PersonalBlog.Controllers.Pages;

[AllowAnonymous]
public class AuthPageController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly UsersContext _context;
    private readonly ITokenService _tokenService;
    
    public AuthPageController(UserManager<IdentityUser> userManager, UsersContext context, ITokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }
    
    [Route("login")]
    public IActionResult Index()
    {
        return View();
    }
    
    // [HttpPost]
    // [Route("register")]
    // public async Task<IActionResult> Register([FromForm] RegistrationRequest registration)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }
    //     
    //     var result = await _userManager.CreateAsync(
    //         new IdentityUser { UserName = registration.Username, Email = registration.Email},
    //         registration.Password
    //     );
    //     
    //     if (result.Succeeded)
    //     {
    //        registration.Password = "";
    //         return CreatedAtAction(nameof(Register), new {email = registration.Email}, registration);
    //     }
    //     
    //     foreach (var error in result.Errors) {
    //         ModelState.AddModelError(error.Code, error.Description);
    //     }
    //     return BadRequest(ModelState);
    // }

    [HttpPost]
    [Route("admin")]
    public async Task<ActionResult<AuthorizationResponse>> Authenticate([FromForm] AuthorizationRequest userAuth)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByEmailAsync(userAuth.Email);
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, userAuth.Password);
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var userInDb = _context.Users.FirstOrDefault(u => u.Email == userAuth.Email);
        if (userInDb is null)
            return Unauthorized();

        var accessToken = _tokenService.CreateToken(userInDb);
        await _context.SaveChangesAsync();

        //Todo:有效期内显示登陆信息，过时退出登陆，更新token，cookie
        Response.Cookies.Append("X-Access-Token", accessToken,
            new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
        Response.Cookies.Append("X-UserName", userInDb.UserName,
            new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
        return View();
    }

    //     if (ModelState.IsValid)
    //     {
    //         var signIn = await _signInManager.PasswordSignInAsync(userAuth.Email, userAuth.Password, false, false);
    //
    //         if (signIn.Succeeded)
    //         {
    //             var user = await _userManager.FindByEmailAsync(userAuth.Email);
    //             var token = _tokenService.CreateToken(user);
    //             
    //             await _userManager.UpdateAsync(user);
    //
    //             Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
    //             Response.Cookies.Append("X-Email", user.Email, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
    //
    //             return Ok();
    //         }
    //         else
    //         {
    //             return BadRequest(new { signIn.IsLockedOut, signIn.IsNotAllowed, signIn.RequiresTwoFactor });
    //         }
    //     }
    //     else
    //         return BadRequest(ModelState);
    // }
}