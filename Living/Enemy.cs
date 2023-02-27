using JeuCours.Interfaces;

namespace JeuCours.Living
{
    public class Enemy : IEnemy
    {
        internal string name;
        internal int maxHealth;
        internal int health;
        internal int attack;
        internal int defense;

        public String Name { get { return name; } }
        public int Health { get { return health; } }

        public Enemy(string name, int maxHealth, int attack, int defense)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            health = maxHealth;
            this.attack = attack;
            this.defense = defense;
        }

        public void AttackCharacter(Character character)
        {
            int damage = Math.Max(0, attack - character.Defense);
            character.Health -= damage;
            Console.WriteLine(name + " attacks " + character.Name + " for " + damage + " damage!");
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        public void TakeDamage(int damage, bool ignoreDefense = true)
        {
            health -= ignoreDefense ? Math.Max(0, damage - defense) : damage;
        }
    }

}
