using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Helpers
{
    public class CustomEmailTagHelper: TagHelper
    {
        public string MonEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
           // output.Attributes.SetAttribute("href", "mailto:mouhameddiouf19@gmail.com");
            output.Attributes.SetAttribute("href", $"mailto:{MonEmail}");
            output.Attributes.Add("id", "mon-email-id");
            output.Content.SetContent("Mon email");
        }
    }
}
