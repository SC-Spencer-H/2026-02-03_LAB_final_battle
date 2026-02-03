using FinalBattler.Character;
using FinalBattler.Character.Upgrades;

public class Program
{
    static void Main()
    {
        Hero hero = new Hero();

        FinalBattler.Character.Upgrades.Equipment equipment = new FinalBattler.Character.Upgrades.Equipment(name: "The Throngler", slot: FinalBattler.Character.Upgrades.EquipmentSlot.RightArm, statBoostType: FinalBattler.Character.Upgrades.StatBoostType.Power, boostValue: 10000);
        hero.Equipment.Add(equipment);

        hero.DisplayStats();
        hero.DisplayStats(true);

        hero.CombatClass = CombatClass.Warrior;
        hero.CurrentXP += 1000;
        hero.LevelUp();
        hero.LevelUp();
        hero.LevelUp();
        hero.LevelUp();
        hero.LevelUp();

        hero.DisplayStats();
        hero.DisplayStats(true);
    }
}

