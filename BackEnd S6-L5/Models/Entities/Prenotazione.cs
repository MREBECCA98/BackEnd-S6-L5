using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_S6_L5.Models.Entities
{
    public class Prenotazione
    {
        [Key]
        public Guid IdPrenotazione { get; set; }

        [Required]
        public DateTime DataInizio { get; set; }

        [Required]
        public DateTime DataFine { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Stato { get; set; }


        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        [ForeignKey(nameof(CameraId))]
        public Camera Camera { get; set; }
        public Guid CameraId { get; set; }
    }
}
