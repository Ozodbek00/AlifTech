namespace AlifTech.Service.DTOs.Transactions
{
    public sealed class TransactionViewDto
    {
        /// <summary>
        /// Gets && sets From address of coming money.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets && sets To address of coming money.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets && sets Amount of money.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets && sets Date of Transaction.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
