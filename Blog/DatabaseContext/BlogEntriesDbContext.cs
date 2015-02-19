using Blog.DatabaseContext;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Blog.DatabaseContext
{
    public class BlogEntriesDbContext : DbContext, IDbContext
    {
        public BlogEntriesDbContext()
       {
       }

        public IDbSet<BlogEntry> BlogEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}