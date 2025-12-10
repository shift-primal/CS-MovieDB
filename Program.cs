namespace CS_MovieDB;

public static class Program
{
	private static readonly MockMovies MockMovies = new();

	private static void Main()
	{
		Library library = new();

		library.PrintLibrary();
	}
}
