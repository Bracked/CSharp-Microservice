using System;
using System.Collections.Generic;
using System.Linq;
using TicketService.Models;

namespace CardsService.Data
{
    public class CardRepo : ICardRepo
    {
        private readonly AppDbContext _context;

        public CardRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCard(int MovieId, Card Card)
        {
            if (Card == null)
            {
                throw new ArgumentNullException(nameof(Card));
            }

            Card.MovieId = MovieId;
            _context.Cards.Add(Card);
        }

        public void CreateMovie(Movie plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Movies.Add(plat);
        }

        public bool ExternalMovieExists(int externalMovieId)
        {
            return _context.Movies.Any(p => p.ExternalID == externalMovieId);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Card GetCard(int MovieId, int CardId)
        {
            return _context.Cards
                .Where(c => c.MovieId == MovieId && c.Id == CardId).FirstOrDefault();
        }

        public IEnumerable<Card> GetCardsForMovie(int MovieId)
        {
            return _context.Cards
                .Where(c => c.MovieId == MovieId)
                .OrderBy(c => c.Movie.Name);
        }

        public bool MovieExits(int MovieId)
        {
            return _context.Movies.Any(p => p.Id == MovieId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}