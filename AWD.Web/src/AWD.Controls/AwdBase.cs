
using System.Threading.Tasks;
using AWD.Controls.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AWD.Controls
{
    // Create an html tag.
    [HtmlTargetElement("az-", TagStructure = TagStructure.NormalOrSelfClosing)]
    public abstract class AwdBase : TagHelper
    {
        [HtmlAttributeName("id")]
        public string Id { get; set; }
        private TagHelperOutput output;

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.output = output;
            output.Attributes.Add(HtmlAttributes.Id, Id);
            output.Attributes.Add(HtmlAttributes.Name, Id);
            return base.ProcessAsync(context, output);
        }
    }
}