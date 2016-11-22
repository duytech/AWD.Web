using System;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace AWD.Web.Core.ViewEngine
{
    public class DbFileProvider : IFileProvider
    {
        public const string RESOURCE_VIEW_PREFIX = "/ResourceView?";

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            // check the url was received from browser
            if (subpath.StartsWith(RESOURCE_VIEW_PREFIX))
            {
                var razor = new RazorViewFileInfo();
                return razor;
            }

            return null;
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }
    }
}