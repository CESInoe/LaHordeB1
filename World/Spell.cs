using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuCours.World
{
    public class Spell
    {
        public string Name;
        public SpellType Type;
        public int Amount;

        public Spell(string name, SpellType type, int amount)
        {
            Name = name;
            Type = type;
            Amount = amount;
        }
    }

    public enum SpellType
    {
        Heal,
        Fireball
    }
}
