using JeuCours.Living;

namespace JeuCours.Interfaces
{
    public interface IEnemy
    {
        public String Name { get; }
        public int Health { get; }
        public void AttackCharacter(Character character);
        public bool IsDead();
        public void TakeDamage(int damage,  bool ignoreDefense = false);
    }
}
