using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MovieApi.Models;
using MovieApi.Options;
using System.Text.Json;

namespace MovieApi.Services
{
    public class MovieApiServices : IMovieApiServices
    {
        public string BaseUrl { get; }
        public string ApiKey { get; }

        private readonly IMemoryCache memoryCache;

        private readonly HttpClient httpClient;
        public MovieApiServices(IHttpClientFactory httpClientFactory, IOptions<MovieApiOptions> options, IMemoryCache memoryCache)
        {
            //https://omdbapi.com/?i=tt3221698&apikey=5b9b7798&page=2 Detail
            //"https://omdbapi.com/?apikey=5b9b7798&s={title}"
            BaseUrl = options.Value.BaseUrl;
            ApiKey = options.Value.ApiKey;
            httpClient = httpClientFactory.CreateClient();
            this.memoryCache = memoryCache;
        }
        public async Task<MovieApiRespons> SearchByTitle(string title ,int page)//1 , 2 ,Hulk
        {
            //Hulk
            MovieApiRespons result;            
            string search = title.ToLower();
            //hulk
            if (!memoryCache.TryGetValue($"{search}_page{page}", out result))
            {
                var respons = await httpClient.GetAsync($"{BaseUrl}?apikey={ApiKey}&s={title}&page={page}");
                var json = await respons.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<MovieApiRespons>(json);               
                if (result.Response == "False")
                {
                    throw new Exception(result.Error);
                }               
                memoryCache.Set(title,result); // Установить время хранения - хранит в памяти сервера
            }
            return result;
        }

        public async Task<Movie> SearchById(string id)
        {
            Movie result;
            if (!memoryCache.TryGetValue(id, out result))
            {
                //https://omdbapi.com/?i=tt3221698&apikey=5b9b7798&page=2 Detail
                var respons = await httpClient.GetAsync($"{BaseUrl}?apikey={ApiKey}&i={id}");
                var json = await respons.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<Movie>(json);
                if (result.Response == "False")
                {
                    throw new Exception(result.Error);
                }
                memoryCache.Set(id, result); // Установить время хранения - хранит в памяти сервера
            }
            return result;
        }
    }
}

