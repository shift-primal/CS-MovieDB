using System.Text.Json;

namespace CS_MovieDB;

public class Library
{
	private static readonly JsonSerializerOptions SWriteOptions = new() { WriteIndented = true };

	private static readonly JsonSerializerOptions SReadOptions = new() { AllowTrailingCommas = true };

	private const string PathToJson = "./movies.json";

	private readonly List<Movie> _movieLibrary = [];

	public Library()
	{
		LoadFromJson();
	}

	public void AddToLibrary(Movie movie)
	{
		if (_movieLibrary.Any(m => m.Id == movie.Id))
		{
			Console.WriteLine("Movie is already in your library.");
			return;
		}

		_movieLibrary.Add(movie);

		SaveToJson();
	}

	public void RemoveFromLibrary(int id)
	{
		var movieToRemove = _movieLibrary.FirstOrDefault(m => m.Id == id);

		if (movieToRemove == null)
		{
			Console.WriteLine("Movie not found in library.");
			return;
		}

		_movieLibrary.Remove(movieToRemove);

		SaveToJson();
	}

	public void PrintLibrary()
	{
		var sortedList = _movieLibrary.OrderBy(movie => movie.Id);

		foreach (var movie in sortedList)
		{
			Console.WriteLine("-------------------------------------");
			Console.WriteLine($"Id: {movie.Id}");
			Console.WriteLine($"Title: {movie.Title}");
			Console.WriteLine($"Release Year: {movie.ReleaseYear}");
			Console.WriteLine("-------------------------------------");
			Console.WriteLine("");
		}
	}

	private void SaveToJson()
	{
		string jsonString = JsonSerializer.Serialize(_movieLibrary, SWriteOptions);

		File.WriteAllText(PathToJson, jsonString);
	}

	private void LoadFromJson()
	{
		if (!File.Exists(PathToJson))
		{
			Console.WriteLine("No JSON file found!");
			Console.Write("Creating...");
			File.WriteAllText(PathToJson, "[]");
			return;
		}

		string file = File.ReadAllText(PathToJson);

		if (string.IsNullOrWhiteSpace(file))
		{
			Console.WriteLine("JSON file empty!");
			return;
		}

		var result = JsonSerializer.Deserialize<List<Movie>>(file, SReadOptions);

		if (result == null || result.Count < 1)
		{
			Console.WriteLine("No movies found in JSON file!");
			return;
		}

		_movieLibrary.Clear();
		_movieLibrary.AddRange(result);
	}
}
