using AlifTech.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlifTech.Domain.DBEntities
{
    public sealed class User : Auditable
    {
        /// <summary>
        /// Gets && sets FirstName of a User.
        /// </summary>
        [MaxLength(32)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets && sets LastName of a User.
        /// </summary>
        [MaxLength(32)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets && sets Login of a User.
        /// </summary>
        [MinLength(3), MaxLength(8), JsonIgnore]
        public string Login { get; set; }

        /// <summary>
        /// Gets && sets Password of a User.
        /// </summary>
        [MaxLength(128), JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Gets && sets if a User is identified or unidentified.
        /// </summary>
        [JsonIgnore]
        public bool IsIdentified { get; set; }
    }
}
