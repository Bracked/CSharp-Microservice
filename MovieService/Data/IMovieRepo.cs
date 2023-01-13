using System.Collections.Generic;
using MovieService.Models;

namespace MovieService.Data
{
    public interface IMovieRepo
    {
        bool SaveChanges();

        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void CreateMovie(Movie plat);
    }
}