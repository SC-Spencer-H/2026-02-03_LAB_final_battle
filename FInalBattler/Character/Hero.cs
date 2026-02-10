using FinalBattler.Character.Upgrades;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero, IBattlable
    {
        private int Health { get; set; }
        private int Power { get; set; }
        private int Luck { get; set; }
        private int Mana { get; set; }
        private int CurrentXP { get; set; }
        private int XPToNextLevel { get; set; }
        private CombatClass CombatClass { get; set; }
        private List<Item> Items { get; set; } = new List<Item>();
        private List<Skill> Skills { get; set; } = new List<Skill>();
        private List<Spell> Spells { get; set; } = new List<Spell>();
        private List<Equipment> Equipment { get; set; } = new List<Equipment>();

        public Hero(string name = "Hero")
        {
            Name = name;
            Health = 1;
            Power = 1;
            Luck = 1;
            Mana = 1;
            CurrentXP = 0;
            XPToNextLevel = 100;

            this.CombatClass = CombatClass.None;

            CalculateTotals();
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

                CalculateTotals();

                CurrentXP -= XPToNextLevel;
                XPToNextLevel += 100;
                Level++;
            }
        }

        public void DisplayStats(bool showTotalStats = false)
        {
            if (showTotalStats)
            {
                CalculateTotals();

                Console.WriteLine("TOTAL STATS");
                Console.WriteLine($"Health: {TotalHealth}");
                Console.WriteLine($"Power: {TotalPower}");
                Console.WriteLine($"Luck: {TotalLuck}");
                Console.WriteLine($"Mana: {TotalMana}");
                Console.WriteLine($"Level: {Level}");
                Console.WriteLine($"XP to next level: {XPToNextLevel - CurrentXP}");
            }
            else
            {
                Console.WriteLine("STATS");
                Console.WriteLine($"Health: {Health}");
                Console.WriteLine($"Power: {Power}");
                Console.WriteLine($"Luck: {Luck}");
                Console.WriteLine($"Mana: {Mana}");
                Console.WriteLine($"Level: {Level}");
                Console.WriteLine($"XP to next level: {XPToNextLevel - CurrentXP}");
            }
        }

        public void CalculateTotals() 
        {
            TotalHealth = Health;
            TotalPower = Power;
            TotalLuck = Luck;
            TotalMana = Mana;

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

        public BattleActions ChooseCombatAction(int opponents, out int target)
        {
            target = Random.Shared.Next(opponents);
            return (BattleActions)Random.Shared.Next(3);
        }

        public void TakeDamage()
        {
            CurrentHealth--;
        }

        public void BasicAttack()
        {
            Console.WriteLine($"{Name} swings their weapon");
        }

        public void SpecialAttack()
        {
            Console.WriteLine($"{Name} unleashes a magical blast");
        }

        public void Defend()
        {
            Console.WriteLine($"{Name} raises their shield");
        }

        public string GetName() => Name;

        public int GetCurrentHealth() => CurrentHealth;
    }

    public enum CombatClass
    {
        None,
        Warrior,
        Wizard,
        Rogue
    }
}
