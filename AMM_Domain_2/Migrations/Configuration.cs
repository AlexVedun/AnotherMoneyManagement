namespace AMM_Domain_2.Migrations
{
    using AMM_Domain_2.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AMM_Domain_2.Model.AMMContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AMM_Domain_2.Model.AMMContainer";
        }

        protected override void Seed(AMM_Domain_2.Model.AMMContainer context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.TypeOfSourceSet.Any())
            {
                context.TypeOfSourceSet.Add(new TypeOfSource { Id = 1, Name = "Доходы" });
                context.TypeOfSourceSet.Add(new TypeOfSource { Id = 2, Name = "Расходы" });
                context.TypeOfSourceSet.Add(new TypeOfSource { Id = 3, Name = "Кошелек" });
                context.TypeOfSourceSet.Add(new TypeOfSource { Id = 4, Name = "Карта" });

                context.SaveChanges();
            }            
        }
    }
}
