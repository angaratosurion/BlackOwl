using System.Web;
using System.Web.Mvc;

namespace BlackOwl.Core.Application
{
    public class FilterConfig:BlackCogs.Application.FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
