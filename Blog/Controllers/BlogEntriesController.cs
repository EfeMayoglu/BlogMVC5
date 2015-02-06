using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.Service;

namespace Blog.Controllers
{
    public class BlogEntriesController : Controller
    {
        IBlogEntryService blogEntryService;

        public BlogEntriesController(IBlogEntryService BlogEntryService)
        {
            blogEntryService = BlogEntryService;
        }

        // GET: BlogEntries
        public ActionResult Index()
        {
            return View(blogEntryService.SelectAll());
        }

        // GET: BlogEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = blogEntryService.GetById(id);
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
        public ActionResult Create(BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                blogEntryService.Create(blogEntry);
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
            BlogEntry blogEntry = blogEntryService.GetById(id);
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
        public ActionResult HttpPostEdit(BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                blogEntryService.Update(blogEntry);
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
            BlogEntry blogEntry = blogEntryService.GetById(id);
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
            BlogEntry blogEntry = blogEntryService.GetById(id);
            blogEntryService.Delete(blogEntry);
            return RedirectToAction("Index");
        }
    }
}
