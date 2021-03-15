namespace Centric_Project_rc744716.Migrations.CentricContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Centric_Project_rc744716.DAL.CentricContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\CentricContext";
            ContextKey = "Centric_Project_rc744716.DAL.CentricContext";
        }

        protected override void Seed(Centric_Project_rc744716.DAL.CentricContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
