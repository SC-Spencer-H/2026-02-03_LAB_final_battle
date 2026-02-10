using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Monster : Creations, IBattlable
    {
        public Monster(string name = "Monster")
        {
            Name = name;
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
            Console.WriteLine($"{Name} swipes their claws");
        }

        public void SpecialAttack()
        {
            Console.WriteLine($"{Name} spits acid");
        }

        public void Defend()
        {
            Console.WriteLine($"{Name} dodges");
        }

        public string GetName() => Name;

        public int GetCurrentHealth() => CurrentHealth;
    }
}
