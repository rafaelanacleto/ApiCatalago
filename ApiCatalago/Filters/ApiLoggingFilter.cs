using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCatalago.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //executa depois da action
            _logger.LogInformation("### Executando -> OnActionExecuted");
            _logger.LogInformation("############################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //executa antes da action
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("############################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        }
    }
}
