using FinalBattler.Character;
using FinalBattler.Character.Upgrades;
using FinalBattler.GamePlay;

public class Program
{
    static void Main()
    {
        CombatManager combatManager = new CombatManager(new Hero(), new Monster());

        Console.WriteLine($"WINNER: {combatManager.NewBattle().GetName()}");
    }
}

