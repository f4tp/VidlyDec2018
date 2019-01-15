using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VidlyDec2018.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //as the page associated with this does not change very often, it can be cached at client side using this, giving performance enhancement
        //can be cached on the server if it is not specific to the user, or if it is, cache it on the client
        //varybyParam means if there are different arguments passed to this method, it will cache a different page for each e.g. genre, * means if there are multiple different parameters, cache a page for each one
        //do not do this before performance testing through e.g. glimpse
        //negatives of caching - providing stale data to clients... narking them off
        //if people are complaining that things are not working properly, check caching


        //[OutputCache(Duration = 50, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "genre")]
        // [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)] - DISABLES CACHING
        //The above disables caching on an action when caching is applied at controller level
        //outputcache is for html caching, not data... for data... see customersController (not API)
        [OutputCache(Duration = 50, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            throw new Exception();
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}