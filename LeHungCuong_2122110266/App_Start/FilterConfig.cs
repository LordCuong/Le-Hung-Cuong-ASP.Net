using System.Web;
using System.Web.Mvc;

namespace LeHungCuong_2122110266
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
