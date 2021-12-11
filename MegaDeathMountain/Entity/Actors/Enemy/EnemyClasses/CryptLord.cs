using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class CryptLord : Enemy
    {
        public CryptLord(string name, int playerLevel, ILogger logger) : base(name, creationDefense(playerLevel, 5), creationAttack(playerLevel, 5), logger, (ConsoleColor.Red, 'C'), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetCryptLord();
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
                m1 = "The Crypt Lord rises from the ground, as the life begins to drain from you!";
                UILineManager.PrintLine($"\n{m1}");
                target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            }

            return m1;
        }
    }
}
