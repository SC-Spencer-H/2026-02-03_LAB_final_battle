using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Monster : Creations, IBattleActions
    {
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
            Console.WriteLine("Monster attacks");
        }

        public void SpecialAttack()
        {
            Console.WriteLine("Monster special attacks");
        }

        public void Defend()
        {
            Console.WriteLine("Monster guards");
        }
    }
}
