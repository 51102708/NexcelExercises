namespace BusinessEnglish.Sites.Controllers
{
    using System.Linq;
    using System.Data;
    using System.Data.Entity;
    using System.Web.Mvc;
    using BusinessEnglish.Services;
    using BusinessEnglish.Sites.Models;
    using BusinessEnglish.Models;
    using System.Collections.Generic;
    using System;

    public class HomeController : Controller
    {
        private TopicService topicService;
        private EnglishDbContext db = new EnglishDbContext();

        public HomeController()
        {
            topicService = new TopicService();
        }

        public ActionResult Index()
        {
            return View(new BaseViewModel
            {
                Topics = GetAllTopics()
            });
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

        public ActionResult Search(string searchString)
        {
            var searchDataResult = new SearchViewModel
            {
                ResultLength = 69,
                SearchString = searchString,
                SearchType = ""
            };
            var topics = GetAllTopics();

            if (!String.IsNullOrEmpty(searchString))
            {
                // topics = topics.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View(new BaseViewModel
            {
                Topics = topics,
                CurrentSearch = searchDataResult
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