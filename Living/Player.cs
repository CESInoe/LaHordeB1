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

        public Character(string name, int maxHealth, int attack, int defense, Weapon equippedWeapon)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Attack = attack;
            Defense = defense;
            EquippedWeapon = equippedWeapon;
        }

        public void AttackEnemy(IEnemy enemy)
        {
            int damage = Math.Max(0, Attack + EquippedWeapon.Damage);
            enemy.TakeDamage( damage);
            Console.WriteLine(Name + " attacks " + enemy.Name + " with " + EquippedWeapon.Name + " for " + damage + " damage!");
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
