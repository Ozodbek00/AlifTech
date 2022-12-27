using AlifTech.Service.DTOs.Transactions;
using AlifTech.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlifTech.Api.Controllers
{
    [ApiController, Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Get all Transactions for the current month.
        /// </summary>
        [HttpGet("last-monthly-report")]
        public async Task<IActionResult> GetAllTransactionsAsync(int pageIndex, int pageSize)
        {
            var thisMonth = DateTime.Now.Month;
            var thisYear = DateTime.Now.Year;

            return Ok(await transactionService.GetAllAsync(pageIndex, pageSize, transaction =>
                transaction.CreatedAt.Month == thisMonth && transaction.CreatedAt.Year == thisYear));
        }

        /// <summary>
        /// Get all Replenishments for the current month.
        /// </summary>
        [HttpGet("last-month-replenishments-report")]
        public async Task<IActionResult> GetAllReplenishmentsAsync(int pageIndex, int pageSize)
        {
            var thisMonth = DateTime.Now.Month;
            var thisYear = DateTime.Now.Year;

            var replenishments = await transactionService.GetAllAsync(pageIndex, pageSize, transaction =>
                transaction.FromWalletId == null &&
                transaction.CreatedAt.Month == thisMonth &&
                transaction.CreatedAt.Year == thisYear);

            return Ok(new TransactionForReplenishmentDto
            {
                TotalAmount = replenishments.Sum(rep => rep.Amount),
                TotalCount = replenishments.Count(),
                Transactions = replenishments
            });
        }

        /// <summary>
        /// Get all People to People Transactions report for the current month.
        /// </summary>
        [HttpGet("last-month-p2p-report")]
        public async Task<IActionResult> GetAllTransactionsP2pAsync(int pageIndex, int pageSize)
        {
            var thisMonth = DateTime.Now.Month;
            var thisYear = DateTime.Now.Year;

            var replenishments = await transactionService.GetAllAsync(pageIndex, pageSize, transaction =>
                transaction.FromWalletId != null &&
                transaction.CreatedAt.Month == thisMonth &&
                transaction.CreatedAt.Year == thisYear);

            return Ok(new TransactionForReplenishmentDto
            {
                TotalAmount = replenishments.Sum(rep => rep.Amount),
                TotalCount = replenishments.Length,
                Transactions = replenishments
            });
        }

        /// <summary>
        /// Replenish wallet balance.
        /// </summary>
        [HttpPost("replenishment")]
        public async Task<IActionResult> ReplenishAsync(TransactionNotFromWalletDto dto)
        {
            return Ok(await transactionService.AddMoneyAsync(dto));
        }

        /// <summary>
        /// Create Person to person transaction.
        /// </summary>
        [HttpPost("person-to-person-transaction"), Authorize]
        public async Task<IActionResult> AddTransactionAsync(TransactionForCreationDto dto)
        {
            return Ok(await transactionService.AddP2pAsync(dto));
        }
    }
}
