public class Movie
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public int Id { get; set; }
    
    public Movie(string title, int year, string genre, int id)
    {
        Title = title;
        Year = year;
        Genre = genre;
        Id = id;
    }

    // Add methods and additional functionality here

    public override string ToString()
    {
        return $"{Title} ({Year}) - {Genre}";
    }
}