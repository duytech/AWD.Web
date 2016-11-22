using System.Threading.Tasks;
using AWD.Controls.Contexts;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AWD.Controls.Modal
{
    [HtmlTargetElement("modal-body", ParentTag = "modal")]
    public class ModalBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = context.Items[typeof(ModalTagHelper)] as ModalContext;
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }
}