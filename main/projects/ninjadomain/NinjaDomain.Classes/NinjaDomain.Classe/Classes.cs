
using System;
using System.Collections.Generic;


namespace NinjaDomain.Classes
{


    public class Ninja : IModificationHistory
    {
        public Ninja()
        {
            equipementOwned = new List<NinjaEquipement>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public bool served { get; set; }
        public Clan clan { get; set; }
        public int clanId { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public List<NinjaEquipement> equipementOwned { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }

    public class Clan : IModificationHistory
    {
        public int id { get; set; }
        public string clanName { get; set; }
        public List<Ninja> Ninjas { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }

    public class NinjaEquipement : IModificationHistory
    {
        public int id { get; set; }
        public string name { get; set; }

        public EquipementType type { get; set; }
        public Ninja ninja { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }


}
