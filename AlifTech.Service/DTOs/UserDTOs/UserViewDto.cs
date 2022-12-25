using AlifTech.Domain.DBEntities;

namespace AlifTech.Service.DTOs.UserDTOs
{
    public sealed class UserViewDto
    {
        /// <summary>
        /// Gets && sets Id of a User.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets && sets FirstName of a User.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets && sets LastName of a User.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets && sets Login of a User.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets && sets if a User is identified or unidentified.
        /// </summary>
        public bool IsIdentified { get; set; }

        /// <summary>
        /// Gets && sets Collection of Wallets of a User.
        /// </summary>
        public IEnumerable<Wallet>? Wallets { get; set; }
    }
}
