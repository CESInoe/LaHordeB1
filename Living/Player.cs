using JeuCours.Interfaces;
using JeuCours.World;

namespace JeuCours.Living
{
    public class Character
    {
        public string Name;
        public int MaxHealth;
        public int Health;
        public int Attack;
        public int Defense;
        public Weapon EquippedWeapon;
        public Spell[] KnownSpells;

        public Character(string name, int maxHealth, int attack, int defense, Weapon equippedWeapon, Spell[] knownSpells)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Attack = attack;
            Defense = defense;
            EquippedWeapon = equippedWeapon;
            KnownSpells = knownSpells;
        }

        public void AttackEnemy(IEnemy enemy)
        {
            int damage = Math.Max(0, Attack + EquippedWeapon.Damage);
            enemy.TakeDamage( damage);
            Console.WriteLine(Name + " attacks " + enemy.Name + " with " + EquippedWeapon.Name + " for " + damage + " damage!");
        }

        public void CastSpell(Spell spell, IEnemy target)
        {
            if (!Array.Exists(KnownSpells, s => s == spell))
            {
                Console.WriteLine(Name + " does not know how to cast " + spell.Name + "!");
                return;
            }
            if (spell.Type == SpellType.Heal)
            {
                int amount = Math.Min(MaxHealth - Health, spell.Amount);
                Health += amount;
                Console.WriteLine(Name + " casts " + spell.Name + " and heals " + amount + " health!");
            }
            else if (spell.Type == SpellType.Fireball)
            {
                int damage = spell.Amount;
                target.TakeDamage(damage);
                Console.WriteLine(Name + " casts " + spell.Name + " on " + target.Name + " for " + damage + " damage!");
            }
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
