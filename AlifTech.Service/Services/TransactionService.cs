using AlifTech.Data.IRepositories;
using AlifTech.Domain.DBEntities;
using AlifTech.Service.DTOs.Transactions;
using AlifTech.Service.Exceptions;
using AlifTech.Service.Extensions;
using AlifTech.Service.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace AlifTech.Service.Services
{
    public sealed class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> repository;
        private readonly IRepository<Wallet> walletRepo;
        private readonly IRepository<User> userRepo;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public TransactionService(IRepository<Transaction> repository,
                                  IRepository<Wallet> walletRepo,
                                  IRepository<User> userRepo,
                                  IConfiguration configuration,
                                  IMapper mapper)
        {
            this.repository = repository;
            this.walletRepo = walletRepo;
            this.userRepo = userRepo;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        /// <summary>
        /// Add money to wallet without a sender id.
        /// </summary>
        public async Task<TransactionViewDto> AddMoneyAsync(TransactionNotFromWalletDto dto)
        {
            var receiverWallet = await walletRepo.GetAsync(w => w.Id == dto.ToWalletId);

            if (receiverWallet is null)
                throw new EWalletException(404, "Wallet not found!");

            var user = await userRepo.GetAsync(u => u.Id == receiverWallet.UserId);

            if (user is null)
                throw new EWalletException(404, "User not found!");

            var transactionSettings = configuration[$"TransactionSettings:{(user.IsIdentified ? "Identified" : "Unidentified")}"];
            double amountLimit = double.Parse(transactionSettings);

            if (receiverWallet.Balance + dto.Amount > amountLimit)
                throw new EWalletException(400, $"Balance must not exceed: {amountLimit}");

            receiverWallet.Balance += dto.Amount;
            
            await walletRepo.UpdateAsync(receiverWallet);

            Transaction transaction = mapper.Map<Transaction>(dto);
            
            transaction.CreatedAt = DateTime.UtcNow;

            transaction = await repository.CreateAsync(transaction);

            var view =  mapper.Map<TransactionViewDto>(transaction);
            view.From = string.Concat(user.FirstName, " ", user.LastName);

            return view;
        }

        /// <summary>
        /// Add money / Transaction.
        /// </summary>
        public async Task<TransactionViewDto> AddP2pAsync(TransactionForCreationDto dto)
        {
            var senderWallet = await walletRepo.GetAsync(w => w.Id == dto.SenderWalletId);

            if (senderWallet is null)
                throw new EWalletException(404, "SenderWallet not found!");

            var receiverWallet = await walletRepo.GetAsync(w => w.Id == dto.ReceiverWalletId);

            if (receiverWallet is null)
                throw new EWalletException(404, "ReceiverWallet not found!");

            if (senderWallet.Balance - dto.Amount < 0)
                throw new EWalletException(400, "Not enough money on balance!");

            var user = await userRepo.GetAsync(u => u.Id == receiverWallet.UserId);
            var transactionSettings = configuration[$"TransactionSettings:{(user.IsIdentified ? "Identified" : "Unidentified")}"];
            double amountLimit = double.Parse(transactionSettings);

            if (receiverWallet.Balance + dto.Amount > amountLimit)
                throw new EWalletException(400, $"Balance must not exceed: {amountLimit}");

            senderWallet.Balance -= dto.Amount;
            receiverWallet.Balance += dto.Amount;

            await walletRepo.UpdateAsync(senderWallet);
            await walletRepo.UpdateAsync(receiverWallet);

            Transaction transaction = mapper.Map<Transaction>(dto);

            transaction.CreatedAt = DateTime.UtcNow;

            transaction = await repository.CreateAsync(transaction);

            var view = mapper.Map<TransactionViewDto>(transaction);
            view.From = string.Concat(user.FirstName, " ", user.LastName);

            return view;
        }

        /// <summary>
        /// Get all transactions.
        /// </summary>
        public async Task<TransactionViewDto[]> GetAllAsync(int pageIndex, int pageSize)
        {
            var transactions = repository.GetAll(include: 
                new[] { "ToWallet.User", "FromWallet.User" })
                .Paginate(pageIndex, pageSize);

            var result = new List<TransactionViewDto>(transactions.Count());
            foreach (var item in transactions)
            {
                var viewDto = new TransactionViewDto
                {
                    To = item.ToWallet!.User!.FirstName + " " + item.ToWallet.User.LastName,
                    Amount = item.Amount,
                    CreatedAt = item.CreatedAt,
                    From = item.FromWalletId is null
                        ? item.From
                        : item.FromWallet.User.FirstName + " " + item.FromWallet.User.LastName
                };

                result.Add(viewDto);
            }

            return result.ToArray();
        }
    }
}
