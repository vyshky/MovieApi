using MovieApi.Models;

namespace MovieApi.Services
{
	public interface IMovieApiServices
	{
        string BaseUrl { get; }
        string ApiKey { get; }
        Task<MovieApiRespons> SearchByTitle(string title,int page);
        Task<Movie> SearchById(string id);
	}
}