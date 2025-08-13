namespace CSharpLifeCycle.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"[Middleware] start request: {context.Request.Method} {context.Request.Path}");
            if (context.Request.Headers.TryGetValue("X-Block", out var v) && v.ToString().ToLower() == "true")
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Request be block by middleware (X-Block=true)");
                return;
            }
            await _next(context);
            Console.WriteLine($"[Middleware] end request: StatusCode={context.Response.StatusCode}");
        }
    }
}