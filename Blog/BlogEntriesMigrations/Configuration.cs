namespace Blog.BlogEntriesMigrations
{
    using Blog.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Blog.DatabaseContext;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.DatabaseContext.BlogEntriesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"BlogEntriesMigrations";
            ContextKey = "Blog.DatabaseContext.BlogEntriesDbContext";
        }

        protected override void Seed(Blog.DatabaseContext.BlogEntriesDbContext context)
        {
            List<BlogEntry> blogList = new List<BlogEntry>() 
            {
                new BlogEntry { Entry="Entry", EntryDate=DateTime.Now, Id=1, Title="Title", UserName="Seed"}
            };
        }
    }
}
