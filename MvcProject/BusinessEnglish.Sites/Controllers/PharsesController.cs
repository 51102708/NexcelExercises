namespace BusinessEnglish.Sites.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using BusinessEnglish.Models;
    using Services;

    public class PharsesController : Controller
    {
        private SectionService sectionService;
        private PharseService pharseService;

        public PharsesController()
        {
            sectionService = new SectionService();
            pharseService = new PharseService();
        }

        public ActionResult Index(string searchString, int? sectionId)
        {
            var pharses = pharseService.GetAll();

            if (!sectionId.Equals(null))
            {
                pharses = pharseService.FilterPharsesBySectionId(pharses, (int)sectionId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                pharses = pharseService.FilterPharsesWithName(pharses, searchString);
            }

            ViewBag.SectionId = new SelectList(sectionService.GetAll(), "Id", "Name");

            return View(pharses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Example,SectionId")] Pharse pharse)
        {
            if (ModelState.IsValid)
            {
                pharseService.Create(pharse);

                return RedirectToAction("Index");
            }

            return View(pharse);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pharse = pharseService.Get((int)id);

            if (pharse == null)
            {
                return HttpNotFound();
            }

            ViewBag.SectionId = new SelectList(sectionService.GetAll(), "Id", "Name", pharse.SectionId);

            return View(pharse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Example,SectionId")] Pharse pharse)
        {
            if (ModelState.IsValid)
            {
                pharseService.Update(pharse);

                return RedirectToAction("Index");
            }

            return View(pharse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            pharseService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}