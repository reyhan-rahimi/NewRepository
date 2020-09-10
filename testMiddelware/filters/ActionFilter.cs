using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testMiddelware.filters
{
    public class ActionFilter : IActionFilter
    {
       
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("on action executed");

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("on action executing ");
        }
    }
}
