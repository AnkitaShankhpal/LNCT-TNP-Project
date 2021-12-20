using LNCT_TNP_Project.CustomFilter;
using System.Web;
using System.Web.Mvc;

namespace LNCT_TNP_Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlerAttribute());
        }
    }
}
