using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AuthenticationAPI.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [StringLength(200)]
        public String NombreCompleto { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
