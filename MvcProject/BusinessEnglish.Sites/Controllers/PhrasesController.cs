namespace BusinessEnglish.Sites.Controllers
{
    using Filters;
    using Services;
    using Services.Models;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Phrases;

    [BasicAuthentication(Roles = "1")]
    public class PhrasesController : Controller
    {
        private readonly SectionService sectionService;
        private readonly PhraseService phraseService;

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

            return View(new IndexViewModel
            {
                Phrases = phrases,
                Sections = new SelectList(sectionService.GetAll(), "Id", "Name")
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Example,SectionId")] CreateViewModel phrase)
        {
            if (ModelState.IsValid)
            {
                phraseService.Create(new Phrase
                {
                    Name = phrase.Name,
                    Example = phrase.Example,
                    SectionId = phrase.SectionId
                });

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

            return View(new EditViewModel
            {
                Id = phrase.Id,
                Name = phrase.Name,
                Example = phrase.Example,
                SectionId = phrase.SectionId,
                Sections = new SelectList(sectionService.GetAll(), "Id", "Name", phrase.SectionId)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Example,SectionId")] EditViewModel phrase)
        {
            if (ModelState.IsValid)
            {
                phraseService.Update(new Phrase
                {
                    Id = phrase.Id,
                    Name = phrase.Name,
                    Example = phrase.Example,
                    SectionId = phrase.SectionId
                });

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