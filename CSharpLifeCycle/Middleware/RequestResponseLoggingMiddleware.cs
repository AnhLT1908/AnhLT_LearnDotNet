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
            Console.WriteLine($"[Middleware] Start request: {context.Request.Method} {context.Request.Path}");

       
            await _next(context);

            Console.WriteLine($"[Middleware] End request: StatusCode={context.Response.StatusCode}");
        }
    }
}