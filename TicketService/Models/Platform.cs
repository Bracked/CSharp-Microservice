using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketService.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Card> Cards { get; set; } = new List<Card>();
     }
}