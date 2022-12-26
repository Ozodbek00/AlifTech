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
        
        /// <summary>
        /// Create User.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserForCreationDto dto)
        {
            return Ok(await userService.AddAsync(dto));
        }

        /// <summary>
        /// Update User.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, UserForCreationDto dto)
        {
            return Ok(await userService.UpdateAsync(id, dto));
        }

        /// <summary>
        /// Delete User.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await userService.DeleteAsync(id);

            return Ok();
        }

        /// <summary>
        /// Get User by Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await userService.GetByIdAsync(id));
        }

        /// <summary>
        /// Get All Users with pagination
        /// Default pageIndez is 1, pageSize is 20.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
        {
            return Ok(await userService.GetAllAsync(pageIndex, pageSize));
        }
    }
}
