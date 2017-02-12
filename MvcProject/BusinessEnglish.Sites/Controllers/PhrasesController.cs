namespace BusinessEnglish.Sites.Controllers
{
    using BusinessEnglish.Models;
    using Filters;
    using Services;
    using System.Net;
    using System.Web.Mvc;

    [BasicAuthentication(Roles = "1")]
    public class PhrasesController : Controller
    {
        private SectionService sectionService;
        private PhraseService phraseService;

        public PhrasesController()
        {
            sectionService = new SectionService();
            phraseService = new PhraseService();
        }

        public ActionResult Index(string searchString, int? sectionId)
        {
            var phrases = phraseService.GetAll();

            if (!sectionId.Equals(null))
            {
                phrases = phraseService.FilterPhrasesBySectionId(phrases, (int)sectionId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                phrases = phraseService.FilterPhrasesWithName(phrases, searchString);
            }

            ViewBag.SectionId = new SelectList(sectionService.GetAll(), "Id", "Name");

            return View(phrases);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Example,SectionId")] Phrase phrase)
        {
            if (ModelState.IsValid)
            {
                phraseService.Create(phrase);

                return RedirectToAction("Index");
            }

            return View(phrase);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var phrase = phraseService.Get((int)id);

            if (phrase == null)
            {
                return HttpNotFound();
            }

            ViewBag.SectionId = new SelectList(sectionService.GetAll(), "Id", "Name", phrase.SectionId);

            return View(phrase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Example,SectionId")] Phrase phrase)
        {
            if (ModelState.IsValid)
            {
                phraseService.Update(phrase);

                return RedirectToAction("Index");
            }

            return View(phrase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            phraseService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}