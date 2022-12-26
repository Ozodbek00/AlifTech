using AlifTech.Data.IRepositories;
using AlifTech.Domain.DBEntities;
using AlifTech.Service.DTOs.UserDTOs;
using AlifTech.Service.Exceptions;
using AlifTech.Service.Extensions;
using AlifTech.Service.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AlifTech.Service.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IRepository<Wallet> walletRepo;
        private readonly IMapper mapper;

        public UserService(IRepository<User> repository,
                           IRepository<Wallet> walletRepo,
                           IMapper mapper)
        {
            this.repository = repository;
            this.walletRepo = walletRepo;
            this.mapper = mapper;
        }

        /// <summary>
        /// Adds User by mapping && checking.
        /// </summary>
        public async Task<UserViewDto> AddAsync(UserForCreationDto dto)
        {
            // check for exist
            var anyUser = await repository.GetAsync(u =>
                u.Login.Equals(dto.Login) || u.Password.Equals(dto.Password.HashPassword()));
            
            if (anyUser is not null)
                throw new EWalletException(400, "User already exist!");

            dto.Password = dto.Password.HashPassword();

            var newUser = mapper.Map<User>(dto);
            newUser.CreatedAt = DateTime.UtcNow;

            await repository.CreateAsync(newUser);

            var wallet = new Wallet()
            {
                Balance = 0,
                UserId = newUser.Id,
                CreatedAt = DateTime.UtcNow
            };

            await walletRepo.CreateAsync(wallet);

            return mapper.Map<UserViewDto>(newUser);
        }

        /// <summary>
        /// Updates User by id.
        /// </summary>
        public async Task<UserViewDto> UpdateAsync(long id, UserForCreationDto dto)
        {
            // check for exist
            var user = await repository.GetAsync(u => u.Id == id);
            if (user is null)
                throw new EWalletException(404, "User not found!");

            // check for already exist
            var existLogin = await repository.GetAsync(u =>
                u.Login.Equals(dto.Login) && u.Id != id);

            if (existLogin is not null)
                throw new EWalletException(400, "This login already exist!");

            user = mapper.Map(dto, user);
            user.Password = dto.Password.HashPassword();
            user.UpdatedAt = DateTime.UtcNow;

            user = await repository.UpdateAsync(user);

            return mapper.Map<UserViewDto>(user);
        }

        /// <summary>
        /// Deletes User by id.
        /// </summary>
        public async Task DeleteAsync(long id)
        {
            var user = await repository.GetAsync(u => u.Id == id);

            if (user is null)
                throw new EWalletException(404, "User not found!");

            await repository.DeleteAsync(u => u.Id == id);
        }

        /// <summary>
        /// Gets User by id.
        /// </summary>
        public async Task<UserViewDto> GetByIdAsync(long id)
        {
            var user = await repository.GetAsync(u => u.Id == id);

            if (user is null)
                throw new EWalletException(404, "User not found!");

            var userView = mapper.Map<UserViewDto>(user);

            return userView;
        }

        /// <summary>
        /// Gets all User by mapping with pagination.
        /// </summary>
        public async Task<UserViewDto[]> GetAllAsync(int pageIndex, int pageSize)
        {
            IQueryable<UserViewDto> users = repository
                .GetAll()
                .Paginate(pageIndex, pageSize)
                .ProjectTo<UserViewDto>(mapper.ConfigurationProvider);

            return await users.ToArrayAsync();
        }
    }
}
