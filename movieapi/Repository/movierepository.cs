using System.Collections.Generic;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class MovieRepository : IMovieReposiroty
    {
        public static readonly List<Movie> Movies = new List<Movie>
        {
            new Movie("Citezen Kane", 1941, "Action", 1),
            new Movie("The Wizard of Oz", 1939, "Comedy", 2),
            new Movie("The Godfather", 1972, "Drama", 3),
        };
    

    public MovieRepository() {

    }

    public IEnumerable<Movie> GetAll() {
        return Movies;
    }

    public Movie GetMovieByName(string name) {
        foreach (var movie in Movies) {
            if (movie.Title.Equals(name)) {
                return movie;
            }
        }
        return null;
    }

    public void InsertMovie(Movie movie) {
       Movies.Add(movie);
    }

    public void UpdateMovie(string name ,Movie movie) {
        foreach (var m in Movies) {
            if (m.Id == movie.Id) {
                m.Title = name;
            }
        }
    }

    public void DeleteMovie(string name, Movie movie) {
        Movies.Remove(movie);
    }



}
}
