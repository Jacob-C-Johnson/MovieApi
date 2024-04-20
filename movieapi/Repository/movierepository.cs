using System.Collections.Generic;
using System.Data;
using MovieApi.Models;
using MySql.Data.MySqlClient;

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
    
    private MySqlConnection _connection;
    public MovieRepository() {
        string connectionstring = "server=localhost;userid=csci330user;password=csci330pass;database=entertainment";
        _connection = new MySqlConnection(connectionstring);
        _connection.Open();
    }
    ~MovieRepository() {
        _connection.Close();
    }

    public IEnumerable<Movie> GetAll() {
        var statement = "SELECT * FROM movies";
        var cmd = new MySqlCommand(statement, _connection);
        var result = cmd.ExecuteReader();

        List<Movie> newList = new List<Movie>(20);
        
        while (result.Read()) {
            Movie m = new Movie((string)result[1], (int)result[2], (string)result[3], 0);
            newList.Add(m);
        }
        result.Close();
        return newList;
        //return Movies;
    }

    public Movie GetMovieByName(string name) {
        var statement = "SELECT * FROM movies WHERE name = @title";
        var cmd = new MySqlCommand(statement, _connection);
        cmd.Parameters.AddWithValue("@title", name);
        var result = cmd.ExecuteReader();
        Movie m = null;
        if (result.Read()){
        m = new Movie((string)result[1], (int)result[2], (string)result[3], 0);
        result.Close();
        }
        return m;
    }

    public void InsertMovie(Movie movie) {
        var statement = "INSERT INTO movies (name, year, genre) VALUES (@name, @year, @genre)";
        var cmd = new MySqlCommand(statement, _connection);
        cmd.Parameters.AddWithValue("@name", movie.Title);
        cmd.Parameters.AddWithValue("@year", movie.Year);
        cmd.Parameters.AddWithValue("@genre", movie.Genre);
        int result = cmd.ExecuteNonQuery();
        Console.WriteLine(result);
    }

    public void UpdateMovie(string name ,Movie movie) {
        try {
            var statement = "UPDATE movies SET name = @newname, year = @year, genre = @genre WHERE name = @updatename ";
            var cmd = new MySqlCommand(statement, _connection);
            cmd.Parameters.AddWithValue("@newname", movie.Title);
            cmd.Parameters.AddWithValue("@year", movie.Year);
            cmd.Parameters.AddWithValue("@genre", movie.Genre);
            cmd.Parameters.AddWithValue("@updatename", name);
            int result = cmd.ExecuteNonQuery();
            } catch (MySqlException e) {
                Console.WriteLine(e.Message);
            }
    }

    public void DeleteMovie(string name, Movie movie) {
        var statement = "DELETE FROM movies WHERE name = @name";
        var cmd = new MySqlCommand(statement, _connection);
        cmd.Parameters.AddWithValue("@name", name);
        int result = cmd.ExecuteNonQuery();
    }

    public IEnumerable<Movie> GetMoviesByYear(int year) {
        var statement = "SELECT * FROM movies WHERE year = @year";
        var cmd = new MySqlCommand(statement, _connection);
        cmd.Parameters.AddWithValue("@year", year);
        var result = cmd.ExecuteReader();

        List<Movie> newList = new List<Movie>(20);
        
        while (result.Read()) {
            Movie m = new Movie((string)result[1], (int)result[2], (string)result[3], 0);
            newList.Add(m);
        }
        result.Close();
        return newList;


}
}
}
