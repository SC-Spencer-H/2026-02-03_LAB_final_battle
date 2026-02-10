namespace FinalBattler.Character
{
    public class Creations
    {
        protected string Name { get; set; }
        protected int Level { get; set; }
        protected int CurrentHealth { get; set; }
        protected int TotalHealth { get; set; }
        protected int TotalPower { get; set; }
        protected int TotalLuck { get; set; }
        protected int TotalMana { get; set; }

        public Creations()
        {
            Name = "Unknown";
            Level = 0;
            TotalHealth = 10;
            CurrentHealth = 1;
            TotalPower = 1;
            TotalLuck = 1;
            TotalMana = 1;
        }
    }

    public enum CombatClass
    {
        None,
        Warrior,
        Wizard,
        Rogue
    }
}
