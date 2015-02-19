using Blog.DatabaseContext;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ShowEntryController : Controller
    {
        private BlogEntriesDbContext db = new BlogEntriesDbContext();

        // GET: ShowEntry
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(blogEntry);
        }
    }
}