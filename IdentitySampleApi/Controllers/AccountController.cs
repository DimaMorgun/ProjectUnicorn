using IdentitySample.EntityLayer.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentitySampleApi.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("create", Name = "Create")]
        public async Task<ActionResult> Post([FromBody]User userModel)
        {
            string password = HttpContext.Request.Query["password"];
            IdentityResult result = await _userManager.CreateAsync(userModel, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userModel, isPersistent: false);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("signin", Name = "SignIn")]
        public async Task<ActionResult> Get(string username, string password)
        {
            bool isPersistent = true;

            User user = await _userManager.FindByNameAsync(username);
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, true);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("signout", Name = "SignOut")]
        public async Task<ActionResult> Get(string username)
        {
            await _signInManager.SignOutAsync();

            return Ok(true);
        }

        [Authorize]
        [HttpGet("test", Name = "Test")]
        public ActionResult Get()
        {
            return Ok(true);
        }
    }
}
