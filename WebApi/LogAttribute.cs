using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Web.Http.Controllers;

namespace WebApi
{
    public class LogAttribute : Attribute, IActionFilter
    {
        public LogAttribute()
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            return;            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string statusCode = context.Result.GetType().GetProperty("StatusCode").GetValue(context.Result, null)?.ToString();
            string acao = context.RouteData.Values.FirstOrDefault().Value.ToString();
            if (acao == "Delete" && statusCode == "200")
            { 
                Trace.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " - Card " + context.ActionDescriptor.Id + " - Removido");
            }
            if (acao == "Put" && statusCode == "200")
            {
                Trace.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " - Card " + context.ActionDescriptor.Id + " - Alterado");
            }
        }
    }
}
