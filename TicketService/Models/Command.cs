using System.ComponentModel.DataAnnotations;

namespace TicketService.Models
{
    public class Card
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CardLine { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie {get; set;}
    }
}