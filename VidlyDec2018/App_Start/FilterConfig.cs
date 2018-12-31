using System.Web;
using System.Web.Mvc;

namespace VidlyDec2018
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //below is added to apply authorisation throughout the whole app...
            //...use [AllowAnonymous] above any method / class that you wish to be allowed with no authorisation, in each controller
            filters.Add(new AuthorizeAttribute());
        }
    }
}
