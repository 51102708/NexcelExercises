namespace MvcProject.Controllers
{
    using System.Linq;
    using System.Data;
    using System.Web.Mvc;
    using BusinessEnglish.Services;
    using BusinessEnglish.Sites.Models;

    public class HomeController : Controller
    {
        private TopicService topicService;

        public HomeController()
        {
            topicService = new TopicService();
        }

        public ActionResult Index()
        {
            return View(new BaseViewModel
            {
                Topics = topicService.GetAllTopics()
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
    }
}