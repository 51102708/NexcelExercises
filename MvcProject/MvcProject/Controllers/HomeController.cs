using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private EnglishDbContext db = new EnglishDbContext();

        public ActionResult Index()
        {
            var topics = (from d in db.Topics
                          orderby d.Id
                          select d).ToList();

            foreach (var topic in topics)
            {
                var sections = db.Sections.Include(s => s.Topic).Where(x => x.TopicId == topic.Id).ToList();
                topic.Sections = sections;
            }
            BaseViewModel result = new BaseViewModel();
            result.Topics = topics;

            return View(result);
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

        public PartialViewResult GetMenuContent(int menuId)
        {
            return PartialView("Contact");
        }
    }
}