using System.Web;
using System.Web.Mvc;

namespace TWDP.PlayList.SL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
