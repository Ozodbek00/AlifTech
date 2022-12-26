using AlifTech.Service.DTOs.UserDTOs;
using AlifTech.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlifTech.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public sealed class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromServices] IAuthService service, UserForLoginDto dto)
        {
            return Ok(await service.GenerateTokenAsync(dto.Login, dto.Password));
        }
    }
}
