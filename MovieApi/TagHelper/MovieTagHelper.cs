using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MovieApi.TagHelpers
{

    //public class MovieTagHelper : TagHelper
    //{
    //    public string AspEmail { get; set; } // asp-email
    //    public string AspTitle { get; set; } // asp-title
    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {
    //        //output.TagName = "button";
    //        //output.Content.Append("Click");    

    //        //output.TagName = "a";
    //        //output.Content.Append("Youtube");
    //        //output.Attributes.Add("href","https://www.youtube.com");

    //        output.TagName = "a";
    //        output.Content.Append(AspTitle ?? AspEmail);
    //        output.Attributes.Add("href", $"mailto:{AspEmail}");
    //    }
    //}

    //[HtmlTargetElement("a")]
    //public class MovieTagHelper : TagHelper
    //{
    //    public string AspEmail { get; set; } // asp-email
    //    public string AspTitle { get; set; } // asp-title
    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {
    //        //output.TagName = "button";
    //        //output.Content.Append("Click");    

    //        //output.TagName = "a";
    //        //output.Content.Append("Youtube");
    //        //output.Attributes.Add("href","https://www.youtube.com");

    //        output.TagName = "a";
    //        output.Content.Append(AspTitle ?? AspEmail);
    //        output.Attributes.Add("href", $"mailto:{AspEmail}");
    //    }
    //}

    [HtmlTargetElement("a",Attributes = "AspEmail")] // применяет логику только к тегу a- у которого есть Attributes - "AspEmail"
    public class MovieTagHelper : TagHelper
    {
        public string AspEmail { get; set; } // asp-email
        public string AspTitle { get; set; } // asp-title
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AspEmail != null)
            {
                output.TagName = "a";
                output.Content.Append(AspTitle ?? AspEmail);
                output.Attributes.Add("href", $"mailto:{AspEmail}");
            }
        }
    }
}
