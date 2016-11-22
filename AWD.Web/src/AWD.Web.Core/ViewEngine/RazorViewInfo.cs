using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace AWD.Web.Core.ViewEngine
{
    public class RazorViewFileInfo : IFileInfo
    {
        public bool Exists
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsDirectory
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset LastModified
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PhysicalPath
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }
}