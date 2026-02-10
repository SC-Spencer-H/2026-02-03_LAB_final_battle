using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBattler.Interfaces
{
    public interface IBattlable
    {
        public string GetName();
        public int GetCurrentHealth();
        public void TakeDamage();
        public void BasicAttack();
        public void SpecialAttack();
        public void Defend();
        public BattleActions ChooseCombatAction(int opponents, out int target);
    }

    public enum BattleActions
    {
        BasicAttack,
        SpecialAttack,
        Defend
    }
}
