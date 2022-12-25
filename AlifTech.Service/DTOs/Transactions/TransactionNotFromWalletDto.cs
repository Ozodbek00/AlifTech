namespace AlifTech.Service.DTOs.Transactions
{
    public sealed class TransactionNotFromWalletDto
    {
        /// <summary>
        /// Gets && sets From address of coming money.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets && sets id of wallet where money is coming to.
        /// </summary>
        public long ToWalletId { get; set; }

        /// <summary>
        /// Gets && sets amount of coming money.
        /// </summary>
        public double Amount { get; set; }
    }
}
