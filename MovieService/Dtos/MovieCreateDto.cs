using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos
{
    public class MovieCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? DeveloperCompany { get; set; }

        [Required]
        public string? TicketCost { get; set; }
    }
}