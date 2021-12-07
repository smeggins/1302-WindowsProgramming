using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Vampire : Enemy
    {
        public Vampire(string name, int playerLevel, ILogger logger) : base(name, creationDefense(playerLevel, 3), creationAttack(playerLevel, 3), logger, (ConsoleColor.Red, 'V'), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetVampire();
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
                m1 = "The Vampire appears behind you an sinks its teeth deep in your neck!";
                UILineManager.PrintLine($"\n{m1}");
                target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            }

            return m1;
        }
    }
}
