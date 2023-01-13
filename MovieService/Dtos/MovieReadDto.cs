namespace MovieService.Dtos
{
    public class MovieReadDto
    {        
        public int Id { get; set; }

        public string? Name { get; set; }
   
        public string? DeveloperCompany { get; set; }
        
        public string? TicketCost { get; set; }
    }
}