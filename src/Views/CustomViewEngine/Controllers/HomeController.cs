using System;
using System.Web.Mvc;
namespace CustomViewEngine.Controllers
{
    using Models;
    using MvcContrib.Filters;

    [Layout("Site")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		
        public ActionResult Contact()
        {
            var companyInfo = new CompanyInfo
                                  {
                                      CompanyName = "Your company name here",
                                      AddressLine1 = "Company address Line 1",
                                      AddressLine2 = "Company address Line 2",
                                      City = "City",
                                      State = "State",
                                      Zip = "00000",
                                      Email = "email@yourcompany.com"
                                  };

            return View(companyInfo);
        }

		
        public ActionResult About()
        {
            ViewData["now"] = DateTime.Now;

            return View();
        }
        
        [Layout("")]
        public ActionResult Ads()
        {
            return View("_ads");
        }
    }
}