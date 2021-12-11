using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Demon : Enemy
    {
        public Demon(string name, int playerLevel, ILogger logger) : base(name, creationDefense(playerLevel, 2), creationAttack(playerLevel, 2), logger, (ConsoleColor.Red, 'D'), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetDemon();
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
                m1 = "The demon rears back, and begins an all out frenzied attack";
                UILineManager.PrintLine($"\n{m1}");
                target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            }

            return m1;
        }
    }
}
