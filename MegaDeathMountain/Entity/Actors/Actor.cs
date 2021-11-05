using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSlayer9000OmegaForce1
{
    public interface IActor
    {
        public int _CurrentHealth { get; set; }
        public void takeDamage(int damage, string damageMessage);
        public void die(string deathMessage);
        public int attack(IActor target, string attackMessage);
        public void specialAttack(IActor target);
        public bool defend(int attack);
        public void missAttack(string missMessage);
    }

    public abstract class Actor : IActor
    {
        protected Random _RNG = new Random();
        public string _Name;
        public int _Defence;
        public int _Attack;

        public int _Level;
        public int _TotalHealth;
        public int currentHealth;
        public int _CurrentHealth 
        { 
            get { return currentHealth; }
            set 
            {
                if ( (value) > 0 )
                {
                    currentHealth = (value < _TotalHealth) ? value : _TotalHealth;
                }
                else 
                {
                    currentHealth = 0;
                    die(Dialogue.Instance.getRandomKillMsg());
                }
            } 
        }
        public Actor(string Name, int defense, int attack, int totalHealth = 100)
        {
            _Name = Name;
            _Defence = defense;
            _Attack = attack;
            _Level = 1;
            _TotalHealth = totalHealth;
            _CurrentHealth = _TotalHealth;
        }

        public abstract int attack(IActor target, string attackMessage);

        public abstract bool defend(int attack);

        public abstract void die(string deathMessage);

        public abstract void specialAttack(IActor target);

        public virtual void takeDamage(int damage, string damageMessage)
        {
            Console.WriteLine($"\n\n{_Name}{damageMessage}");
            Console.WriteLine($"{damage} damage\n\n");
            this._CurrentHealth -= damage;
        }
        public abstract void missAttack(string missMessage);
    }
}
