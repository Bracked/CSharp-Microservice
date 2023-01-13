using System.Collections.Generic;
using TicketService.Models;

namespace CommandsService.SyncDataServices.Grpc
{
    public interface IMovieDataClient
    {
        IEnumerable<Movie> ReturnAllMovies();
    }
}