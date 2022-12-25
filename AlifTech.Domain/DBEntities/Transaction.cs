﻿using AlifTech.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlifTech.Domain.DBEntities
{
    public sealed class Transaction : Auditable
    {
        /// <summary>
        /// Gets && sets Amount of a Transaction.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets && sets Id of a Wallet money coming from.
        /// </summary>
        public long? FromWalletId { get; set; }
        [ForeignKey(nameof(FromWalletId))]
        public Wallet FromWallet { get; set; }

        /// <summary>
        /// Gets && sets Id of a Wallet momey coming to.
        /// </summary>
        public long ToWalletId { get; set; }
        [ForeignKey(nameof(ToWalletId))]
        public Wallet ToWallet { get; set; }
    }
}
