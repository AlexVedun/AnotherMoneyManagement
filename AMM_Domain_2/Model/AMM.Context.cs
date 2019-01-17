using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Domain_2.Model
{
    public partial class AMMContainer : DbContext
    {
        public AMMContainer() : base("name=AMMContainer")
        {
            Database.SetInitializer<AMMContainer>(new FirstInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<Transaction> TransactionSet { get; set; }
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<Family> FamilySet { get; set; }
        public virtual DbSet<Source> SourceSet { get; set; }
        //public virtual DbSet<TypeOfSource> TypeOfSourceSet { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogSet { get; set; }       
    }

    public class FirstInitializer : DropCreateDatabaseIfModelChanges<AMMContainer>
    {
        // В этом методе можно заполнить таблицу по умолчанию
        protected override void Seed(AMMContainer context)
        {
            //context.TypeOfSourceSet.Add(new TypeOfSource { Id = 1, Name = "Доходы" });
            //context.TypeOfSourceSet.Add(new TypeOfSource { Id = 2, Name = "Расходы" });
            //context.TypeOfSourceSet.Add(new TypeOfSource { Id = 3, Name = "Кошелек" });
            //context.TypeOfSourceSet.Add(new TypeOfSource { Id = 4, Name = "Карта" });

            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}
