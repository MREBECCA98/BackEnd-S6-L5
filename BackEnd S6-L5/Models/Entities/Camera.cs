using System.ComponentModel.DataAnnotations;

namespace BackEnd_S6_L5.Models.Entities
{
    public class Camera
    {
        [Key]
        public Guid IdCamera { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Tipo { get; set; }

        [Required]
        public decimal Prezzo { get; set; }

        public ICollection<Prenotazione>? Prenotazioni { get; set; }
    }
}
