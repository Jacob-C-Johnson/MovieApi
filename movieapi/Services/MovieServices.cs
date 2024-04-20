using System.Collections.Generic;
using MovieApi.Models;
using MovieApi.Repository;
namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {
        private IMovieReposiroty _repo;

        public MovieService(IMovieReposiroty repo)
        {
            _repo = repo;
        }

        public IEnumerable<Movie> GetAll()
        {
            IEnumerable<Movie> myList = _repo.GetAll();
            return myList;
        }

        public Movie GetMovieByName(string name)
        {
            Movie movie = _repo.GetMovieByName(name);
            return movie;
        }

        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            IEnumerable<Movie> myList = _repo.GetMoviesByYear(year);
            return myList;
        }

        public void InsertMovie(Movie movie)
        {
            _repo.InsertMovie(movie);
        }

        public void UpdateMovie(string name, Movie movie)
        {
            _repo.UpdateMovie(name, movie);
        }

        public void DeleteMovie(string name,Movie movie)
        {
            _repo.DeleteMovie(name, movie);
        }


    }
}