using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopWatch;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopWatch.Stop();
            _logger.Info($"Request: {filterContext.HttpContext.Request.Url.AbsolutePath},{_stopWatch.ElapsedMilliseconds}");
        }
    }
}