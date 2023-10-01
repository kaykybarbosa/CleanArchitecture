using CleanArchitecture.API.Models;
using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate ??
                throw new ArgumentNullException(nameof(authenticate));
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("sign-user")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel login)
        {
            var result = await _authenticate.AuthenticateUserAsync(login.Email, login.Password);

            if (result)
            {
                var token = GenerateToken(login);
                return Ok(token);
            }

            ModelState.AddModelError(string.Empty, "Error: invalid 'email' or 'password'!");
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost("register-user")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Register([FromBody] RegisterModel register)
        {
            var emailNoExist = await _authenticate.FindEmailAsync(register.Email);
            if (emailNoExist)
            {
                var result = await _authenticate.RegisterUserAsync(register.Email, register.Password);

                if (result)
                {
                    return Ok($"User '{register.Email}' was create successfully!");
                }

                ModelState.AddModelError(string.Empty, $"Error: unable to register '{register.Email}', try again. ");
                return BadRequest(ModelState);
            }

            ModelState.AddModelError(string.Empty, $"Error: this email '{register.Email}' is already in use!");
            return BadRequest(ModelState);
        }

        private UserToken GenerateToken(LoginModel login)
        {
            //user declaration 
            var claims = new[]
            {
                new Claim("email", login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //generation of the securitkey
            var secretKey = _configuration["Jwt:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //generation the digital signature
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //settings expiration time
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //generate Token
            JwtSecurityToken token = new(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
