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
            var topics = GetAllTopics();
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

        public ActionResult Contents(int? sectionId, int? topicId)
        {
            if ((sectionId == null) || (topicId == null))
            {
                return RedirectToAction("Index");
            }
            var topics = GetAllTopics();

            var section = db.Sections.Where(s => s.TopicId == topicId && s.Id == sectionId).First();
            section.Pharses = db.Pharses.Where(s => s.SectionId == sectionId).ToList();
            return View(new BaseViewModel
            {
                Topics = topics,
                CurrentSection = section,
                CurrentTopicId = (int)topicId,
                CurrentSectionId = (int)sectionId
            });
        }

        [NonAction]
        public IEnumerable<Topic> GetAllTopics()
        {
            var topics = (from d in db.Topics
                          orderby d.Id
                          select d).ToList();

            foreach (var topic in topics)
            {
                var sections = db.Sections.Include(s => s.Topic).Where(x => x.TopicId == topic.Id).ToList();
                topic.Sections = sections;
            }

            return topics;
        }
    }
}