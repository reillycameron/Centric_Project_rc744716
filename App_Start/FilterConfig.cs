using System.Web;
using System.Web.Mvc;

namespace Centric_Project_rc744716
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
