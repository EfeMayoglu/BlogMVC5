using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace Blog.Models
{
    public class BlogEntry
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        [StringLength(50), Required(ErrorMessage = "Title required")]
        public string Title { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml, StringLength(10000, ErrorMessage = "Text cannot be longer than 10000 characters")]
        public string Entry { get; set; }

        [Display(Name = "Add date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
    }

    public class BlogEntriesDbContext : DbContext
    {
        public DbSet<BlogEntry> BlogEntries { get; set; }
    }
}