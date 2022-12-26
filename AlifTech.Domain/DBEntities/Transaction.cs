using AlifTech.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlifTech.Domain.DBEntities
{
    public sealed class Transaction : Auditable
    {
        /// <summary>
        /// Gets && sets Amount of a Transaction.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets && sets From address of money coming from.
        /// </summary>
        [MaxLength(100)]
        public string? From { get; set; }

        /// <summary>
        /// Gets && sets Id of a Wallet money coming from.
        /// </summary>
        [AllowNull]
        public long? FromWalletId { get; set; }
        [ForeignKey(nameof(FromWalletId))]
        public Wallet? FromWallet { get; set; }

        /// <summary>
        /// Gets && sets Id of a Wallet momey coming to.
        /// </summary>
        public long ToWalletId { get; set; }
        [ForeignKey(nameof(ToWalletId))]
        public Wallet? ToWallet { get; set; }
    }
}
