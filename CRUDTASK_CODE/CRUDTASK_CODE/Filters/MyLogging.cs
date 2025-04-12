using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDTASK_CODE.Filters
{
    public class MyLogging : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Filter Executed before");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("filter executed after");
        }
    }
}
