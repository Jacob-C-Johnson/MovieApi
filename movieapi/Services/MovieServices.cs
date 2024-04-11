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


    }
}