using IdentitySample.EntityLayer.Identity;
using IdentitySampleApi.BusinessLogicLayer.DTO.Account.Create;
using IdentitySampleApi.BusinessLogicLayer.DTO.Account.SignIn;
using IdentitySampleApi.BusinessLogicLayer.Models;
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
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Register", Name = "Register")]
        public async Task<ActionResult> Post([FromBody]CreateAccountRequestDTO createAccountDTO)
        {
            var appUser = new User();
            appUser.UserName = createAccountDTO.UserName;
            appUser.Email = createAccountDTO.UserName;
            appUser.FirstName = createAccountDTO.FirstName;
            appUser.LastName = createAccountDTO.LastName;

            var response = new CreateAccountResponseDTO();

            string scheme = HttpContext.Request.Scheme;
            string callbackUrl = Url.RouteUrl("Post", "Account", null, scheme);
            callbackUrl = Url.Action("Post", "Account", null, scheme);

            IdentityResult result = await _userManager.CreateAsync(appUser, createAccountDTO.PlainPassword);
            if (result.Succeeded)
            {
                var accessTokenPayload = new JWTAccessTokenPayloadModel();
                accessTokenPayload.UniqueId = Guid.NewGuid().ToString();
                accessTokenPayload.UserId = appUser.Id;
                accessTokenPayload.UserName = appUser.UserName;
                accessTokenPayload.UserRoles = await _userManager.GetRolesAsync(appUser);
                response.AccessToken = GetAccessToken(accessTokenPayload);

                var refreshTokenPayload = new JWTRefreshTokenPayloadModel();
                refreshTokenPayload.UniqueId = Guid.NewGuid().ToString();
                refreshTokenPayload.AccessToken = response.AccessToken;
                response.RefreshToken = GetRefreshToken(refreshTokenPayload);

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
        [HttpPost("SignIn", Name = "SignIn")]
        public async Task<ActionResult> Post([FromBody]SignInAccountRequestDTO signInAccountDTO)
        {
            var response = new SignInAccountResponseDTO();

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(signInAccountDTO.UserName, signInAccountDTO.PlainPassword, false, false);
            if (result.Succeeded)
            {
                User appUser = _userManager.Users.SingleOrDefault(r => r.Email == signInAccountDTO.UserName);

                var accessTokenPayload = new JWTAccessTokenPayloadModel();
                accessTokenPayload.UniqueId = Guid.NewGuid().ToString();
                accessTokenPayload.UserId = appUser.Id;
                accessTokenPayload.UserName = appUser.UserName;
                accessTokenPayload.UserRoles = await _userManager.GetRolesAsync(appUser);
                response.AccessToken = GetAccessToken(accessTokenPayload);

                var refreshTokenPayload = new JWTRefreshTokenPayloadModel();
                refreshTokenPayload.UniqueId = Guid.NewGuid().ToString();
                refreshTokenPayload.AccessToken = response.AccessToken;
                response.RefreshToken = GetRefreshToken(refreshTokenPayload);

                response.Message.Add("Signed in successfully.");
                response.Status = true;

                return Ok(response);
            }

            response.Message.Add("Credentials are invalid.");
            response.Status = false;

            return BadRequest(response);
        }

        private string GetAccessToken(JWTAccessTokenPayloadModel payload)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, payload.UniqueId));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, payload.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, payload.UserId));
            foreach (string role in payload.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfigure:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtConfigure:AccessTokenExpireDate"]));

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

        private string GetRefreshToken(JWTRefreshTokenPayloadModel payload)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, payload.UniqueId));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, payload.AccessToken));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfigure:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtConfigure:RefreshTokenExpireDate"]));

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

        [Authorize(Roles = Entities.Role.Admin)]
        [HttpGet("SignOut", Name = "SignOut")]
        public IActionResult Get()
        {
            return Ok("Signed out with role Admin");
        }
    }
}
