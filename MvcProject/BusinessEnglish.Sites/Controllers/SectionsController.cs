namespace BusinessEnglish.Sites.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using BusinessEnglish.Models;
    using Services;

    public class SectionsController : Controller
    {
        private SectionService sectionService;
        private TopicService topicService;
        private EnglishDbContext db = new EnglishDbContext();

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

            //   ViewBag.TopicId = new SelectList(topicService.GetAll(), "Id", "Name", section.TopicId);
            return View(section);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "Name", section.TopicId);
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TopicId")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "Name", section.TopicId);
            return View(section);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = db.Sections.Find(id);
            db.Sections.Remove(section);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}