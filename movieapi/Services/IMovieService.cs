using System.Collections.Generic;
using MovieApi.Models;
namespace MovieApi.Services
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetAll();

        // public Movie GetMovieByName(string name);

        // public void InsertMovie(Movie movie);

        // public void UpdateMovie(Movie movie);

        // public void DeleteMovie(Movie movie);
        
    }
}