using System;
using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System.Linq;
namespace ConsoleApplication
{
    class Program
    {
        private static void insertNinjaWithEquipement()
        {
            using (var context = new NinjaContext())
            {
                var ninja = new Ninja
                {
                    clanId = 1,
                    served = false,
                    dateOfBirth = new DateTime(1988, 09, 09),
                    name = "Sirine"

                };

                var muscle = new NinjaEquipement
                {
                    name = "muscle",
                    type = EquipementType.Tool
                };

                var sword = new NinjaEquipement
                {
                    name = "sword",
                    type = EquipementType.Outware
                };
                context.ninjas.Add(ninja);
                ninja.equipementOwned.Add(muscle);
                ninja.equipementOwned.Add(sword);
            }

            
        }
        private static void DeleteNinja()
        {
            using( var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.ninjas.FirstOrDefault();
                context.ninjas.Remove(ninja);
                context.SaveChanges();
            }
           

        }
        private static void queryAndUpdateNinja()
        {
            using(var context =  new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.ninjas.FirstOrDefault();
                ninja.served = !ninja.served;
                context.Entry(ninja).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        private static void simpleNinjaQueries()
        {   using (var context = new NinjaContext())
            {
                var ninjas = context.ninjas;

                foreach( var ninja in ninjas)
                {
                    Console.WriteLine(ninja.name);
                }

                var oneNinja = context.ninjas.Find(5);

               
                Console.WriteLine(oneNinja.name);
                
            }
            
        }
        private static void insertNinja()
        {
            var ninja = new Ninja
            {
                clanId = 1,
                served = false,
                dateOfBirth = new DateTime(1988, 09, 09),
                name = "Abderrahmane"

            };

            using (var context =  new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.ninjas.Add(ninja);
                context.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            insertNinja();
            simpleNinjaQueries();
            queryAndUpdateNinja();
            DeleteNinja();
            insertNinjaWithEquipement();
        }
    }
}
