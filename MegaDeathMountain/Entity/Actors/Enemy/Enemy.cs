using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public abstract class Enemy : Actor
    {
        public bool waitingToAttack = false;
        public Enemy(string name, int defense, int attack, int health) : base(name, defense, attack, health) {  }

        public override int attack(IActor target, string attackMessage)
        {
            int damage = this._Attack;

            if (waitingToAttack == false)
            {
                if (_RNG.Next(1, 10) > 3)
                {
                    Console.WriteLine(_Name + "Begins charging for a powerful attack");
                    waitingToAttack = true;
                    return 0;
                }
                else
                {
                    Console.WriteLine(_Name + attackMessage);

                    if (target.defend(_Attack) == false)
                    {
                        target.missAttack(Dialogue.Instance.getRandomMissMsg());
                        return 0;
                    }
                    else
                    {
                        target.takeDamage(_Attack, Dialogue.Instance.getRandomHitMsg());

                    }
                    return _Attack;
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
