using System.Collections.Generic;
using MovieApi.Models;
namespace MovieApi.Repository
{
    public interface IMovieReposiroty
    {
        public IEnumerable<Movie> GetAll();

        public Movie GetMovieByName(string name);

        public IEnumerable<Movie> GetMoviesByYear(int year);

        public void InsertMovie(Movie movie);

        public void UpdateMovie(string name ,Movie movie);

        public void DeleteMovie(string name, Movie movie);
        
    }
}