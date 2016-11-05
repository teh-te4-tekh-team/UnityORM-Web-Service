using System.Web;
using System.Web.Mvc;

namespace Teh_te4_tekh_ORM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
