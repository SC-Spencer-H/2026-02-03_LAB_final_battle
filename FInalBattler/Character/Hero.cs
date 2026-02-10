using FinalBattler.Character.Upgrades;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero, IBattleActions
    {
        private int Health { get; set; }
        private int Power { get; set; }
        private int Luck { get; set; }
        private int Mana { get; set; }
        private int CurrentXP { get; set; }
        private int XPToNextLevel { get; set; }
        private CombatClass CombatClass { get; set; }
        private List<Item> Items { get; set; }
        private List<Skill> Skills { get; set; }
        private List<Spell> Spells { get; set; }
        private List<Equipment> Equipment { get; set; }

        public Hero()
        {
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

        public BattleActions ChooseCombatAction(int opponents, out int target)
        {
            target = Random.Shared.Next(opponents);
            return (BattleActions)Random.Shared.Next(3);
        }

        public int GetCurrentHealth() => CurrentHealth;
        public void TakeDamage()
        {
            CurrentHealth--;
        }

        public void BasicAttack()
        {
            Console.WriteLine($"{Name} attacks");
        }

        public void SpecialAttack()
        {
            Console.WriteLine($"{Name} attacks specially");
        }

        public void Defend()
        {
            Console.WriteLine($"{Name} raises their guard");
        }
    }
}
