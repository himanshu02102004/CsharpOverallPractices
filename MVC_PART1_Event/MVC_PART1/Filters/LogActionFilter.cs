using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.IO;

public class LogActionFilter : IActionFilter
{
    private readonly string _logFilePath = "Logs/action_logs.txt";

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string method = context.HttpContext.Request.Method;
        string url = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
        string controller = (context.ActionDescriptor as ControllerActionDescriptor)?.ControllerName;
        string action = (context.ActionDescriptor as ControllerActionDescriptor)?.ActionName;

        string log = $"[{timestamp}] Request: {method} {url} => {controller}/{action}";
        WriteLog(log);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string status = context.Exception == null ? "Success" : "Failed";

        string log = $"[{timestamp}] Result: {status}";
        WriteLog(log);
    }

    private void WriteLog(string log)
    {
        string logDir = Path.GetDirectoryName(_logFilePath);
        if (!Directory.Exists(logDir))
        {
            Directory.CreateDirectory(logDir);
        }

        File.AppendAllText(_logFilePath, log + Environment.NewLine);
    }
}
