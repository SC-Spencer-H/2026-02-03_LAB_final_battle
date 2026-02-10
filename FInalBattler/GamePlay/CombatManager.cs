using FinalBattler.Character;
using FinalBattler.Interfaces;

namespace FinalBattler.GamePlay
{
    public class CombatManager
    {
        private List<IBattlable> Battlers = new List<IBattlable>();

        public CombatManager(params IBattlable[] battlers)
        {
            foreach (IBattlable battler in battlers)
            {
                Battlers.Add(battler);
            }
        }

        public void AddBattler(IBattlable battler)
        {
            Battlers.Add(battler);
        }

        public IBattlable NewBattle()
        {
            while (Battlers.Count > 1 && Battlers.Any(b => b.GetCurrentHealth() > 0))
            {
                CombatTurn();
            }

            return Battlers[0];
        }

        private void CombatTurn()
        {
            foreach (IBattlable battler in Battlers)
            {
                if (battler.GetCurrentHealth() > 0)
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
                else
                {
                    Battlers.Remove(battler);
                    break;
                }
            }
        }
    }
}
