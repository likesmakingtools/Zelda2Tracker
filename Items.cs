using System.Numerics;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Zelda2Tracker
{
    public enum Requirements
    {
        // Items
        None,
        Candle,
        Glove,
        Raft,
        Boots,
        Flute,
        Cross,
        Hammer,
        Bracelet,
        FairyItem,
        AllKey,
        Book,
        Letter,
        Mirror,
        Trophy,
        Flower,
        Kid,
        Slimes,
        P1Key,
        P2Key,
        P3Key,
        P4Key,
        P5Key,
        P6Key,
        // Spells
        Protect,
        Jump,
        Heal,
        FairySpell,
        Fire,
        Reflect,
        Enigma,
        Thunder,
        // Actions
        Downthrust,
        Upthrust,
        // Other
        PalaceGems,
        Uncollectible
    }

    public class MyStuff
    {
        //private readonly int[] ProtectCosts = { 0, 32, 24, 24, 16, 16, 16, 16, 16, 12 };
        //private readonly int[] JumpCosts = { 0, 48, 40, 32, 32, 20, 16, 12, 8, 6 };
        //private readonly int[] HealCosts = { 0, 70, 70, 60, 60, 50, 50, 50, 50, 40 };
        //private readonly int[] FairyCosts = { 0, 80, 80, 60, 60, 40, 40, 40, 40, 30 };
        //private readonly int[] FireCosts = { 0, 120, 80, 60, 30, 16, 16, 16, 16, 12 };
        //private readonly int[] ReflectCosts = { 0, 120, 120, 80, 48, 40, 32, 24, 16, 12 };
        //private readonly int[] EnigmaCosts = { 0, 120, 112, 96, 80, 48, 32, 24, 16, 12 };
        //private readonly int[] ThunderCosts = { 0, 120, 120, 120, 120, 120, 120, 100, 64, 48 };

        private readonly int HeartMax = 18;
        private readonly int MagicMax = 18;
        private readonly int LifeMax = 4;
        private readonly int SlimeMax = 12;
        private readonly int P1KeysMax = 3;
        private readonly int P2KeysMax = 4;
        private readonly int P3KeysMax = 4;
        private readonly int P4KeysMax = 6;
        private readonly int P5KeysMax = 5;
        private readonly int P6KeysMax = 6;
        //[JsonInclude]
        private int _hearts;
        private int _magic;
        private int _lives;
        private int _slimes;
        private int _p1Keys;
        private int _p2Keys;
        private int _p3Keys;
        private int _p4Keys;
        private int _p5Keys;
        private int _p6Keys;

        public int Hearts { get { return _hearts; } set { _hearts = (value >= HeartMax) ? HeartMax : (value <= 0) ? 0 : value; }}
        public int Magic { get { return _magic; } set { _magic = (value >= MagicMax) ? MagicMax : (value <= 0) ? 0 : value; } }
        public int Lives { get { return _lives; } set { _lives = (value >= LifeMax) ? LifeMax : (value <= 0) ? 0 : value; } }
        public int Slimes { get { return _slimes; } set { _slimes = (value >= SlimeMax) ? SlimeMax : (value <= 0) ? 0 : value; } }
        public int P1Keys { get { return _p1Keys; } set { _p1Keys = (value >= P1KeysMax) ? P1KeysMax : (value <= 0) ? 0 : value; } }
        public int P2Keys { get { return _p2Keys; } set { _p2Keys = (value >= P2KeysMax) ? P2KeysMax : (value <= 0) ? 0 : value; } }
        public int P3Keys { get { return _p3Keys; } set { _p3Keys = (value >= P3KeysMax) ? P3KeysMax : (value <= 0) ? 0 : value; } }
        public int P4Keys { get { return _p4Keys; } set { _p4Keys = (value >= P4KeysMax) ? P4KeysMax : (value <= 0) ? 0 : value; } }
        public int P5Keys { get { return _p5Keys; } set { _p5Keys = (value >= P5KeysMax) ? P5KeysMax : (value <= 0) ? 0 : value; } }
        public int P6Keys { get { return _p6Keys; } set { _p6Keys = (value >= P6KeysMax) ? P6KeysMax : (value <= 0) ? 0 : value; } }

        // Progression Items
        public bool Candle { get; set; }
        public bool Glove { get; set; }
        public bool Raft { get; set; }
        public bool Boots { get; set; }
        public bool Flute { get; set; }
        public bool Cross { get; set; }
        public bool Hammer { get; set; }
        public bool Bracelet { get; set; }
        public bool FairyItem { get; set; }
        public bool AKey { get; set; }
        public bool Book { get; set; }
        public bool Letter { get; set; }
        public bool Mirror { get; set; }
        public bool Trophy { get; set; }
        public bool Flower { get; set; }
        public bool Kid { get; set; }

        // Spells
        public bool Protect { get; set; }
        public bool Jump { get; set; }
        public bool Heal { get; set; }
        public bool FairySpell { get; set; }
        public bool Fire { get; set; }
        public bool Reflect { get; set; }
        public bool Enigma { get; set; }
        public bool Thunder { get; set; }

        // Other Items
        public bool Meat { get; set; }
        public bool Shield { get; set; }
        public bool Ring { get; set; }
        public bool Amulet { get; set; }
        public bool Sword { get; set; }
        //public bool Blood { get; set; }
        public bool Map1 { get; set; }
        public bool Map2 { get; set; }

        // Skills
        public bool Downthrust { get; set; }
        public bool Upthrust { get; set; }

        // Palace Gems
        public bool P1Gem { get; set; }
        public bool P2Gem { get; set; }
        public bool P3Gem { get; set; }
        public bool P4Gem { get; set; }
        public bool P5Gem { get; set; }
        public bool P6Gem { get; set; }

        public MyStuff()
        {
            Hearts = 0;
            Magic = 0;
            Lives = 0;
            Slimes = 0;
            P1Keys = 0;
            P2Keys = 0;
            P3Keys = 0;
            P4Keys = 0;
            P5Keys = 0;
            P6Keys = 0;

            Candle = false;
            Glove = false;
            Raft = false;
            Boots = false;
            Flute = false;
            Cross = false;
            Hammer = false;
            Bracelet = false;
            FairyItem = false;
            AKey = false;
            Book = false;
            Letter = false;
            Mirror = false;
            Trophy = false;
            Flower = false;
            Kid = false;
            Protect = false;
            Jump = false;
            Heal = false;
            FairySpell = false;
            Fire = false;
            Reflect = false;
            Enigma = false;
            Thunder = false;
            Meat = false;
            Shield = false;
            Ring = false;
            Amulet = false;
            Sword = false;
            //Blood = false;
            Map1 = false;
            Map2 = false;
            Downthrust = false;
            Upthrust = false;
            P1Gem = false;
            P2Gem = false;
            P3Gem = false;
            P4Gem = false;
            P5Gem = false;
            P6Gem = false;    
        }
        
        public int GetPalaceGems()
        {
            int palaceGems = 0;

            if (P1Gem) palaceGems++;
            if (P2Gem) palaceGems++;
            if (P3Gem) palaceGems++;
            if (P4Gem) palaceGems++;
            if (P5Gem) palaceGems++;
            if (P6Gem) palaceGems++;

            return palaceGems;
        }
    }

    class Collectible
    {
        private int requirementSets = 0;
        private string lastException = string.Empty;

        public string ID = string.Empty;
        public string Name = string.Empty;
        public int X = 0;
        public int Y = 0;
        public bool isCollected = false;
        public bool canCollect = false;
        public bool inGroup = false;
        public string GroupID = string.Empty;
        public string GroupName = string.Empty;
        public bool inPalace = false;
        public string PalaceID = string.Empty;
        public string PalaceName = string.Empty;

        // Requirments
        public List<Dictionary<Requirements, int>> CollectRequirements = new List<Dictionary<Requirements, int>>();

        public Collectible(string name, int x, int y)
        {
            Name = name;
            ID = name.Replace(" ", "");
            X = x;
            Y = y;
        }

        public Collectible(string name, int x, int y, string group, bool isPalace)
        {
            Name = name;
            ID = name.Replace(" ", "");
            X = x;
            Y = y;

            if (isPalace)
            {
                PalaceName = group;
                PalaceID = group.Replace(" ", "");
                inPalace = true;
            }
            else
            {
                GroupName = group;
                GroupID = group.Replace(" ", "");
                inGroup = true;
            }
        }

        public void SetGroup(string name)
        {
            GroupName = name;
            GroupID = name.Replace(" ", "");
            inGroup = true;
        }

        public void SetPalace(string palace)
        {
            PalaceName = palace;
            PalaceID = palace.Replace(" ", "");
            inPalace = true;
        }

        public void AddRequirementSet(List<Requirements> reqs, List<int> quantities)
        {
            if (reqs.Count != quantities.Count) return;

            Dictionary<Requirements, int> requirements = new Dictionary<Requirements, int>();

            for (int i = 0; i < reqs.Count; i++)
            {
                try
                {
                    requirements.Add(reqs[i], quantities[i]);
                }
                catch (Exception e)
                {
                    lastException = e.Message;
                }
            }

            requirementSets++;
            CollectRequirements.Add(requirements);
        }

        public string GetTooltip()
        {
            string tooltip = $"{Name}\n";
            tooltip += (isCollected) ? "Collected" : "Not Collected";

            return tooltip;
        }

        public void UpdateCollectibility(ref MyStuff collection)
        {
            canCollect = false;
            bool meetsRequirement = false;

            foreach (Dictionary<Requirements, int> requirements in CollectRequirements)
            {
                foreach (KeyValuePair<Requirements, int> requirement in requirements)
                {
                    meetsRequirement = CheckRequirement(requirement.Key, requirement.Value, ref collection);
                    if (!meetsRequirement) break;
                }
                if (meetsRequirement)
                {
                    canCollect = true;
                    break;
                }
            }
        }

        private bool CheckRequirement(Requirements requirement, int amount, ref MyStuff collection)
        {
            bool meetsRequirement = false;

            switch(requirement)
            {
                case Requirements.None: meetsRequirement = true; break;
                case Requirements.Candle: meetsRequirement = collection.Candle; break;
                case Requirements.Glove: meetsRequirement = collection.Glove; break;
                case Requirements.Raft: meetsRequirement = collection.Raft; break;
                case Requirements.Boots: meetsRequirement = collection.Boots; break;
                case Requirements.Flute: meetsRequirement = collection.Flute; break;
                case Requirements.Cross: meetsRequirement = collection.Cross; break;
                case Requirements.Hammer: meetsRequirement = collection.Hammer; break;
                case Requirements.Bracelet: meetsRequirement = collection.Bracelet; break;
                case Requirements.FairyItem: meetsRequirement = collection.FairyItem; break;
                case Requirements.AllKey: meetsRequirement = collection.AKey; break;
                case Requirements.Book: meetsRequirement = collection.Book; break;
                case Requirements.Letter: meetsRequirement = collection.Letter; break;
                case Requirements.Mirror: meetsRequirement = collection.Mirror; break;
                case Requirements.Trophy: meetsRequirement = collection.Trophy; break;
                case Requirements.Flower: meetsRequirement = collection.Flower; break;
                case Requirements.Kid: meetsRequirement = collection.Kid; break;
                case Requirements.Slimes: meetsRequirement = (collection.Slimes >= amount); break;
                case Requirements.P1Key: meetsRequirement = (collection.P1Keys >= amount || collection.AKey); break;
                case Requirements.P2Key: meetsRequirement = (collection.P2Keys >= amount || collection.AKey); break;
                case Requirements.P3Key: meetsRequirement = (collection.P3Keys >= amount || collection.AKey); break;
                case Requirements.P4Key: meetsRequirement = (collection.P4Keys >= amount || collection.AKey); break;
                case Requirements.P5Key: meetsRequirement = (collection.P5Keys >= amount || collection.AKey); break;
                case Requirements.P6Key: meetsRequirement = (collection.P6Keys >= amount || collection.AKey); break;
                case Requirements.Protect: meetsRequirement = collection.Protect; break;
                case Requirements.Jump: meetsRequirement = collection.Jump; break;
                case Requirements.Heal: meetsRequirement = collection.Heal; break;
                case Requirements.FairySpell: meetsRequirement = collection.FairySpell; break;
                case Requirements.Fire: meetsRequirement = collection.Fire; break;
                case Requirements.Reflect: meetsRequirement = collection.Reflect; break;
                case Requirements.Enigma: meetsRequirement = collection.Enigma; break;
                case Requirements.Thunder: meetsRequirement = collection.Thunder; break;
                case Requirements.Downthrust: meetsRequirement = collection.Downthrust; break;
                case Requirements.Upthrust: meetsRequirement = collection.Upthrust; break;
                case Requirements.PalaceGems: meetsRequirement = (collection.GetPalaceGems() >= amount); break;
                default: break;
            }

            return meetsRequirement;
        }

        public bool IsUncollectible()
        {
            bool isUncollectible = false;

            foreach (Dictionary<Requirements, int> requirements in CollectRequirements)
            {
                foreach (KeyValuePair<Requirements, int> requirement in requirements)
                {
                    if (requirement.Key == Requirements.Uncollectible)
                    {
                        isUncollectible = true;
                        break;
                    }
                }
                if (isUncollectible)
                {
                    break;
                }
            }

            return isUncollectible;
        }
    }

    class CollectibleList
    {
        private string exceptions = string.Empty;

        public List<Collectible> MapCollectibles; // Map Ellipses Created from this
        public List<Collectible> Palace01Collectibles;
        public List<Collectible> Palace02Collectibles;
        public List<Collectible> Palace03Collectibles;
        public List<Collectible> Palace04Collectibles;
        public List<Collectible> Palace05Collectibles;
        public List<Collectible> Palace06Collectibles;
        public List<Collectible> Palace07Collectibles;
        public List<Collectible> GroupCollectibles;

        public CollectibleList()
        {
            MapCollectibles = GenerateMapCollectibles();
            Palace01Collectibles = GeneratePalaceCollectibles(1);
            Palace02Collectibles = GeneratePalaceCollectibles(2);
            Palace03Collectibles = GeneratePalaceCollectibles(3);
            Palace04Collectibles = GeneratePalaceCollectibles(4);
            Palace05Collectibles = GeneratePalaceCollectibles(5);
            Palace06Collectibles = GeneratePalaceCollectibles(6);
            Palace07Collectibles = GeneratePalaceCollectibles(7);
            GroupCollectibles = GenerateGroupedCollectibles();
        }

        private List<Collectible> GenerateMapCollectibles()
        {
            List<Collectible> items = new List<Collectible>
            {
                // Create every collectible on the map here
                // Grouped collectible locations
                GenerateCollectible("Lake Ruin", "Lake Ruin", false, 48, 78, new string[] { "Uncollectible" }),
                GenerateCollectible("Hyrule Castle", "Hyrule Castle", false, 48, 83, new string[] { "Uncollectible" }),
                GenerateCollectible("Ruto", "Ruto", false, 27, 67, new string[] { "Uncollectible" }),
                GenerateCollectible("Ruto Mountain", "Ruto Mountain", false, 28, 51, new string[] { "Uncollectible" }),
                GenerateCollectible("Saria", "Saria", false, 33, 120, new string[] { "Uncollectible" }),
                GenerateCollectible("Mido", "Mido", false, 85, 106, new string[] { "Uncollectible" }),
                GenerateCollectible("Nabooru", "Nabooru", false, 130, 116, new string[] { "Uncollectible" }),
                GenerateCollectible("Darunia", "Darunia", false, 110, 89, new string[] { "Uncollectible" }),
                GenerateCollectible("New Kasuto", "New Kasuto", false, 169, 141, new string[] { "Uncollectible" }),
                GenerateCollectible("Old Kasuto", "Old Kasuto", false, 141, 155, new string[] { "Uncollectible" }),
                GenerateCollectible("Hammer Cave", "Hammer Cave", false, 37, 166, new string[] { "Uncollectible" }),
                GenerateCollectible("Parapa Palace", "Parapa Palace", true, 85, 52, new string[] { "Uncollectible" }),
                GenerateCollectible("Midoro Palace", "Midoro Palace", true, 37, 95, new string[] { "Uncollectible" }),
                GenerateCollectible("Island Palace", "Island Palace", true, 82, 129, new string[] { "Uncollectible" }),
                GenerateCollectible("Maze Island Palace", "Maze Island Palace", true, 199, 87, new string[] { "Uncollectible" }),
                GenerateCollectible("Palace On The Sea", "Palace On The Sea", true, 169, 116, new string[] { "Uncollectible" }),
                GenerateCollectible("Three Eye Rock Palace", "Three Eye Rock Palace", true, 157, 163, new string[] { "Uncollectible" }),
                GenerateCollectible("Great Palace", "Great Palace", true, 111, 129, new string[] { "Uncollectible" }),
                // Single collectible locations
                // Hyrule area items
                GenerateCollectible("North Islands P250", 56, 7, new string[] { "Raft" }),
                GenerateCollectible("North Islands Heart", 89, 23, new string[] { "Raft" }),
                GenerateCollectible("Whale Island Book Item", 137, 13, new string[] { "Raft,Boots,Hammer" }),
                GenerateCollectible("North Islands Slime", 127, 32, new string[] { "Raft,Hammer,Thunder" }),
                GenerateCollectible("North Cave P300", 34, 39, new string[] { "Boots" }),
                GenerateCollectible("Ruto Mountain Magic", 27, 60, new string[] { "Jump" }),
                GenerateCollectible("Desert Magic", 45, 65, new string[] { "None" }),
                GenerateCollectible("Trophy Item", 54, 63, new string[] { "Candle", "Fire" }),
                GenerateCollectible("Parapa Magic", 79, 50, new string[] { "None" }),
                GenerateCollectible("Parapa Heart", 87, 95, new string[] { "None" }),
                GenerateCollectible("Forest P50", 62, 73, new string[] { "None" }),
                GenerateCollectible("Lake P50", 40, 83, new string[] { "None" }),
                GenerateCollectible("Rauru", 71, 85, new string[] { "None" }),
                GenerateCollectible("Lake Cave Magic", 41, 91, new string[] { "None" }),
                // Swamp area items
                GenerateCollectible("Flower Item", 34, 100, new string[] { "Hammer,Jump,Candle", "Hammer,Jump,Fire" }),
                GenerateCollectible("Swamp Cave Heart", 79, 93, new string[] { "Hammer,Jump", "Hammer,Glove", "Hammer,Bracelet", "Hammer,Flute", "Hammer,Raft", "Hammer,Fire" }),
                GenerateCollectible("Swamp Heart", 33, 102, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Swamp P50", 47, 98, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Swamp Magic", 64, 101, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Swamp Cave P400", 63, 93, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Letter Item", 46, 107, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Saria P100", 45, 117, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Saria Magic", 56, 119, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }),
                GenerateCollectible("Saria Mountain PBag", 10, 113, new string[] { "Jump,Fire,Letter", "Jump,Fire,Candle" }),
                GenerateCollectible("Meat Item", 9, 109, new string[] { "Jump,Fire,Letter", "Jump,Fire,Candle" }),
                GenerateCollectible("Meat P400", 14, 96, new string[] { "Jump,Fire,Letter", "Jump,Fire,Candle" }),
                // Death Mountain / Mido area items
                GenerateCollectible("Mirror Item", 38, 125, new string[] { "Candle,Fire", "Letter,Jump", "Letter,Glove", "Letter,Bracelet", "Letter,Flute", "Candle,Hammer,Jump", "Candle,Hammer,Glove", "Candle,Hammer,Bracelet", "Candle,Hammer,Flute", "Candle,Hammer,Raft" }),
                GenerateCollectible("Saria Slime", 36, 133, new string[] { "Jump,Letter,Candle", "Jump,Hammer", "Jump,Fire" }), // FairySpell works
                GenerateCollectible("Death Mountain Magic", 47, 157, new string[] { "Candle,Letter,Jump", "Candle,Letter,FairySpell,Glove", "Candle,Letter,FairySpell,Bracelet", "Candle,Letter,FairySpell,Flute", "Candle,Hammer,Jump", "Candle,Hammer,FairySpell,Glove", "Candle,Hammer,FairySpell,Bracelet", "Candle,Hammer,FairySpell,Flute", "Candle,Hammer,FairySpell,Raft", "Candle,Fire,FairySpell" }),
                GenerateCollectible("Death Mountain Heart", 43, 167, new string[] { "Candle,Letter,Jump", "Candle,Letter,Glove", "Candle,Letter,Bracelet", "Candle,Letter,Flute", "Candle,Hammer,Jump", "Candle,Hammer,Glove", "Candle,Hammer,Bracelet", "Candle,Hammer,Flute", "Candle,Hammer,Raft", "Candle,Fire" }),
                GenerateCollectible("Death Mountain Link Doll", 12, 160, new string[] { "Candle,Letter,Jump", "Candle,Letter,Glove", "Candle,Letter,Bracelet", "Candle,Letter,Flute", "Candle,Hammer,Jump", "Candle,Hammer,Glove", "Candle,Hammer,Bracelet", "Candle,Hammer,Flute", "Candle,Hammer,Raft", "Candle,Fire" }),
                GenerateCollectible("Hammer Magic", 35, 166, new string[] { "Hammer,Jump", "Hammer,Glove", "Hammer,Bracelet", "Hammer,Flute", "Hammer,Raft", "Hammer,Fire" }),
                GenerateCollectible("Death Mountain Ocean Magic", 57, 171, new string[] { "Boots,Letter,Candle,Jump", "Boots,Letter,Candle,Glove", "Boots,Letter,Candle,Bracelet", "Boots,Letter,Candle,Flute", "Boots,Hammer,Jump", "Boots,Hammer,Glove", "Boots,Hammer,Bracelet", "Boots,Hammer,Flute", "Boots,Hammer,Raft", "Boots,Fire" }),
                GenerateCollectible("Ring Item", 47, 185, new string[] { "Hammer,Jump", "Hammer,Glove", "Hammer,Bracelet", "Hammer,Flute", "Hammer,Raft", "Hammer,Fire" }),
                GenerateCollectible("Graveyard Island P500", 64, 151, new string[] { "Boots,Letter,Candle,Jump", "Boots,Letter,Candle,Glove", "Boots,Letter,Candle,Bracelet", "Boots,Letter,Candle,Flute", "Boots,Hammer,Jump", "Boots,Hammer,Glove", "Boots,Hammer,Bracelet", "Boots,Hammer,Flute", "Boots,Hammer,Raft", "Boots,Fire" }),
                GenerateCollectible("Graveyard P250", 63, 133, new string[] { "Letter,Candle,Jump", "Letter,Candle,Glove", "Letter,Candle,Bracelet", "Letter,Candle,Flute", "Hammer,Jump", "Hammer,Glove", "Hammer,Bracelet", "Hammer,Flute", "Hammer,Raft", "Fire" }),
                GenerateCollectible("Graveyard Heart", 78, 122, new string[] { "Letter,Candle,Jump", "Letter,Candle,Glove", "Letter,Candle,Bracelet", "Letter,Candle,Flute", "Hammer,Jump", "Hammer,Glove", "Hammer,Bracelet", "Hammer,Flute", "Hammer,Raft", "Fire" }),
                GenerateCollectible("King Tomb Item", 75, 119, new string[] { "Book,Protect,Jump,Heal,FairySpell,Fire,Reflect,Enigma,Thunder" }),
                GenerateCollectible("Sword Item", 57, 205, new string[] { "Glove,Downthrust,Slimes" }),
                GenerateCollectible("Sword P500", 74, 205, new string[] { "Glove,Downthrust,Slimes" }),
                // East Island area
                // Darunia area
                GenerateCollectible("Amulet Item", 150, 48, new string[] { "Raft,Boots,Book,Protect,Jump,Heal,FairySpell,Fire,Reflect,Enigma,Thunder" }),
                GenerateCollectible("Amulet Magic", 148, 61, new string[] { "Raft,Boots,Letter,Candle,Jump", "Raft,Boots,Letter,Candle,Glove", "Raft,Boots,Letter,Candle,Bracelet", "Raft,Boots,Letter,Candle,Flute", "Raft,Boots,Hammer", "Raft,Boots,Fire" }),
                GenerateCollectible("Darunia Cave P500", 115, 86, new string[] { "Raft,Boots,Letter,Candle,Jump", "Raft,Boots,Letter,Candle,Glove", "Raft,Boots,Letter,Candle,Bracelet", "Raft,Boots,Letter,Candle,Flute", "Raft,Boots,Hammer", "Raft,Boots,Fire" }),
                GenerateCollectible("Darunia P400", 126, 97, new string[] { "Raft,Letter,Candle,Jump", "Raft,Letter,Candle,Glove", "Raft,Letter,Candle,Bracelet", "Raft,Letter,Candle,Flute", "Raft,Hammer", "Raft,Fire" }),
                GenerateCollectible("Darunia Forest Slime", 148, 91, new string[] { "Raft,Letter,Candle,Jump", "Raft,Letter,Candle,Glove", "Raft,Letter,Candle,Bracelet", "Raft,Letter,Candle,Flute", "Raft,Hammer", "Raft,Fire" }),
                GenerateCollectible("Darunia P200", 155, 100, new string[] { "Raft,Letter,Candle,Jump", "Raft,Letter,Candle,Glove", "Raft,Letter,Candle,Bracelet", "Raft,Letter,Candle,Flute", "Raft,Hammer", "Raft,Fire" }),
                // Maze Island area
                GenerateCollectible("Kid Item", 196, 89, new string[] { "Raft,Downthrust,Letter,Candle,Jump", "Raft,Downthrust,Letter,Candle,Glove", "Raft,Downthrust,Letter,Candle,Bracelet", "Raft,Downthrust,Letter,Candle,Flute", "Raft,Downthrust,Hammer,Candle", "Raft,Downthrust,Fire" }),
                GenerateCollectible("Maze Island Magic", 180, 87, new string[] { "Raft,Downthrust,Letter,Candle,Jump", "Raft,Downthrust,Letter,Candle,Glove", "Raft,Downthrust,Letter,Candle,Bracelet", "Raft,Downthrust,Letter,Candle,Flute", "Raft,Downthrust,Hammer", "Raft,Downthrust,Fire" }),
                GenerateCollectible("Maze Island Slime", 190, 78, new string[] { "Raft,Downthrust,FairySpell,Letter,Candle,Jump", "Raft,Downthrust,FairySpell,Letter,Candle,Glove", "Raft,Downthrust,FairySpell,Letter,Candle,Bracelet", "Raft,Downthrust,FairySpell,Letter,Candle,Flute", "Raft,Downthrust,FairySpell,Hammer", "Raft,Downthrust,FairySpell,Fire" }),
                GenerateCollectible("Maze Island Link Doll", 201, 82, new string[] { "Raft,Downthrust,Boots,Letter,Candle,Jump", "Raft,Downthrust,Boots,Letter,Candle,Glove", "Raft,Downthrust,Boots,Letter,Candle,Bracelet", "Raft,Downthrust,Boots,Letter,Candle,Flute", "Raft,Downthrust,Boots,Hammer", "Raft,Downthrust,Boots,Fire" }),
                // Nabooru area
                GenerateCollectible("Nabooru Cave Heart", 144, 106, new string[] { "Raft,Boots,Letter,Candle,Jump", "Raft,Boots,Letter,Candle,Glove", "Raft,Boots,Letter,Candle,Bracelet", "Raft,Boots,Letter,Candle,Flute", "Raft,Boots,Hammer", "Raft,Boots,Fire" }),
                GenerateCollectible("West Nabooru P200", 117, 114, new string[] { "Raft,Letter,Candle,Jump", "Raft,Letter,Candle,Glove", "Raft,Letter,Candle,Bracelet", "Raft,Letter,Candle,Flute", "Raft,Hammer", "Raft,Fire" }),
                GenerateCollectible("Nabooru Ocean Heart", 169, 111, new string[] { "Raft,Boots,Letter,Candle,Jump", "Raft,Boots,Letter,Candle,Glove", "Raft,Boots,Letter,Candle,Bracelet", "Raft,Boots,Letter,Candle,Flute", "Raft,Boots,Hammer", "Raft,Boots,Fire" }),
                GenerateCollectible("Nabooru Beach P500", 160, 121, new string[] { "Raft,Jump,Boots,Letter,Candle", "Raft,Jump,Boots,Fire", "Raft,Jump,Hammer" }),
                GenerateCollectible("Nabooru Cave P500", 132, 127, new string[] { "Raft,Letter,Candle,Jump", "Raft,Letter,Candle,Glove", "Raft,Letter,Candle,Bracelet", "Raft,Letter,Candle,Flute", "Raft,Hammer", "Raft,Fire" }),
                // Kasuto area
                GenerateCollectible("Kasuto Graveyard Slime", 127, 147, new string[] { "Cross,Book,Raft,Flute,Protect,Jump,Heal,FairySpell,Fire,Reflect,Enigma,Thunder", "Cross,Book,Raft,Boots,Bracelet,Protect,Jump,Heal,FairySpell,Fire,Reflect,Enigma,Thunder" }),
                GenerateCollectible("Kasuto Swamp P700", 133, 137, new string[] { "Raft,Flute,Letter,Candle", "Raft,Flute,Hammer", "Raft,Flute,Fire", "Raft,Boots,Bracelet,Hammer", "Raft,Boots,Bracelet,Fire" }),
                GenerateCollectible("Kasuto River Magic", 135, 129, new string[] { "Raft,Flute,Letter,Candle", "Raft,Flute,Hammer", "Raft,Flute,Fire", "Raft,Boots,Bracelet,Hammer", "Raft,Boots,Bracelet,Fire" }),
                GenerateCollectible("Kasuto Cave P500", 138, 134, new string[] { "Raft,Flute,Letter,Candle", "Raft,Flute,Hammer", "Raft,Flute,Fire", "Raft,Boots,Bracelet,Hammer", "Raft,Boots,Bracelet,Fire" }),
                GenerateCollectible("Kasuto Lake Magic", 154, 140, new string[] { "Raft,Flute,Letter,Candle", "Raft,Flute,Hammer", "Raft,Flute,Fire", "Raft,Boots,Bracelet,Hammer", "Raft,Boots,Bracelet,Fire" }),
                GenerateCollectible("Kasuto Forest P500", 161, 147, new string[] { "Raft,Flute,Letter,Candle", "Raft,Flute,Hammer", "Raft,Flute,Fire", "Raft,Boots,Bracelet,Hammer", "Raft,Boots,Bracelet,Fire" }),
                GenerateCollectible("Kasuto Three Eye Rock Heart", 155, 159, new string[] { "Raft,Flute,Letter,Candle", "Raft,Flute,Hammer", "Raft,Flute,Fire", "Raft,Boots,Bracelet,Hammer", "Raft,Boots,Bracelet,Fire" }),
                GenerateCollectible("Mountain Heart", 109, 150, new string[] { "Raft,Cross,Flute,Letter,Candle", "Raft,Cross,Flute,Hammer", "Raft,Cross,Flute,Fire", "Raft,Cross,Boots,Bracelet,Hammer", "Raft,Cross,Boots,Bracelet,Fire" }),
                GenerateCollectible("Mountain P500", 111, 147, new string[] { "Raft,Cross,Flute,Letter,Candle", "Raft,Cross,Flute,Hammer", "Raft,Cross,Flute,Fire", "Raft,Cross,Boots,Bracelet,Hammer", "Raft,Cross,Boots,Bracelet,Fire" })
                //GenerateCollectible("", , , new string[] { "" }),
            };

            return items;
        }

        private List<Collectible> GeneratePalaceCollectibles(int palace)
        {
            List<Collectible> items = new List<Collectible>();

            // Create every collectible in palaces here
            if (palace == 1)
            {
                items.Add(GenerateCollectible("P1 Heart", 64, 4, new string[] { "P1Key1" }));
                items.Add(GenerateCollectible("P1 Key1", 188, 28, new string[] { "P1Key1" }));
                items.Add(GenerateCollectible("P1 Key2", 220, 28, new string[] { "P1Key1" }));
                items.Add(GenerateCollectible("P1 Key3", 20, 44, new string[] { "Glove" }));
                items.Add(GenerateCollectible("P1 Slime", 8, 44, new string[] { "Candle", "Fire" }));
                items.Add(GenerateCollectible("CandleItem", 44, 60, new string[] { "P1Key2" }));
                items.Add(GenerateCollectible("P1 P50", 88, 60, new string[] { "P1Key1" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Parapa Palace");
                }
            }
            else if (palace == 2)
            {
                items.Add(GenerateCollectible("P2 Link Doll", 188, 4, new string[] { "Glove" }));
                items.Add(GenerateCollectible("P2 1P100", 228, 4, new string[] { "Jump" }));
                items.Add(GenerateCollectible("P2 Key1", 168, 44, new string[] { "P2Key1,Jump", "P2Key1,Glove", "P2Key1,Bracelet", "P2Key1,Flute", "P2Key1,Fire", "P2Key1,Hammer,Raft" }));
                items.Add(GenerateCollectible("GloveItem", 4, 60, new string[] { "P2Key3,Jump", "P2Key3,Glove", "P2Key3,Bracelet", "P2Key3,Flute", "P2Key3,Fire", "P2Key3,Hammer,Raft" }));
                items.Add(GenerateCollectible("P2 P50", 48, 60, new string[] { "P2Key2,Jump", "P2Key2,Glove", "P2Key2,Bracelet", "P2Key2,Flute", "P2Key2,Fire", "P2Key2,Hammer,Raft" }));
                items.Add(GenerateCollectible("P2 Key2", 180, 60, new string[] { "Glove" }));
                items.Add(GenerateCollectible("P2 Key3", 284, 76, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Hammer,Raft" }));
                items.Add(GenerateCollectible("P2 Key4", 204, 92, new string[] { "P2Key1,Glove" }));
                items.Add(GenerateCollectible("P2 Magic", 236, 92, new string[] { "P2Key1,Glove" }));
                items.Add(GenerateCollectible("P2 2P100", 208, 108, new string[] { "P2Key2,Glove" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Midoro Palace");
                }
            }
            else if (palace == 3)
            {   // "Glove,Jump,FairySpell,Letter,Candle", "Glove,Jump,FairySpell,Hammer", "Glove,Jump,FairySpell,Fire"
                items.Add(GenerateCollectible("P3 Heart", 180, 12, new string[] { "P3Key2,Glove,Jump,FairySpell,Letter,Candle", "P3Key2,Glove,Jump,FairySpell,Hammer", "P3Key2,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("RaftItem", 196, 12, new string[] { "P3Key2,Glove,Jump,FairySpell,Letter,Candle", "P3Key2,Glove,Jump,FairySpell,Hammer", "P3Key2,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 Slime", 232, 20, new string[] { "P3Key2,Glove,Jump,FairySpell,Letter,Candle", "P3Key2,Glove,Jump,FairySpell,Hammer", "P3Key2,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 Key1", 132, 44, new string[] { "Downthrust,Glove,Jump,FairySpell,Letter,Candle", "Downthrust,Glove,Jump,FairySpell,Hammer", "Downthrust,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 P100", 140, 44, new string[] { "Downthrust,Glove,Jump,FairySpell,Letter,Candle", "Downthrust,Glove,Jump,FairySpell,Hammer", "Downthrust,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 Key2", 204, 44, new string[] { "Glove,Jump,FairySpell,Letter,Candle", "Glove,Jump,FairySpell,Hammer", "Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 1P150", 92, 60, new string[] { "P3Key1,Glove,Jump,FairySpell,Letter,Candle", "P3Key1,Glove,Jump,FairySpell,Hammer", "P3Key1,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 Key3", 100, 60, new string[] { "P3Key1,Glove,Jump,FairySpell,Letter,Candle", "P3Key1,Glove,Jump,FairySpell,Hammer", "P3Key1,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 2P150", 148, 60, new string[] { "Glove,Jump,FairySpell,Letter,Candle", "Glove,Jump,FairySpell,Hammer", "Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 Key4", 200, 60, new string[] { "P3Key1,Glove,Jump,FairySpell,Letter,Candle", "P3Key1,Glove,Jump,FairySpell,Hammer", "P3Key1,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 1P200", 156, 76, new string[] { "P3Key1,Glove,Jump,FairySpell,Letter,Candle", "P3Key1,Glove,Jump,FairySpell,Hammer", "P3Key1,Glove,Jump,FairySpell,Fire" }));
                items.Add(GenerateCollectible("P3 2P200", 188, 76, new string[] { "P3Key1,Glove,Jump,FairySpell,Letter,Candle", "P3Key1,Glove,Jump,FairySpell,Hammer", "P3Key1,Glove,Jump,FairySpell,Fire" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Island Palace");
                }
            }
            else if (palace == 4)
            {   // "Downthrust,Raft,Jump,Letter,Candle", "Downthrust,Raft,Glove,Letter,Candle", "Downthrust,Raft,Bracelet,Letter,Candle", "Downthrust,Raft,Flute,Letter,Candle", "Downthrust,Raft,Fire", "Downthrust,Raft,Hammer"
                items.Add(GenerateCollectible("P4 Key1", 4, 44, new string[] { "P4Key2,Glove,Downthrust,Raft,Letter,Candle", "P4Key2,Glove,Downthrust,Raft,Fire", "P4Key2,Glove,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 1P200", 12, 44, new string[] { "P4Key2,Glove,Downthrust,Raft,Letter,Candle", "P4Key2,Glove,Downthrust,Raft,Fire", "P4Key2,Glove,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 Key2", 60, 44, new string[] { "P4Key1,Glove,Jump,Downthrust,Raft,Letter,Candle", "P4Key1,Glove,Jump,Downthrust,Raft,Fire", "P4Key1,Glove,Jump,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 P100", 112, 44, new string[] { "Downthrust,Raft,Jump,Letter,Candle", "Downthrust,Raft,Glove,Letter,Candle", "Downthrust,Raft,Bracelet,Letter,Candle", "Downthrust,Raft,Flute,Letter,Candle", "Downthrust,Raft,Fire", "Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 Key3", 92, 60, new string[] { "P4Key2,Downthrust,Raft,Jump,Letter,Candle", "P4Key2,Downthrust,Raft,Glove,Letter,Candle", "P4Key2,Downthrust,Raft,Bracelet,Letter,Candle", "P4Key2,Downthrust,Raft,Flute,Letter,Candle", "P4Key2,Downthrust,Raft,Fire", "P4Key2,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 Magic", 144, 60, new string[] { "FairySpell,Downthrust,Raft,Jump,Letter,Candle", "FairySpell,Downthrust,Raft,Glove,Letter,Candle", "FairySpell,Downthrust,Raft,Bracelet,Letter,Candle", "FairySpell,Downthrust,Raft,Flute,Letter,Candle", "FairySpell,Downthrust,Raft,Fire", "FairySpell,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 Key4", 196, 60, new string[] { "Downthrust,Raft,Jump,Letter,Candle", "Downthrust,Raft,Glove,Letter,Candle", "Downthrust,Raft,Bracelet,Letter,Candle", "Downthrust,Raft,Flute,Letter,Candle", "Downthrust,Raft,Fire", "Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 2P200", 140, 76, new string[] { "Downthrust,Raft,Jump,Letter,Candle", "Downthrust,Raft,Glove,Letter,Candle", "Downthrust,Raft,Bracelet,Letter,Candle", "Downthrust,Raft,Flute,Letter,Candle", "Downthrust,Raft,Fire", "Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("BootsItem", 196, 76, new string[] { "P4Key1,Downthrust,Raft,Jump,Letter,Candle", "P4Key1,Downthrust,Raft,Glove,Letter,Candle", "P4Key1,Downthrust,Raft,Bracelet,Letter,Candle", "P4Key1,Downthrust,Raft,Flute,Letter,Candle", "P4Key1,Downthrust,Raft,Fire", "P4Key1,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 P250", 28, 92, new string[] { "P4Key4,Jump,Downthrust,Raft,Letter,Candle", "P4Key4,Jump,Downthrust,Raft,Fire", "P4Key4,Jump,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 Key5", 76, 108, new string[] { "Glove,Downthrust,Raft,Letter,Candle", "Glove,Downthrust,Raft,Fire", "Glove,Downthrust,Raft,Hammer" }));
                items.Add(GenerateCollectible("P4 Key6", 196, 108, new string[] { "Downthrust,Raft,Jump,Letter,Candle", "Downthrust,Raft,Glove,Letter,Candle", "Downthrust,Raft,Bracelet,Letter,Candle", "Downthrust,Raft,Flute,Letter,Candle", "Downthrust,Raft,Fire", "Downthrust,Raft,Hammer" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Maze Island Palace");
                }
            }
            else if (palace == 5)
            {   // "FairySpell,Boots,Raft,Jump,Letter,Candle", "FairySpell,Boots,Raft,Glove,Letter,Candle", "FairySpell,Boots,Raft,Bracelet,Letter,Candle", "FairySpell,Boots,Raft,Flute,Letter,Candle", "FairySpell,Boots,Raft,Fire", "FairySpell,Boots,Raft,Hammer"
                items.Add(GenerateCollectible("P5 1P200", 104, 4, new string[] { "Boots,Raft,Jump,Letter,Candle", "Jump,Boots,Raft,Fire", "Jump,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 Key1", 156, 44, new string[] { "FairySpell,Boots,Raft,Jump,Letter,Candle", "FairySpell,Boots,Raft,Glove,Letter,Candle", "FairySpell,Boots,Raft,Bracelet,Letter,Candle", "FairySpell,Boots,Raft,Flute,Letter,Candle", "FairySpell,Boots,Raft,Fire", "FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 2P200", 176, 44, new string[] { "FairySpell,Boots,Raft,Jump,Letter,Candle", "FairySpell,Boots,Raft,Glove,Letter,Candle", "FairySpell,Boots,Raft,Bracelet,Letter,Candle", "FairySpell,Boots,Raft,Flute,Letter,Candle", "FairySpell,Boots,Raft,Fire", "FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 Key2", 184, 76, new string[] { "P5Key1,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key1,Glove,FairySpell,Boots,Raft,Fire", "P5Key1,Glove,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 Magic", 260, 76, new string[] { "P5Key1,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Bracelet,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Flute,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Fire", "P5Key1,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 3P200", 60, 92, new string[] { "P5Key2,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key2,Glove,FairySpell,Boots,Raft,Fire", "P5Key2,Glove,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 4P200", 116, 92, new string[] { "P5Key1,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key1,Jump,FairySpell,Boots,Raft,Fire", "P5Key1,Jump,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 Key3", 212, 92, new string[] { "P5Key1,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Bracelet,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Flute,Letter,Candle", "P5Key1,FairySpell,Boots,Raft,Fire", "P5Key1,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 Key4", 4, 108, new string[] { "P5Key2,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Bracelet,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Flute,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Fire", "P5Key2,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 P250", 64, 108, new string[] { "P5Key2,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Bracelet,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Flute,Letter,Candle", "P5Key2,FairySpell,Boots,Raft,Fire", "P5Key2,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 5P200", 92, 108, new string[] { "P5Key1,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key1,Glove,FairySpell,Boots,Raft,Fire", "P5Key1,Glove,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("P5 Key5", 116, 108, new string[] { "P5Key1,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key1,Jump,FairySpell,Boots,Raft,Fire", "P5Key1,Jump,FairySpell,Boots,Raft,Hammer" }));
                items.Add(GenerateCollectible("FluteItem", 148, 124, new string[] { "P5Key3,FairySpell,Boots,Raft,Jump,Letter,Candle", "P5Key3,FairySpell,Boots,Raft,Glove,Letter,Candle", "P5Key3,FairySpell,Boots,Raft,Bracelet,Letter,Candle", "P5Key3,FairySpell,Boots,Raft,Flute,Letter,Candle", "P5Key3,FairySpell,Boots,Raft,Fire", "P5Key3,FairySpell,Boots,Raft,Hammer" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Palace On The Sea");
                }
            }
            else if (palace == 6)
            {   // "Flute,Raft,Letter,Candle", "Flute,Raft,Hammer"
                items.Add(GenerateCollectible("P6 Slime", 352, 36, new string[] { "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 1P300", 4, 44, new string[] { "Glove,Bracelet,Upthrust,Flute,Raft,Letter,Candle", "Glove,Bracelet,Upthrust,Flute,Raft,Hammer", "Glove,Bracelet,Upthrust,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Key1", 8, 44, new string[] { "Glove,Bracelet,Upthrust,Flute,Raft,Letter,Candle", "Glove,Bracelet,Upthrust,Flute,Raft,Hammer", "Glove,Bracelet,Upthrust,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 1P250", 60, 44, new string[] { "Glove,Jump,Flute,Raft,Letter,Candle", "Glove,Jump,Flute,Raft,Hammer", "Glove,Jump,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 2P250", 152, 60, new string[] { "P6Key2,Glove,Flute,Raft,Letter,Candle", "P6Key2,Glove,Flute,Raft,Hammer", "P6Key2,Glove,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("CrossItem", 236, 60, new string[] { "P6Key2,Glove,Flute,Raft,Letter,Candle", "P6Key2,Glove,Flute,Raft,Hammer", "P6Key2,Glove,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Key2", 84, 76, new string[] { "P6Key1,Flute,Raft,Letter,Candle", "P6Key1,Flute,Raft,Hammer", "P6Key1,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 2P300", 148, 76, new string[] { "P6Key2,Flute,Raft,Letter,Candle", "P6Key2,Flute,Raft,Hammer", "P6Key2,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Key3", 204, 76, new string[] { "P6Key2,Flute,Raft,Letter,Candle", "P6Key2,Flute,Raft,Hammer", "P6Key2,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 3P250", 84, 92, new string[] { "P6Key1,Flute,Raft,Letter,Candle", "P6Key1,Flute,Raft,Hammer", "P6Key1,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Magic", 332, 92, new string[] { "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 3P300", 348, 92, new string[] { "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 1P200", 84, 108, new string[] { "P6Key1,Flute,Raft,Letter,Candle", "P6Key1,Flute,Raft,Hammer", "P6Key1,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Key4", 92, 108, new string[] { "P6Key1,Flute,Raft,Letter,Candle", "P6Key1,Flute,Raft,Hammer", "P6Key1,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Key5", 180, 124, new string[] { "P6Key2,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key2,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key2,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 2P200", 204, 124, new string[] { "P6Key2,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key2,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key2,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 Key6", 288, 124, new string[] { "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                items.Add(GenerateCollectible("P6 P500", 332, 124, new string[] { "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Letter,Candle", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Hammer", "P6Key3,Glove,Jump,FairySpell,Flute,Raft,Fire" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Three Eye Rock Palace");
                }
            }
            else if (palace == 7)
            {   // "Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "Gems6,Cross,Flute,Raft,Glove,Hammer", "Gems6,Cross,Flute,Raft,Glove,Fire"
                items.Add(GenerateCollectible("P7 1P1k", 148, 4, new string[] { "Cross,Flute,Raft,Letter,Candle", "Cross,Flute,Raft,Hammer", "Cross,Flute,Raft,Fire", "Cross,Bracelet,Raft,Boots,Letter,Candle", "Cross,Bracelet,Raft,Boots,Fire", "Cross,Bracelet,Raft,Boots,Hammer" }));
                items.Add(GenerateCollectible("P7 2P1k", 204, 44, new string[] { "Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "Gems6,Cross,Flute,Raft,Glove,Hammer", "Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 3P1k", 124, 76, new string[] { "Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "Gems6,Cross,Flute,Raft,Glove,Hammer", "Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 4P1k", 316, 92, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 5P1k", 100, 124, new string[] { "Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "Gems6,Cross,Flute,Raft,Glove,Hammer", "Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 6P1k", 332, 188, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 Link Doll", 340, 188, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 7P1k", 324, 204, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 8P1k", 328, 204, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 9P1k", 404, 204, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("AKeyItem", 108, 220, new string[] { "Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "Gems6,Cross,Flute,Raft,Glove,Hammer", "Gems6,Cross,Flute,Raft,Glove,Fire" }));
                items.Add(GenerateCollectible("P7 10P1k", 316, 220, new string[] { "AKey,Gems6,Cross,Flute,Raft,Glove,Letter,Candle", "AKey,Gems6,Cross,Flute,Raft,Glove,Hammer", "AKey,Gems6,Cross,Flute,Raft,Glove,Fire" }));
                foreach (Collectible item in items)
                {
                    item.SetPalace("Great Palace");
                }
            }

            return items;
        }

        private List<Collectible> GenerateGroupedCollectibles()
        {
            List<Collectible> items = new List<Collectible>
            {
                // Create every grouped collectible here
                // Hyrule Castle
                GenerateCollectible("Hyrule P200", "Hyrule Castle", false, 48, 83, new string[] { "Jump" }),
                GenerateCollectible("Hyrule P300", "Hyrule Castle", false, 48, 83, new string[] { "Jump" }),
                GenerateCollectible("Hyrule Slime", "Hyrule Castle", false, 48, 83, new string[] { "Jump" }),
                GenerateCollectible("Hyrule Well P200", "Hyrule Castle", false, 48, 83, new string[] { "Jump,Glove,Downthrust" }),
                // Lake Ruins
                GenerateCollectible("Lake Ruin Heart", "Lake Ruin", false, 48, 78, new string[] { "None" }),
                GenerateCollectible("Lake Ruin P100", "Lake Ruin", false, 48, 78, new string[] { "Jump" }),
                // Ruto
                GenerateCollectible("Ruto Heart", "Ruto", false, 27, 67, new string[] { "Trophy,Jump" }),
                GenerateCollectible("Ruto Spell", "Ruto", false, 27, 67, new string[] { "Trophy" }),
                // Ruto Mountain
                GenerateCollectible("Ruto Fairy Item", "Ruto Mountain", false, 28, 51, new string[] { "Jump,Downthrust", "Jump,FairySpell" }),
                GenerateCollectible("Ruto P300", "Ruto Mountain", false, 28, 51, new string[] { "Jump,Downthrust", "Jump,FairySpell" }),
                GenerateCollectible("Ruto P500", "Ruto Mountain", false, 28, 51, new string[] { "Jump,Downthrust", "Jump,FairySpell" }),
                GenerateCollectible("Ruto Slime", "Ruto Mountain", false, 28, 51, new string[] { "Jump,Downthrust", "Jump,FairySpell" }),
                // Saria
                GenerateCollectible("Saria Heart", "Saria", false, 33, 120, new string[] { "Jump", "Glove", "Bracelet", "Flute", "Fire", "Raft,Hammer" }),
                GenerateCollectible("Saria Spell", "Saria", false, 33, 120, new string[] { "Mirror,Jump", "Mirror,Glove", "Mirror,Bracelet", "Mirror,Flute", "Mirror,Fire", "Mirror,Raft,Hammer" }),
                // Mido
                GenerateCollectible("Mido P200", "Mido", false, 85, 106, new string[] { "Flower,FairySpell,Jump,Letter,Candle", "Flower,FairySpell,Glove,Letter,Candle", "Flower,FairySpell,Bracelet,Letter,Candle", "Flower,FairySpell,Flute,Letter,Candle", "Flower,FairySpell,Jump,Hammer", "Flower,FairySpell,Glove,Hammer", "Flower,FairySpell,Bracelet,Hammer", "Flower,FairySpell,Flute,Hammer", "Flower,FairySpell,Raft,Hammer", "Flower,FairySpell,Fire" }),
                GenerateCollectible("Mido Heart", "Mido", false, 85, 106, new string[] { "FairyItem,Jump,Letter,Candle", "FairyItem,Glove,Letter,Candle", "FairyItem,Bracelet,Letter,Candle", "FairyItem,Flute,Letter,Candle", "FairyItem,Jump,Hammer", "FairyItem,Glove,Hammer", "FairyItem,Bracelet,Hammer", "FairyItem,Flute,Hammer", "FairyItem,Raft,Hammer", "FairyItem,Fire" }),
                GenerateCollectible("Mido Spell", "Mido", false, 85, 106, new string[] { "Flower,Jump,Letter,Candle", "Flower,Glove,Letter,Candle", "Flower,Bracelet,Letter,Candle", "Flower,Flute,Letter,Candle", "Flower,Jump,Hammer", "Flower,Glove,Hammer", "Flower,Bracelet,Hammer", "Flower,Flute,Hammer", "Flower,Raft,Hammer", "Flower,Fire" }),
                GenerateCollectible("Downthrust", "Mido", false, 85, 106, new string[] { "Jump,Letter,Candle", "Jump,Hammer", "Jump,Fire", "FairySpell,Glove,Letter,Candle", "FairySpell,Bracelet,Letter,Candle", "FairySpell,Flute,Letter,Candle", "FairySpell,Glove,Hammer", "FairySpell,Bracelet,Hammer", "FairySpell,Flute,Hammer", "FairySpell,Raft,Hammer", "FairySpell,Fire" }),
                // Nabooru
                GenerateCollectible("Nabooru Map Item", "Nabooru", false, 130, 116, new string[] { "Jump,Letter,Candle,Raft", "Glove,Letter,Candle,Raft", "Bracelet,Letter,Candle,Raft", "Flute,Letter,Candle,Raft", "Hammer,Raft", "Fire,Raft" }),
                GenerateCollectible("Nabooru P400", "Nabooru", false, 130, 116, new string[] { "Jump,Letter,Candle,Raft", "Jump,Hammer,Raft", "Jump,Fire,Raft" }),
                GenerateCollectible("Nabooru Well P200", "Nabooru", false, 130, 116, new string[] { "Glove,Downthrust,Letter,Candle,Raft", "Glove,Downthrust,Hammer,Raft", "Glove,Downthrust,Fire,Raft" }),
                GenerateCollectible("Nabooru Well P300", "Nabooru", false, 130, 116, new string[] { "Glove,Downthrust,Jump,Letter,Candle,Raft", "Glove,Downthrust,Jump,Hammer,Raft", "Glove,Downthrust,Jump,Fire,Raft" }),
                GenerateCollectible("Nabooru P300", "Nabooru", false, 130, 116, new string[] { "Glove,Downthrust,Jump,Fire,Raft" }),
                GenerateCollectible("Nabooru Spell", "Nabooru", false, 130, 116, new string[] { "Glove,Downthrust,Jump,Letter,Candle,Raft", "Glove,Downthrust,Jump,Hammer,Raft", "Glove,Downthrust,Jump,Fire,Raft" }),
                // Darunia
                GenerateCollectible("Darunia Heart", "Darunia", false, 110, 89, new string[] { "Downthrust,Jump,Letter,Candle,Raft", "Downthrust,Glove,Letter,Candle,Raft", "Downthrust,Bracelet,Letter,Candle,Raft", "Downthrust,Flute,Letter,Candle,Raft", "Downthrust,Hammer,Raft", "Downthrust,Fire,Raft" }),
                GenerateCollectible("Darunia Slime", "Darunia", false, 110, 89, new string[] { "Jump,Downthrust,Glove,Letter,Candle,Raft", "Jump,Downthrust,Glove,Hammer,Raft", "Jump,Downthrust,Glove,Fire,Raft" }),
                GenerateCollectible("Darunia Spell", "Darunia", false, 110, 89, new string[] { "Kid,Jump,Letter,Candle,Raft", "Kid,Glove,Letter,Candle,Raft", "Kid,Bracelet,Letter,Candle,Raft", "Kid,Flute,Letter,Candle,Raft", "Kid,Hammer,Raft", "Kid,Fire,Raft" }),
                GenerateCollectible("Upthrust", "Darunia", false, 110, 89, new string[] { "Jump,Letter,Candle,Raft", "Downthrust,Glove,Letter,Candle,Raft", "Downthrust,Bracelet,Letter,Candle,Raft", "Downthrust,Flute,Letter,Candle,Raft", "Downthrust,Hammer,Raft", "Downthrust,Fire,Raft" }),
                // New Kasuto
                GenerateCollectible("Kasuto Magic", "New Kasuto", false, 169, 141, new string[] { "Flute,Hammer,Raft", "Bracelet,Boots,Hammer,Raft" }),
                GenerateCollectible("Kasuto Bracelet Item", "New Kasuto", false, 169, 141, new string[] { "Flute,Hammer,Raft,Enigma", "Bracelet,Boots,Hammer,Raft,Enigma" }),
                GenerateCollectible("Kasuto P400", "New Kasuto", false, 169, 141, new string[] { "Flute,Bracelet,Hammer,Raft,Enigma", "Boots,Bracelet,Hammer,Raft,Enigma" }),
                GenerateCollectible("New Kasuto Spell", "New Kasuto", false, 169, 141, new string[] { "Flute,Hammer,Raft", "Bracelet,Boots,Hammer,Raft" }),
                // Old Kasuto
                GenerateCollectible("Old Kasuto Heart", "Old Kasuto", false, 141, 155, new string[] { "Cross,Flute,Letter,Candle,Raft", "Cross,Flute,Hammer,Raft", "Cross,Bracelet,Letter,Candle,Raft,Boots", "Cross,Bracelet,Hammer,Raft,Boots", "Cross,Bracelet,Fire,Raft,Boots" }),
                GenerateCollectible("Old Kasuto Spell", "Old Kasuto", false, 141, 155, new string[] { "Cross,Flute,Letter,Candle,Raft", "Cross,Flute,Hammer,Raft", "Cross,Bracelet,Letter,Candle,Raft,Boots", "Cross,Bracelet,Hammer,Raft,Boots", "Cross,Bracelet,Fire,Raft,Boots" }),
                // Hammer Cave
                GenerateCollectible("Hammer Item", "Hammer Cave", false, 37, 166, new string[] { "Candle,Fire", "Candle,Letter,Jump", "Candle,Letter,Glove", "Candle,Letter,Bracelet", "Candle,Letter,Flute", "Candle,Hammer,Jump", "Candle,Hammer,Glove", "Candle,Hammer,Bracelet", "Candle,Hammer,Flute", "Candle,Hammer,Raft" }),
                GenerateCollectible("Hammer Cave Slime", "Hammer Cave", false, 37, 166, new string[] { "Candle,Fire", "Candle,Letter,Jump", "Candle,Letter,Glove", "Candle,Letter,Bracelet", "Candle,Letter,Flute", "Candle,Hammer,Jump", "Candle,Hammer,Glove", "Candle,Hammer,Bracelet", "Candle,Hammer,Flute", "Candle,Hammer,Raft" })
            };

            return items;
        }

        private Collectible GenerateCollectible(string name, int x, int y, string[] reqs)
        {
            Collectible item = new Collectible(name, x, y);
            List<Requirements> requirementList;
            List<int> quantities;
            foreach(string req in reqs)
            {
                string[] requirementNames = req.Split(",");
                GetRequirementLists(requirementNames, out requirementList, out quantities);
                item.AddRequirementSet(requirementList, quantities);
                if (requirementList.Count == 1 && requirementList[0] == Requirements.None)
                    item.canCollect = true;
            }
            return item;
        }

        private Collectible GenerateCollectible(string name, string group, bool isPalace, int x, int y, string[] reqs)
        {
            Collectible item = new Collectible(name, x, y, group, isPalace);
            List<Requirements> requirementList;
            List<int> quantities;
            foreach (string req in reqs)
            {
                string[] requirementNames = req.Split(",");
                GetRequirementLists(requirementNames, out requirementList, out quantities);
                item.AddRequirementSet(requirementList, quantities);
                if (requirementList.Count == 1 && requirementList[0] == Requirements.None)
                    item.canCollect = true;
            }
            return item;
        }

        private void GetRequirementLists(string[] collectibles, out List<Requirements> reqs, out List<int> values)
        {
            reqs = new List<Requirements>();
            values = new List<int>();
            foreach(string item in collectibles)
            {
                switch (item.ToLower())
                {
                    case "none": reqs.Add(Requirements.None); values.Add(0); break;
                    case "candle": reqs.Add(Requirements.Candle); values.Add(1); break;
                    case "glove": reqs.Add(Requirements.Glove); values.Add(1); break;
                    case "raft": reqs.Add(Requirements.Raft); values.Add(1); break;
                    case "boots": reqs.Add(Requirements.Boots); values.Add(1); break;
                    case "flute": reqs.Add(Requirements.Flute); values.Add(1); break;
                    case "cross": reqs.Add(Requirements.Cross); values.Add(1); break;
                    case "hammer": reqs.Add(Requirements.Hammer); values.Add(1); break;
                    case "bracelet": reqs.Add(Requirements.Bracelet); values.Add(1); break;
                    case "fairyitem": reqs.Add(Requirements.FairyItem); values.Add(1); break;
                    case "akey": reqs.Add(Requirements.AllKey); values.Add(1); break;
                    case "book": reqs.Add(Requirements.Book); values.Add(1); break;
                    case "letter": reqs.Add(Requirements.Letter); values.Add(1); break;
                    case "mirror": reqs.Add(Requirements.Mirror); values.Add(1); break;
                    case "trophy": reqs.Add(Requirements.Trophy); values.Add(1); break;
                    case "flower": reqs.Add(Requirements.Flower); values.Add(1); break;
                    case "kid": reqs.Add(Requirements.Kid); values.Add(1); break;
                    case "slimes": reqs.Add(Requirements.Slimes); values.Add(12); break;
                    case "p1key1": reqs.Add(Requirements.P1Key); values.Add(1); break;
                    case "p1key2": reqs.Add(Requirements.P1Key); values.Add(2); break;
                    case "p1key3": reqs.Add(Requirements.P1Key); values.Add(3); break;
                    case "p2key1": reqs.Add(Requirements.P2Key); values.Add(1); break;
                    case "p2key2": reqs.Add(Requirements.P2Key); values.Add(2); break;
                    case "p2key3": reqs.Add(Requirements.P2Key); values.Add(3); break;
                    case "p2key4": reqs.Add(Requirements.P2Key); values.Add(4); break;
                    case "p3key1": reqs.Add(Requirements.P3Key); values.Add(1); break;
                    case "p3key2": reqs.Add(Requirements.P3Key); values.Add(2); break;
                    case "p3key3": reqs.Add(Requirements.P3Key); values.Add(3); break;
                    case "p3key4": reqs.Add(Requirements.P3Key); values.Add(4); break;
                    case "p4key1": reqs.Add(Requirements.P4Key); values.Add(1); break;
                    case "p4key2": reqs.Add(Requirements.P4Key); values.Add(2); break;
                    case "p4key3": reqs.Add(Requirements.P4Key); values.Add(3); break;
                    case "p4key4": reqs.Add(Requirements.P4Key); values.Add(4); break;
                    case "p4key5": reqs.Add(Requirements.P4Key); values.Add(5); break;
                    case "p4key6": reqs.Add(Requirements.P4Key); values.Add(6); break;
                    case "p5key1": reqs.Add(Requirements.P5Key); values.Add(1); break;
                    case "p5key2": reqs.Add(Requirements.P5Key); values.Add(2); break;
                    case "p5key3": reqs.Add(Requirements.P5Key); values.Add(3); break;
                    case "p5key4": reqs.Add(Requirements.P5Key); values.Add(4); break;
                    case "p5key5": reqs.Add(Requirements.P5Key); values.Add(5); break;
                    case "p6key1": reqs.Add(Requirements.P6Key); values.Add(1); break;
                    case "p6key2": reqs.Add(Requirements.P6Key); values.Add(2); break;
                    case "p6key3": reqs.Add(Requirements.P6Key); values.Add(3); break;
                    case "p6key4": reqs.Add(Requirements.P6Key); values.Add(4); break;
                    case "p6key5": reqs.Add(Requirements.P6Key); values.Add(5); break;
                    case "p6key6": reqs.Add(Requirements.P6Key); values.Add(6); break;
                    case "protect": reqs.Add(Requirements.Protect); values.Add(1); break;
                    case "jump": reqs.Add(Requirements.Jump); values.Add(1); break;
                    case "heal": reqs.Add(Requirements.Heal); values.Add(1); break;
                    case "fairyspell": reqs.Add(Requirements.FairySpell); values.Add(1); break;
                    case "fire": reqs.Add(Requirements.Fire); values.Add(1); break;
                    case "reflect": reqs.Add(Requirements.Reflect); values.Add(1); break;
                    case "enigma": reqs.Add(Requirements.Enigma); values.Add(1); break;
                    case "thunder": reqs.Add(Requirements.Thunder); values.Add(1); break;
                    case "downthrust": reqs.Add(Requirements.Downthrust); values.Add(1); break;
                    case "upthrust": reqs.Add(Requirements.Upthrust); values.Add(1); break;
                    case "gems6": reqs.Add(Requirements.PalaceGems); values.Add(6); break;
                    case "uncollectible": reqs.Add(Requirements.Uncollectible); values.Add(0); break;
                    default: exceptions += $"requirement failed: {item}\n"; break;
                }
            }
        }

        public Collectible FindCollectible(string ID)
        {
            Collectible collectible = null;
            bool itemFound = false;

            foreach (Collectible item in MapCollectibles)
            {
                if (item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace01Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace02Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace03Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace04Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace05Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace06Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }
            foreach (Collectible item in Palace07Collectibles)
            {
                if (!itemFound && item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    itemFound = true;
                    break;
                }
            }

            return collectible;
        }

        public Collectible FindCollectible(string ID, int index)
        {
            Collectible collectible = null;
            List<Collectible> searchItems = new List<Collectible>();
            if (index == 0) searchItems = MapCollectibles;
            if (index == 1) searchItems = Palace01Collectibles;
            if (index == 2) searchItems = Palace02Collectibles;
            if (index == 3) searchItems = Palace03Collectibles;
            if (index == 4) searchItems = Palace04Collectibles;
            if (index == 5) searchItems = Palace05Collectibles;
            if (index == 6) searchItems = Palace06Collectibles;
            if (index == 7) searchItems = Palace07Collectibles;

            foreach (Collectible item in searchItems)
            {
                if (item.ID.ToLower() == ID.ToLower())
                {
                    collectible = item;
                    break;
                }
            }

            return collectible;
        }

        public void UpdateAllCollectibility(ref MyStuff collection)
        {
            foreach (Collectible item in MapCollectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace01Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace02Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace03Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace04Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace05Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace06Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in Palace07Collectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
            foreach (Collectible item in GroupCollectibles)
            {
                item.UpdateCollectibility(ref collection);
            }
        }

        public List<Collectible> GetGroupedCollectibles(string groupID)
        {
            List<Collectible> collectibles = new List<Collectible>();

            foreach (Collectible item in GroupCollectibles)
            {
                if (item.GroupID.ToLower() == groupID.ToLower())
                {
                    collectibles.Add(item);
                }
            }

            return collectibles;
        }

        public void AllCollectibleInGroup(string groupID, out bool allCollectible, out bool anyCollectible)
        {
            allCollectible = true;
            anyCollectible = false;
            List<Collectible> collectibles = GetGroupedCollectibles(groupID);

            if (collectibles.Count == 0) allCollectible = false;
            foreach (Collectible item in collectibles)
            {
                if (!item.canCollect) allCollectible = false;
                if (item.canCollect) anyCollectible = true;
            }
        }

        public void AllCollectibleInPalace(string palaceID, out bool allCollectible, out bool anyCollectible)
        {
            allCollectible = true;
            anyCollectible = false;
            List<Collectible> collectibles = new List<Collectible>();

            switch (palaceID)
            {
                case "ParapaPalace": collectibles = Palace01Collectibles; break;
                case "MidoroPalace": collectibles = Palace02Collectibles; break;
                case "IslandPalace": collectibles = Palace03Collectibles; break;
                case "MazeIslandPalace": collectibles = Palace04Collectibles; break;
                case "PalaceOnTheSea": collectibles = Palace05Collectibles; break;
                case "ThreeEyeRockPalace": collectibles = Palace06Collectibles; break;
                case "GreatPalace": collectibles = Palace07Collectibles; break;
                default: allCollectible = false; break;
            }

            foreach (Collectible item in collectibles)
            {
                if (!item.canCollect) allCollectible = false;
                if (item.canCollect) anyCollectible = true;
            }
        }

        public List<ItemData> GetAllItemData()
        {
            List<ItemData> data = new List<ItemData>();

            foreach (Collectible item in MapCollectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace01Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace02Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace03Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace04Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace05Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace06Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in Palace07Collectibles)
            {
                data.Add(new(item.ID, item.isCollected, true));
            }
            foreach (Collectible item in GroupCollectibles)
            {
                data.Add(new(item.ID, item.isCollected, false));
            }

            return data;
        }

        public void LoadItemData(List<ItemData> items)
        {
            foreach (ItemData item in items)
            {
                Collectible collectible = FindCollectible(item.ID);
                if (collectible != null) collectible.isCollected = item.IsCollected;
            }
        }
    }

    public class ItemData
    {
        public string ID { get; set; }
        public bool IsCollected { get; set; }
        public bool HasEllipse { get; set; }

        public ItemData()
        {
            ID = string.Empty;
            IsCollected = false;
            HasEllipse = false;
        }

        public ItemData(string id, bool isCollected, bool hasEllipse)
        {
            ID = id;
            IsCollected = isCollected;
            HasEllipse = hasEllipse;
        }
    }

    public class MyData
    {
        public MyStuff Stuff { get; set; }
        public List<ItemData> Items { get; set; }

        public MyData(MyStuff stuff, List<ItemData> items)
        {
            Stuff = stuff;
            Items = items;
        }
    }
}
