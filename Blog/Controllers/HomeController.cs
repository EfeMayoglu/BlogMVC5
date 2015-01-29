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
        
        public ActionResult Index(int? page)
        {
           
            var entries = from s in db.BlogEntries select s;
            entries = entries.OrderByDescending(s => s.EntryDate);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            try
            {
                return View(entries.ToPagedList(pageNumber, pageSize));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
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