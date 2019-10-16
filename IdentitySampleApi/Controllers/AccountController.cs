using IdentitySample.EntityLayer.Identity;
using IdentitySampleApi.BusinessLogicLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "Register")]
        public async Task<ActionResult> Post([FromBody]CreateAccountRequestDTO createAccountDTO)
        {
            var appUser = new User();
            appUser.UserName = createAccountDTO.UserName;
            appUser.Email = createAccountDTO.UserName;
            appUser.FirstName = createAccountDTO.FirstName;
            appUser.LastName = createAccountDTO.LastName;

            var response = new CreateAccountResponseDTO();

            IdentityResult result = await _userManager.CreateAsync(appUser, createAccountDTO.PlainPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, false);

                response.AccessToken = GenerateJwtToken(appUser.UserName, appUser);
                response.RefreshToken = string.Empty;
                response.Message.Add("Account created successfully.");
                response.Message.Add("Signed in successfully.");
                response.Status = true;

                return Ok(response);
            }

            response.Message = result.Errors.Select(prop => prop.Description).ToList();
            response.Status = false;

            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("signin", Name = "SignIn")]
        public async Task<ActionResult> Post([FromBody]SignInAccountRequestDTO signInAccountDTO)
        {
            var response = new SignInAccountResponseDTO();

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(signInAccountDTO.UserName, signInAccountDTO.PlainPassword, false, false);
            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == signInAccountDTO.UserName);
                response.AccessToken = GenerateJwtToken(signInAccountDTO.UserName, appUser);
                response.RefreshToken = string.Empty;
                response.Message.Add("Signed in successfully.");
                response.Status = true;

                return Ok(response);
            }

            response.Message.Add("Credentials are invalid.");
            response.Status = false;

            return BadRequest(response);
        }

        private string GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
                new Claim(ClaimTypes.Role, )
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfigure:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtConfigure:ExpireDate"]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                _configuration["JwtConfigure:Issuer"],
                _configuration["JwtConfigure:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return accessToken;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("signout", Name = "SignOut")]
        public IActionResult GetAll()
        {
            return Ok("Logged in with role Admin");
        }
    }
}
