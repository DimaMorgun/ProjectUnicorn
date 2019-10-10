using IdentitySample.EntityLayer.Identity;
using IdentitySampleApi.PresentationLayer.Entities;
using IdentitySampleApi.PresentationLayer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentitySampleApi.PresentationLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;
        private AppSettings _appSettings;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
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
            User user = await _userManager.FindByEmailAsync(username);
            if (user == null)
            {
                return null;
            }
            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, userRoles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return Ok(token);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("signout", Name = "SignOut")]
        public IActionResult GetAll()
        {
            return Ok("Logged in with role Admin");
        }
    }
}
