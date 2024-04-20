using System.Collections.Generic;
using MovieApi.Models;
namespace MovieApi.Services
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetAll();

        public Movie GetMovieByName(string name);

        public IEnumerable<Movie> GetMoviesByYear(int genre);

        public void UpdateMovie(string name,Movie movie);

        public void DeleteMovie(string name,Movie movie);

        public void InsertMovie(Movie movie);

        
        
    }
}