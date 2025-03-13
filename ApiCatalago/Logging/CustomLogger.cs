
namespace ApiCatalago.Logging
{
    public class CustomLogger : ILogger
    {
        readonly string _name;
        readonly CustomLoggerProviderConfiguration _config;

        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            _name = name;
            _config = config;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $" {logLevel.ToString()} - ID: {eventId.Id} - Name: {eventId.Name} - {formatter(state, exception)}";

            WriteLog(message);

        }

        private void WriteLog(string message)
        {
            string caminhoArquivoLog = @"log.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
