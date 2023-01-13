using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DeveloperCompany { get; set; }

        [Required]
        public string? TicketCost { get; set; }
    }
}