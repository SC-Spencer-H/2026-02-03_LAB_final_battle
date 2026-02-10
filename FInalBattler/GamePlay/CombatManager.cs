using FinalBattler.Character;
using FinalBattler.Interfaces;

namespace FinalBattler.GamePlay
{
    public class CombatManager
    {
        private List<IBattleActions> Battlers = new List<IBattleActions>();

        public CombatManager(params IBattleActions[] battlers)
        {
            foreach (IBattleActions battler in battlers)
            {
                Battlers.Add(battler);
            }
        }

        public void NewBattle()
        {
            while (Battlers.Any(b => b.GetCurrentHealth() > 0))
            {
                CombatTurn();
            }
        }

        public void CombatTurn()
        {
            foreach (IBattleActions battler in Battlers)
            {
                switch (battler.ChooseCombatAction(opponents: Battlers.Count - 1, out int target))
                {
                    case BattleActions.BasicAttack:
                        battler.BasicAttack();
                        Battlers[target].TakeDamage();
                        break;
                    case BattleActions.SpecialAttack:
                        battler.SpecialAttack();
                        Battlers[target].TakeDamage();
                        break;
                    case BattleActions.Defend:
                        battler.Defend();
                        break;
                }
            }
        }
    }
}
