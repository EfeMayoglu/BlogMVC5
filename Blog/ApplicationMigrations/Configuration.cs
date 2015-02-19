namespace Blog.ApplicationMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"ApplicationMigrations";
        }

        protected override void Seed(Blog.Models.ApplicationDbContext context)
        {
            
        }
    }
}
