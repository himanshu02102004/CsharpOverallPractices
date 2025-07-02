using System.Web.Mvc;

namespace MVC_PART1.Filters
{
    public class ExceptionCheck:FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext FilterContext)
        {

            {

            }

            {

            }


            FilterContext.Result = new ViewResult()
           {
            ViewName = "Error"
           };


            FilterContext.ExceptionHandled = true; 
        }


    }
}
