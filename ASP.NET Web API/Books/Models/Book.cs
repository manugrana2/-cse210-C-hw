namespace Books.Models;

public class Book{
    public int Id { get; set; }
    public string? URI { get; set; }
    public required string Name { get; set; }
    public required string Abstract { get; set; }
    public string? VideoReview{ get; set; }
}
