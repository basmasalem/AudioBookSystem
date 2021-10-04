using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Core.Admin.Models
{

    [HtmlTargetElement("a", Attributes = "is-active-route")]
    public class ActiveItemTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-class")]
        public string Class { get; set; } = "active-page";

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string currentController = (string)ViewContext.RouteData.Values["controller"];
            string currentAction = (string)ViewContext.RouteData.Values["action"];
            if (currentController == Controller /*&& currentAction == (Action ?? currentAction)*/)
            {
                if (output.Attributes.ContainsName("class"))
                {
                    var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == "class"); //get value of 'class'
                    output.Attributes.SetAttribute("class", currentAttribute.Value.ToString() + " " + Class);

                }
                else
                    output.Attributes.SetAttribute("class", Class);
            }
        }
    }


}
