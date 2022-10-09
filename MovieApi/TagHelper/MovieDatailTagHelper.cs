using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MovieApi.TagHelpers
{
    public class MovieDatailTagHelper : TagHelper
    {
        public Movie Movie { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("class", "btn btn-primary");
            output.Attributes.Add("href", $"/Home/Movie?id={Movie.imdbID}");

            var icon = new TagBuilder("i");
            if(Movie.Type == "movie")
            {
                icon.AddCssClass("Movie");
                output.Content.Append("Movie");
            }
            else if (Movie.Type == "series")
            {
                icon.AddCssClass("series");
                output.Content.Append("series");
            }
            else if (Movie.Type == "game")
            {
                icon.AddCssClass("game");
                output.Content.Append("game");
            }

            //output.Content.AppendHtml(icon);
            //output.Content.Append("Detail");

        }
    }
}
