using System;
using Microsoft.Extensions.Logging;

namespace AWD.Web.Core.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly string _basePath;

        public FileLoggerProvider(string basePath, Func<string, LogLevel, bool> filter)
        {
            _basePath = basePath;
            _filter = filter;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _basePath, _filter);
        }

        public void Dispose()
        {
        }
    }
}