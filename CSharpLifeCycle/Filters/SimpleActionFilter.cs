using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharpLifeCycle.Filters
{
    public class SimpleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("[ActionFilter] before run action");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("[ActionFilter] after run action");
        }
    }
}