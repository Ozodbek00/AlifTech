using AlifTech.Domain.DBEntities;
using AlifTech.Service.DTOs.Transactions;
using AlifTech.Service.DTOs.UserDTOs;
using AutoMapper;

namespace AlifTech.Service.Mappers
{
    public sealed class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping entities.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserForCreationDto, User>();
            CreateMap<User, UserViewDto>();

            CreateMap<TransactionForCreationDto, Transaction>();
            CreateMap<TransactionNotFromWalletDto, Transaction>();
            CreateMap<Transaction, TransactionViewDto>();
            CreateMap<IQueryable<Transaction>, List<TransactionViewDto>>();
        }
    }
}
