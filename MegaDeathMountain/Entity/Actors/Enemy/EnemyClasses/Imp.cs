using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Imp : Enemy
    {
        public Imp(string name, int playerLevel, ILogger logger) : base(name, creationDefense(playerLevel, 1), creationAttack(playerLevel, 1), logger, (ConsoleColor.Red, 'I'), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetImp();
        }

        public override string specialAttack(Actor target)
        {
            string m1;
            if (target.dodge(Attack) == false)
            {
                m1 = Dialogue.Instance.getRandomMissMsg();
                target.missAttack(m1);
            }
            else
            {
                m1 = "The Imp Sends a massive fireball towards you!";
                UILineManager.PrintLine($"\n{m1}");
                target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            }

            return m1;
        }
    }
}
