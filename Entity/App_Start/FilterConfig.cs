using System.Web;
using System.Web.Mvc;
using static Entity.MvcApplication;

namespace Entity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyFilter());

        }
    }
}
