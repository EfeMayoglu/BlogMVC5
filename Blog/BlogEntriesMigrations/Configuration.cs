namespace Blog.BlogEntriesMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.BlogEntriesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"BlogEntriesMigrations";
            ContextKey = "Blog.Models.BlogEntriesDbContext";
        }

        protected override void Seed(Blog.Models.BlogEntriesDbContext context)
        {
            
        }
    }
}
