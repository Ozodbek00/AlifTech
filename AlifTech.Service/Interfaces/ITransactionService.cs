using AlifTech.Domain.DBEntities;
using AlifTech.Service.DTOs.Transactions;
using System.Linq.Expressions;

namespace AlifTech.Service.Interfaces
{
    public interface ITransactionService
    {
        /// <summary>
        /// Add money without a sender.
        /// </summary>
        Task<TransactionViewDto> AddMoneyAsync(TransactionNotFromWalletDto dto);
        
        /// <summary>
        /// Commit a regular transaction.
        /// </summary>
        Task<TransactionViewDto> AddP2pAsync(TransactionForCreationDto dto);

        /// <summary>
        /// Gets All Transactions.
        /// </summary>
        Task<TransactionViewDto[]> GetAllAsync(int pageIndex, int pageSize, Expression<Func<Transaction, bool>> expression = null);
    }
}
