namespace CRUD_TASK_WEB
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR OCCURED PLEASE THE SERVER ONCE AGAIN");
                context.Response.StatusCode = 500;
                //  await context.Response.WriteAsJsonAsync(new { error = ex.Message });
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "ERROR OCCURRED. PLEASE CHECK THE SERVER." 
                });


            }
        }
    }
}
