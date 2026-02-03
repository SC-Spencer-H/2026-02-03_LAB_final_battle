using FinalBattler.Character;
using FinalBattler.Character.Upgrades;

public class Program
{
    static void Main()
    {
        Hero hero = new Hero();

        hero.Equipment.Add(new FinalBattler.Character.Upgrades.Equipment(name: "The Throngler", slot: FinalBattler.Character.Upgrades.EquipmentSlot.RightArm, statBoostType: FinalBattler.Character.Upgrades.StatBoostType.Power, boostValue: 10000));

        hero.DisplayStats();
        Console.WriteLine();
        hero.DisplayStats(true);
        Console.WriteLine();

        hero.CombatClass = CombatClass.Warrior;
        hero.CurrentXP += 1000;
        hero.LevelUp();
        hero.LevelUp();
        hero.LevelUp();
        hero.LevelUp();
        hero.LevelUp();

        hero.DisplayStats();
        Console.WriteLine();
        hero.DisplayStats(true);
    }
}

