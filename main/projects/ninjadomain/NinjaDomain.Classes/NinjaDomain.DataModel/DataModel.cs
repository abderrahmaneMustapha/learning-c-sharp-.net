using System.Data.Entity;
using NinjaDomain.Classes;

namespace NinjaDomain.DataModel
{
    public class NinjaContext : DbContext
    {
        public DbSet<Ninja> ninjas { get; set; }
        public DbSet<Clan> clans { get; set; }
        public DbSet<NinjaEquipement> equipements { get; set; }
    }
}
