using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public interface IActor
    {
        public int CurrentHealth { get; set; }
        public int takeDamage(int damage, string damageMessage);
        public void die(string deathMessage);
        public string attack(Actor target, string attackMessage);
        public string specialAttack(Actor target);
        public bool dodge(int attack);
        public void missAttack(string missMessage);
        public (ConsoleColor color, char symbol) LayoutGraphic();
    }

    public abstract class Actor : IActor
    {
        protected Random _RNG = new Random();
        protected ILogger Logger;
        public (int X, int Y) LayoutPosition;
        public (ConsoleColor color, char Symbol) LayoutGraphic;

        public string Name;
        public int Defence;
        public int Attack;
        public bool Defending;


        public int Level;
        public int TotalHealth;
        private int currentHealth;
        public int CurrentHealth 
        { 
            get { return currentHealth; }
            set 
            {
                if ( (value) > 0 )
                {
                    currentHealth = (value < TotalHealth) ? value : TotalHealth;
                }
                else 
                {
                    currentHealth = 0;
                    die(Dialogue.Instance.getRandomKillMsg());
                }
            } 
        }
        public Actor(string Name, int defense, int attack, ILogger logger, (ConsoleColor color, char Symbol) layoutGraphic, int totalHealth = 100)
        {
            this.Name = Name;
            Defence = defense;
            Attack = attack;
            Level = 1;
            TotalHealth = totalHealth;
            CurrentHealth = TotalHealth;
            Defending = false;
            this.Logger = logger;
            this.LayoutGraphic = layoutGraphic;
        }

        public abstract string attack(Actor target, string attackMessage);

        public bool dodge(int attack)
        {
            int rn = _RNG.Next(1, 100);
            int ActiveDefence = (this.Defending) ? Defence * 2 : Defence;
            bool dodgeSuccessCheck = false;

            if (attack != (this.Attack * 2))
            {
                dodgeSuccessCheck = (rn >= ActiveDefence) ? true : false;
            }
            else
            {
                dodgeSuccessCheck = (rn >= (ActiveDefence / 2)) ? true : false;
            }

            Defending = false;
            return dodgeSuccessCheck;
        }


        public abstract void die(string deathMessage);

        public abstract string specialAttack(Actor target);

        public virtual int takeDamage(int damage, string damageMessage)
        {
            int damageTaken = _RNG.Next(damage - 3, damage + 2);
            UILineManager.PrintLine($"\n\n{Name}{damageMessage}");
            UILineManager.PrintLine($"{damageTaken} damage\n\n");
            this.CurrentHealth -= damageTaken;
            return damageTaken;
        }
        public void missAttack(string missMessage)
        {
            UILineManager.PrintLine(Name + missMessage);
        }

        (ConsoleColor color, char symbol) IActor.LayoutGraphic()
        {
            return this.LayoutGraphic;
        }
    }
}
