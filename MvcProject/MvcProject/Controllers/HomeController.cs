using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private EnglishDbContext db = new EnglishDbContext();

        public ActionResult Index()
        {
            var Topics = new List<string>();

            var TopicNames = from d in db.Topics
                             orderby d.Name
                             select d.Name;

            Topics.AddRange(TopicNames.Distinct());
            ViewBag.topicNames = new SelectList(TopicNames);
            ViewBag.searchString = "Noanem";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your applicatiosdadasdadasdn description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}