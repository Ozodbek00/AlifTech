using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlifTech.Service.DTOs.UserDTOs
{
    public sealed class UserForCreationDto
    {
        /// <summary>
        /// Gets && sets FirstName of a User.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets && sets LastName of a User.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets && sets Login of a User.
        /// </summary>
        [Required, MinLength(3), MaxLength(8)]
        public string Login { get; set; }

        /// <summary>
        /// Gets && sets Password of a User.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets && sets if a User is identified.
        /// </summary>
        [DefaultValue(false)]
        public bool IsIdentified { get; set; }
    }
}
