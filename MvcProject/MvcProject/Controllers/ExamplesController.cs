using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class ExamplesController : Controller
    {
        private EnglishDbContext db = new EnglishDbContext();

        // GET: Examples
        public ActionResult Index()
        {
            var examples = db.Examples.Include(e => e.Pharse);
            return View(examples.ToList());
        }

        // GET: Examples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // GET: Examples/Create
        public ActionResult Create()
        {
            ViewBag.PharseId = new SelectList(db.Pharses, "Id", "Name");
            return View();
        }

        // POST: Examples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,PharseId")] Example example)
        {
            if (ModelState.IsValid)
            {
                db.Examples.Add(example);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PharseId = new SelectList(db.Pharses, "Id", "Name", example.PharseId);
            return View(example);
        }

        // GET: Examples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            ViewBag.PharseId = new SelectList(db.Pharses, "Id", "Name", example.PharseId);
            return View(example);
        }

        // POST: Examples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,PharseId")] Example example)
        {
            if (ModelState.IsValid)
            {
                db.Entry(example).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PharseId = new SelectList(db.Pharses, "Id", "Name", example.PharseId);
            return View(example);
        }

        // GET: Examples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: Examples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Example example = db.Examples.Find(id);
            db.Examples.Remove(example);
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
