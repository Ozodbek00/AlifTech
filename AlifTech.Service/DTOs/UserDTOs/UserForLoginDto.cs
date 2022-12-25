using System.ComponentModel.DataAnnotations;

namespace AlifTech.Service.DTOs.UserDTOs
{
    public sealed class UserForLoginDto
    {
        /// <summary>
        /// Gets && sets Login of a User.
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Gets && sets Password of a User.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
