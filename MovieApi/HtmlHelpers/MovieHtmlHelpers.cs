using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieApi.HtmlHelpers
{
    public static class MovieHtmlHelpers
    {
        public static IHtmlContent MovieLink(this IHtmlHelper htmlHelper)
        {
            string link = "<a href=\"https://www.youtube.com\">Youtube</a>";
            return new HtmlString(link);

            //string link = "<script>window.location.href=\"https://www.youtube.com\"</script>";
            //return new HtmlString(link);
        }

        //public static IHtmlContent EmailLink(this IHtmlHelper htmlHelper, string email, string title = null)
        //{
        //    string link = $"<a href=\"mailto:{email}\">{title ?? email}</a>";
        //    return new HtmlString(link);
        //}

        public static IHtmlContent EmailLink(this IHtmlHelper htmlHelper, string email, string title = null)
        {
            var link = new TagBuilder("a");
            link.Attributes["href"] = $"mailto:{email}";
            link.InnerHtml.Append(title ?? email);
            link.AddCssClass("text-danger");
            return link;
        }
    }
}
