namespace BusinessEnglish.Sites.Controllers
{
    using BusinessEnglish.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    public class PharsesController : Controller
    {
        private EnglishDbContext db = new EnglishDbContext();

        // GET: Pharses
        public ActionResult Index(string searchString, int? sectionId)
        {
            var pharses = db.Pharses.Include(p => p.Section).OrderBy(x => x.Section.Name).ToList();

            if (!sectionId.Equals(null))
            {
                pharses = pharses.Where(s => s.SectionId == sectionId).ToList();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                pharses = pharses.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name");

            return View(pharses.ToList());
        }

        // GET: Pharses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharse pharse = db.Pharses.Find(id);
            if (pharse == null)
            {
                return HttpNotFound();
            }
            return View(pharse);
        }

        // GET: Pharses/Create
        public ActionResult Create()
        {
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Example,SectionId")] Pharse pharse)
        {
            if (ModelState.IsValid)
            {
                db.Pharses.Add(pharse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", pharse.SectionId);
            return View(pharse);
        }

        // GET: Pharses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharse pharse = db.Pharses.Find(id);
            if (pharse == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", pharse.SectionId);
            return View(pharse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Example,SectionId")] Pharse pharse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", pharse.SectionId);
            return View(pharse);
        }

        // GET: Pharses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharse pharse = db.Pharses.Find(id);
            if (pharse == null)
            {
                return HttpNotFound();
            }
            return View(pharse);
        }

        // POST: Pharses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pharse pharse = db.Pharses.Find(id);
            db.Pharses.Remove(pharse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}