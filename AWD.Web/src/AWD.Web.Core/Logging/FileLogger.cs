using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace AWD.Web.Core.Logging
{
    public class FileLogger : ILogger
    {
        protected static readonly object thisLock = new object();
        private readonly string _categoryName;
        private readonly string _filename;
        private readonly string _path;
        private readonly Func<string, LogLevel, bool> _filter;

        public FileLogger(string basePath)
        {
            _path = Path.Combine(basePath, "Logs");
        }

        public FileLogger(string categoryName, string basePath, Func<string, LogLevel, bool> filter)
        {
            var today = DateTime.Today;
            _path = Path.Combine(basePath, "Logs");
            _filename = $"awd-{today.Year}-{today.Month}-{today.Day}.log";
            _categoryName = categoryName;
            _filter = filter;
        }


        public bool IsEnabled(LogLevel logLevel)
        {
            return _filter == null || _filter(_categoryName, logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            var curTime = String.Format("{0:HH:mm:ss}", DateTime.Now);
            message = $"{curTime} : {logLevel}: {_categoryName} : {message}";

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception;
            }

            //write to file here.
            if (!Directory.Exists(_path)) Directory.CreateDirectory(_path);
            lock (thisLock)
            {
                using (var writer = File.AppendText(Path.Combine(_path, _filename)))
                {
                    writer.WriteLine($"{message}");
                }
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}