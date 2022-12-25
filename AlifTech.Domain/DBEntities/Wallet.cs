using AlifTech.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlifTech.Domain.DBEntities
{
    public sealed class Wallet : Auditable
    {
        /// <summary>
        /// Gets && sets Balance of a Wallet.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Gets && sets Id of a User if a Wallet.
        /// </summary>
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
