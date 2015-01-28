using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private BlogEntriesDbContext db = new BlogEntriesDbContext();
        
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var entries = from s in db.BlogEntries select s;
            entries = entries.OrderByDescending(s => s.EntryDate);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(entries.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");

            
        }
    }
}