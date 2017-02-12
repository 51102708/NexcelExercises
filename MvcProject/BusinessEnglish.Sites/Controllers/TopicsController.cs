namespace BusinessEnglish.Sites.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using BusinessEnglish.Models;
    using Services;

    public class TopicsController : Controller
    {
        private TopicService topicService;

        public TopicsController()
        {
            topicService = new TopicService();
        }

        public ActionResult Index(string searchString)
        {
            var topics = topicService.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                topics = topicService.FilterTopicsWithName(topics, searchString);
            }

            return View(topics);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                topicService.Create(topic);
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var topic = topicService.Get((int)id);

            if (topic == null)
            {
                return HttpNotFound();
            }

            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                topicService.Update(topic);

                return RedirectToAction("Index");
            }

            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            topicService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}