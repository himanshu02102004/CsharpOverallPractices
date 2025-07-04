namespace MVC_PART1.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

       public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies["AuthToken"];
                Console.WriteLine("Middleware token: " + token);
            if (!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Authorization = "Bearer " + token;
            }

            await _next(context);
        }
    }
}
