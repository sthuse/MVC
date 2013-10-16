using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using CherryTomato;

namespace MovieFanClub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UpcomingList()
        {
            string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            var tomatoe = new Tomato(ApiKey);
            var upComingList = tomatoe.FindUpcomingMoviesList();
            return View(upComingList);
        }

        public ActionResult BoxOfficeList()
        {
            string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            var tomatoe = new Tomato(ApiKey);
            var BoxOfficeList = tomatoe.FindBoxOfficeList();
            return View(BoxOfficeList);
        }

        public ActionResult Edit(int RottenTomatoesId)
        {
            string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            var tomatoe = new Tomato(ApiKey);
            var temp  = tomatoe.FindMovieById(RottenTomatoesId);

            ViewBag.id = RottenTomatoesId;

            if (null == temp)
                return View("NotFound");
            else
                return View(temp);

        }

        public ActionResult InTheaterList()
        {
            string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
            var tomatoe = new Tomato(ApiKey);
            var InTheaterList = tomatoe.FindMoviesInTheaterList();
            return View(InTheaterList);
        }



    }
}
