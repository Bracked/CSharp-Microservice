using System.Threading.Tasks;
using MovieService.Dtos;

namespace MovieService.SyncDataServices.Http
{
    public interface ITicketDataClient
    {
        Task SendMovieToTicket(MovieReadDto plat); 
    }
}