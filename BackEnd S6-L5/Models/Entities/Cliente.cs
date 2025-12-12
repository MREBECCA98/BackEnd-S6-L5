using System.ComponentModel.DataAnnotations;

namespace BackEnd_S6_L5.Models.Entities
{
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cognome { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        public string Telefono { get; set; }

        public ICollection<Prenotazione>? Prenotazioni { get; set; }

    }
}
