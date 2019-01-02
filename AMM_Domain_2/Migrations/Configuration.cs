namespace AMM_Domain_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AMM_Domain_2.Model.AMMContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AMM_Domain_2.Model.AMMContainer";
        }

        protected override void Seed(AMM_Domain_2.Model.AMMContainer context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
