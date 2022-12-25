using System.ComponentModel.DataAnnotations;

namespace AlifTech.Service.DTOs.Transactions
{
    public sealed class TransactionForCreationDto
    {
        /// <summary>
        /// Gets && sets Id of a Sender Wallet.
        /// </summary>
        public long SenderWalletId { get; set; }

        /// <summary>
        /// Gets && sets Id of a Receiver Wallet.
        /// </summary>
        [Required]
        public long ReceiverWalletId { get; set; }

        /// <summary>
        /// Gets && sets Amount of a Transaction.
        /// </summary>
        [Required]
        public double Amount { get; set; }
    }
}
