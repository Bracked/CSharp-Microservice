using System.Collections.Generic;
using TicketService.Models;

namespace CardsService.Data
{
    public interface ICardRepo
    {
        bool SaveChanges();

        // Movies
        IEnumerable<Movie> GetAllMovies();
        void CreateMovie(Movie plat);
        bool MovieExits(int MovieId);
        bool ExternalMovieExists(int externalMovieId);

        // Cards
        IEnumerable<Card> GetCardsForMovie(int MovieId);
        Card GetCard(int MovieId, int CardId);
        void CreateCard(int MovieId, Card Card);
    }
}