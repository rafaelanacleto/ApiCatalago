using System.Collections.Concurrent;

namespace ApiCatalago.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {

        readonly CustomLoggerProviderConfiguration _config;
        readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
