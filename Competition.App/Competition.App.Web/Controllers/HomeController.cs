using Competition.App.Services.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Competition.App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;


        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            var homeStats = _homeService.getDashBoardStats();

            return View(homeStats);
        }

        public ActionResult About()
        {
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