using BaiTestPhuHung.Commands.UserCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaiTestPhuHung.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(result != "User registered successfully")
            {
                return BadRequest(new { message = result });
            }
            return Ok(new {message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            if (token == "Invalid username or password")
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(new { Token = token , message="Login Success" });
        }


    }
}
