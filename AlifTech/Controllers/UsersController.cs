using AlifTech.Service.DTOs.UserDTOs;
using AlifTech.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlifTech.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserForCreationDto dto)
        {
            return Ok(await userService.AddAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, UserForCreationDto dto)
        {
            return Ok(await userService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await userService.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await userService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
        {
            return Ok(await userService.GetAllAsync(pageIndex, pageSize));
        }
    }
}
