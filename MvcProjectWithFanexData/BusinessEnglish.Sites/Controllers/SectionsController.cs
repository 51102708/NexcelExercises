namespace BusinessEnglish.Sites.Controllers
{
    using Filters;
    using Services;
    using Services.Models;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Sections;

    [BasicAuthentication(Roles = "1")]
    public class SectionsController : Controller
    {
        private readonly SectionService sectionService;
        private readonly TopicService topicService;

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

            return View(new IndexViewModel
            {
                Sections = sections,
                Topics = new SelectList(topicService.GetAll(), "Id", "Name")
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,TopicId")] CreateViewModel section)
        {
            if (ModelState.IsValid)
            {
                sectionService.Create(new Section
                {
                    Name = section.Name,
                    TopicId = section.TopicId
                });

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

            return View(new EditViewModel
            {
                Id = section.Id,
                Name = section.Name,
                TopicId = section.TopicId,
                Topics = new SelectList(topicService.GetAll(), "Id", "Name", section.TopicId)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TopicId")] EditViewModel section)
        {
            if (ModelState.IsValid)
            {
                sectionService.Update(new Section
                {
                    Id = section.Id,
                    Name = section.Name,
                    TopicId = section.TopicId
                });

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