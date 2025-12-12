using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace BackEnd_S6_L5.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Gender { get; set; }
    }
}
