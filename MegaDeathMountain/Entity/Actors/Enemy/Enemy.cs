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

        public override int attack(IActor target, string attackMessage)
        {
            if (ChargingSpecialAttack == false)
            {
                if (_RNG.Next(1, 10) > 3)
                {
                    UILineManager.PrintLine(Name + "Begins charging for a powerful attack");
                    ChargingSpecialAttack = true;
                    return 0;
                }
                else
                {
                    UILineManager.PrintLine(Name + attackMessage);

                    if (target.dodge(Attack) == false)
                    {
                        target.missAttack(Dialogue.Instance.getRandomMissMsg());
                        return 0;
                    }
                    else
                    {
                        target.takeDamage(Attack, Dialogue.Instance.getRandomHitMsg());

                    }
                    return Attack;
                }
            }
            return 0;
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
