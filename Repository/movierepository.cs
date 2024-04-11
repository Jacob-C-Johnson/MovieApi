using System.Collections.Generic
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class MovieRepository 
    {
        public static readonly List<Movie> Movies = new List<Movie>
        {
            new Movie("Citezen Kane", 1941, "Action", 1),
            new Movie("The Wizard of Oz", 1939, "Comedy", 2),
            new Movie("The Godfather", 1972, "Drama", 3),
        };
    }

    public MovieRepository() {

    }

    public IEnemerable<Movie> GetMovies() {
        return Movies;
    }

}
