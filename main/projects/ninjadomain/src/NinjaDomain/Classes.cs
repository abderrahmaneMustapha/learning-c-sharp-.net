using System;

namespace NinjaDomain
{
    public class Ninja
    {
        public int id {get; set;}
        public string name {get; set;}
        public bool served {get; set;}
        public Clan clan {get; set;}
        public int clanId {get; set;}
        public List<NinjaEquipement> equipementOwned {get; set;}

    }

    public class Clan
    {
        public int id {get; set;}
        public string clanName {get; set;}
        public List<Ninja> Ninjas {get; set;}
    }

    public class NinjaEquipement 
    {
           public int id {get; set;}
        public string name {get; set;}

        public EquipementType type {get; set;}
        public Ninja ninja {get; set;}
    }
}
