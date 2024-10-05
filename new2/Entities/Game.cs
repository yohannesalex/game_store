using System;

namespace new2.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public  DateOnly ReleaseDate { get; set; }
    public  decimal Price { get; set; }
    public  int GenreId { get; set; }
     public required Genre Genre { get; set; }
}
