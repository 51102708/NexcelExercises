namespace BusinessEnglish.Sites.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using BusinessEnglish.Models;
    using Services;

    public class SectionsController : Controller
    {
        private SectionService sectionService;
        private TopicService topicService;

        public SectionsController()
        {
            sectionService = new SectionService();
            topicService = new TopicService();
        }

        public ActionResult Index(string searchString, int? topicId)
        {
            var sections = sectionService.GetAll();

            if (!topicId.Equals(null))
            {
                sections = sectionService.FilterSectionsByTopicId(sections, (int)topicId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                sections = sectionService.FilterSectionsWithName(sections, searchString);
            }
            ViewBag.TopicId = new SelectList(topicService.GetAll(), "Id", "Name");

            return View(sections.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var section = sectionService.Get((int)id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TopicId")] Section section)
        {
            if (ModelState.IsValid)
            {
                sectionService.Create(section);
                return RedirectToAction("Index");
            }
            return View(section);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var section = sectionService.Get((int)id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicId = new SelectList(topicService.GetAll(), "Id", "Name", section.TopicId);
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TopicId")] Section section)
        {
            if (ModelState.IsValid)
            {
                sectionService.Update(section);
                return RedirectToAction("Index");
            }
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            sectionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}