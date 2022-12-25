using AlifTech.Domain.DBEntities;
using AlifTech.Service.DTOs.UserDTOs;

namespace AlifTech.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Add dto to database.
        /// </summary>
        Task<User> AddAsync(UserForCreationDto dto);

        /// <summary>
        /// Update User in database.
        /// </summary>
        Task<User> UpdateAsync(long id, UserForCreationDto dto);

        /// <summary>
        /// Delete User in database.
        /// </summary>
        Task DeleteAsync(long id);

        /// <summary>
        /// Get User by Id.
        /// </summary>
        Task<UserViewDto> GetByIdAsync(long id);

        /// <summary>
        /// Get all Users with pagination.
        /// </summary>
        Task<IEnumerable<User>> GetAllAsync(int pageIndex, int pageSize);
    }
}
