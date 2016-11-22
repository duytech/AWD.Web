using Microsoft.AspNetCore.Html;

namespace AWD.Controls.Contexts
{
    /// <summary>
    /// A context class that will be used to keep track of the contents of the 2 child tag helpers.
    /// </summary>
    public class ModalContext
    {
        public IHtmlContent Body { get; set; }
        public IHtmlContent Footer { get; set; }
    }
}