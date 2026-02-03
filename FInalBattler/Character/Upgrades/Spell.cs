namespace FinalBattler.Character.Upgrades
{
    public class Spell
    {
        public string SpellName { get; set; }
        public int ManaCost { get; set; }
        public int BaseDamage { get; set; }

        public Spell(string name, int manaCost, int baseDamage)
        {
            SpellName = name;
            ManaCost = manaCost;
            BaseDamage = baseDamage;
        }

        public int CalculateSpellDamage(int heroPower)
        {
            return BaseDamage + (heroPower / 2);
        }

        public void CastSpell(Hero hero)
        {
        }
    }
}
