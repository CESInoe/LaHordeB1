using Player;

namespace World
{
    public class Enemy
    {
        public string Name;
        public int MaxHealth;
        public int Health;
        public int Attack;
        public int Defense;

        public Enemy(string name, int maxHealth, int attack, int defense)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Attack = attack;
            Defense = defense;
        }

        public void AttackCharacter(Character character)
        {
            int damage = Math.Max(0, Attack - character.Defense);
            character.Health -= damage;
            Console.WriteLine(Name + " attacks " + character.Name + " for " + damage + " damage!");
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }

}
