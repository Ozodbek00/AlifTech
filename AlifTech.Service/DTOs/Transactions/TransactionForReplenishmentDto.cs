namespace AlifTech.Service.DTOs.Transactions
{
    public sealed class TransactionForReplenishmentDto
    {
        /// <summary>
        /// Gets && sets total number of transactions.
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// Gets && sets total amount of money transacted.
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// Gets && sets Collection of Transactions.
        /// </summary>
        public IEnumerable<TransactionViewDto>? Transactions { get; set; } 
    }
}
