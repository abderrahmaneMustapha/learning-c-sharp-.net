using NinjaDomain.Classes;
using System;
using System.Data.Entity;
using System.Linq;

namespace NinjaDomain.DataModel
{
    public class NinjaContext : DbContext
    {
        public DbSet<Ninja> ninjas { get; set; }
        public DbSet<Clan> clans { get; set; }
        public DbSet<NinjaEquipement> equipements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory &&
                (e.State == EntityState.Added || e.State == EntityState.Modified
            )).Select(e => e.Entity as IModificationHistory)
                )
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }
            int result = base.SaveChanges();
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory).Select(e => e.Entity as IModificationHistory))
            {
                history.IsDirty = false;
            }
            return result;
        }
    }
}
