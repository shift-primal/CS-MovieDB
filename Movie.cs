namespace CS_MovieDB;

public class Movie
{
	public required int Id { get; set; }
	public required string Title { get; set; }
	public required int ReleaseYear { get; set; }

	public string? Description { get; set; } = null;
	public string? Genre { get; set; } = null;
	public bool? Watched { get; set; } = null;
	public string? Language { get; set; } = null;
	public double? Rating { get; set; } = null;
	public double? RunTime { get; set; } = null;
	public string? ImageUrl { get; set; } = null;
}
