using JeuCours.Interfaces;
using JeuCours.Living;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuCours.World
{
    // But du system de spell : 
    // Avoir une classe absraite spell avec une méthode Cast 
    // Le sort Boule de feu : il surcharge Cast, prend en paramètre un Enemy
    // et lui inflige des dégats en appelant la bonne méthode
    // Le sort Heal Overide Cast et prend un objet de type Object. Il vérifie ensuite si l'objet est du type ICanBeHealed
    // pour lui apeler une méthode "HealSelf"
    // Le joueur a une méthode CastSpell qui instancie un nouveau sort. Il lance ensuite ce sort en choississant une cible
    // 

    public abstract class Spell
    {
        internal String _name;
        public void cast(Object? target) {
            string targetName;
            try
            {
                targetName = target.GetType().GetProperty("Name").ToString();
            }catch(Exception)
            {
                targetName = "something";
            }
            if()
            Console.WriteLine($"{targetName}You hear the spell {_name}");

        }
    }

    public class Fireball : Spell
    {
        public Fireball() {
            _name = "Fireball";
        }
        public void cast (Object? target)  {
            if(target != null && target is IEnemy) {
                IEnemy enemy = (IEnemy)target;
                enemy.TakeDamage(20, true);
                base.cast(target);
            }
        } 
    }
}
