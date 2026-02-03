using FinalBattler.Character.Upgrades;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero
    {
        public int Health { get; set; }
        public int Power { get; set; }
        public int Luck { get; set; }
        public int Mana { get; set; }
        public int CurrentXP { get; set; }
        public int XPToNextLevel { get; set; }
        public CombatClass CombatClass { get; set; }
        public List<Item> Items { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Equipment> Equipment { get; set; }

        public Hero()
        {
            Name = "Unknown";
            Level = 0;
            Health = 1;
            Power = 1;
            Luck = 1;
            Mana = 1;
            CurrentXP = 0;
            this.CombatClass = CombatClass.None;
        }

        public void LevelUp()
        {
            if (CurrentXP >= XPToNextLevel)
            {
                switch (this.CombatClass)
                {
                    case CombatClass.Warrior:
                        Health += Random.Shared.Next(1, 21);
                        Power += Random.Shared.Next(3, 6);
                        Luck += Random.Shared.Next(1, 4);
                        Mana += Random.Shared.Next(1, 4);
                        break;
                    case CombatClass.Wizard:
                        Health += Random.Shared.Next(1, 16);
                        Power += Random.Shared.Next(1, 4);
                        Luck += Random.Shared.Next(1, 4);
                        Mana += Random.Shared.Next(3, 6);
                        break;
                    case CombatClass.Rogue:
                        Health += Random.Shared.Next(1, 16);
                        Power += Random.Shared.Next(1, 4);
                        Luck += Random.Shared.Next(3, 6);
                        Mana += Random.Shared.Next(1, 4);
                        break;
                    case CombatClass.None:
                        return;
                        break;
                }

                CurrentXP -= XPToNextLevel;
                XPToNextLevel += 100;
            }
        }

        public void DisplayStats(bool showTotalStats = false)
        {
            if (showTotalStats)
            {
                CalculateTotals();

                Console.WriteLine($"Health: {TotalHealth}");
                Console.WriteLine($"Power: {TotalPower}");
                Console.WriteLine($"Luck: {TotalLuck}");
                Console.WriteLine($"Mana: {TotalMana}");
                Console.WriteLine($"XP to level up: {XPToNextLevel - CurrentXP}");
            }
            else
            {
                Console.WriteLine($"Health: {Health}");
                Console.WriteLine($"Power: {Power}");
                Console.WriteLine($"Luck: {Luck}");
                Console.WriteLine($"Mana: {Mana}");
                Console.WriteLine($"XP to level up: {XPToNextLevel - CurrentXP}");
            }
        }

        public void CalculateTotals() 
        {
            foreach (Equipment equipment in this.Equipment)
            {
                switch (equipment.StatBoostType)
                {
                    case StatBoostType.Health:
                        TotalHealth += equipment.BoostValue;
                        break;
                    case StatBoostType.Power:
                        TotalPower += equipment.BoostValue;
                        break;
                    case StatBoostType.Luck:
                        TotalLuck += equipment.BoostValue;
                        break;
                    case StatBoostType.Mana:
                        TotalMana += equipment.BoostValue;
                        break;
                }
            }
        }
    }
}
