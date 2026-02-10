using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBattler.Interfaces
{
    public interface IBattler
    {
        public int GetCurrentHealth();
        public void TakeDamage();
    }
}
