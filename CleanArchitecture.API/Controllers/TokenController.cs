using CleanArchitecture.API.Models;
using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;

        public TokenController(IAuthenticate authenticate)
        {
            _authenticate = authenticate ?? 
                throw new ArgumentNullException(nameof(authenticate));
        }

        [HttpPost("sign-user")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel login)
        {
            var result = await _authenticate.AuthenticateUserAsync(login.Email, login.Password);

            if (result)
            {
                return Ok($"Login of the {login.Email} successfuly!");
            }

            return BadRequest("invalid 'email' or 'password'!");
        }
    }
}
