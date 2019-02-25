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

            //below is added so that the app can only be accessed through the secure URL, not the other one which runs alongside of it
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
