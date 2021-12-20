using LNCT_TNP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNCT_TNP_Project.CustomFilter
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //throw new NotImplementedException();
            if (!filterContext.ExceptionHandled)
            {
                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now
                };

                LNCT_TNP_DBEntities ctx = new LNCT_TNP_DBEntities();
                ctx.ExceptionLoggers.Add(logger);
                ctx.SaveChanges();

                filterContext.ExceptionHandled = true;
                
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Error/Index.cshtml"
                };
            }
        }
    }
}