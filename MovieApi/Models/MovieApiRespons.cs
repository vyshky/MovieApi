using System.Text.Json.Serialization;
using MovieApi.Converters;

namespace MovieApi.Models
{
    public class MovieApiRespons
    {
        [JsonPropertyName("Search")]
        public IEnumerable<Movie> Movies { get; set; }
        
        [JsonPropertyName("totalResults")]
        [JsonConverter(typeof(IntJsonConverter))]
        public int TotalResults { get; set; }
        public string Response { get; set; }
        public string Error { get; set; }
    }
    
    //public class MovieApiRespons
    //{
    //    [JsonPropertyName("Search")]
    //    public IEnumerable<Movie> Movies { get; set; }
        
    //    [JsonPropertyName("totalResults")]
    //    public string TotalResultsString { get; set; }
    //    public int TotalResults { get => Int32.Parse(TotalResultsString); }
    //    public string Response { get; set; }
    //    public string Error { get; set; }
    //}
}