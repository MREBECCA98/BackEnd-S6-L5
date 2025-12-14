using System.ComponentModel.DataAnnotations;

namespace BackEnd_S6_L5.Models.Dto
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
