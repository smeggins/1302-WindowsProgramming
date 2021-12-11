using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public abstract class Enemy : Actor
    {
        public bool ChargingSpecialAttack = false;
        public Enemy(string name, int defense, int attack, ILogger logger,(ConsoleColor color, char Symbol) layoutGraphic, int health) : base(name, defense, attack, logger, layoutGraphic, health) {  }

        public abstract List<string> Image();
        public override void die(string deathMessage)
        {
            UILineManager.PrintLine(this.Name + deathMessage);
            Processor.WipeEnemyFromExistence(this);
        }

        public override string attack(Actor target, string attackMessage)
        {
            string ReturnMessage;
            if (ChargingSpecialAttack == false)
            {
                if (_RNG.Next(1, 10) > 3)
                {
                    ReturnMessage = Name + "Begins charging for a powerful attack";
                    UILineManager.PrintLine(ReturnMessage);
                    ChargingSpecialAttack = true;
                }
                else
                {
                    UILineManager.PrintLine(Name + attackMessage);
                    ReturnMessage = target.Name;

                    if (target.dodge(Attack) == false)
                    {
                        ReturnMessage += Dialogue.Instance.getRandomMissMsg();
                        target.missAttack(Dialogue.Instance.getRandomMissMsg());
                    }
                    else
                    {
                        ReturnMessage += Dialogue.Instance.getRandomHitMsg();
                        target.takeDamage(Attack, Dialogue.Instance.getRandomHitMsg());
                    }
                }
            }
            
            return attackMessage;
        }

        protected static int creationAttack(int playerLevel, int multiplier)
        {
            return 5 + (multiplier * playerLevel);
        }

        protected static int creationDefense(int playerLevel, int multiplier)
        {
            return 10 + multiplier * (playerLevel / 3);
        }

        protected static int creationHealth(int playerLevel)
        {
            return 10 * playerLevel;
        }
    }
}
