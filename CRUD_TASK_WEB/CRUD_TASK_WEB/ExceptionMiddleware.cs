namespace CRUD_TASK_WEB
{
   public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;    // This is a pointer to the next middleware or part of the app that should run.
        private readonly ILogger<ExceptionMiddleware> _logger;  // This lets us log errors to the console or a file. Super useful for debugging.

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); // run the next part of the app
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json"; // return JSON format
        context.Response.StatusCode = StatusCodes.Status500InternalServerError; // set HTTP 500

        var response = new
        {
            statusCode = context.Response.StatusCode,
            message = ex.Message,                      // main error message
            details = ex.InnerException?.Message       // extra info if available
        };

        return context.Response.WriteAsJsonAsync(response); // send the response
    }
}

}
