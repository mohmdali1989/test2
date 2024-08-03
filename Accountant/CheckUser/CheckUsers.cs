using Microsoft.AspNetCore.Mvc.Filters;

namespace Accountant.CheckUser
{
    public class CheckUsers : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
        public string? Value { get; set; }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
