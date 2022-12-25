using AlifTech.Service.DTOs.Transactions;

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
        Task<IEnumerable<TransactionViewDto>> GetAllAsync(int pageIndex, int pageSize);
    }
}
