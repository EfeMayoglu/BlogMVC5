using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogEntriesController : Controller
    {
        private BlogEntriesDbContext db = new BlogEntriesDbContext();
        private RegisterViewModel reg = new RegisterViewModel();

        // GET: BlogEntries
        public ActionResult Index()
        {
            return View(db.BlogEntries.ToList());
        }

        // GET: BlogEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Entry")] BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                blogEntry.UserName = User.Identity.Name;
                blogEntry.EntryDate = System.DateTime.Now;
                db.BlogEntries.Add(blogEntry);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(blogEntry);
        }

        // GET: BlogEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Title,Entry,EntryDate")] BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            db.BlogEntries.Remove(blogEntry);
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
