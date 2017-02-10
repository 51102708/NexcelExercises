namespace BusinessEnglish.Sites.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Web.Mvc;
    using BusinessEnglish.Models;
    using Services;
    using System.Collections.Generic;

    public class TopicsController : Controller
    {
        private TopicService topicService;
        private EnglishDbContext db = new EnglishDbContext();

        public TopicsController()
        {
            topicService = new TopicService();
        }

        public ActionResult Index(string searchString)
        {
            var topics = (IEnumerable<Topic>)topicService.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                topics = (IEnumerable<Topic>)topicService.FilterTopicsWithName(topics, searchString);
            }
            return View(topics);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}