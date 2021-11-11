using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class CryptLord : Enemy
    {
        public CryptLord(string name, int playerLevel, ILogger logger) : base(name, creationDefense(playerLevel, 5), creationAttack(playerLevel, 5), logger, (ConsoleColor.Red, 'V'), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetCryptLord();
        }

        public override void specialAttack(IActor target)
        {
            if (target.dodge(Attack) == false)
            {
                target.missAttack(Dialogue.Instance.getRandomMissMsg());
                return;
            }
            else
            {
                UILineManager.PrintLine("\nThe Crypt Lord rises from the ground, as the life begins to drain from you!");
                target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            }
        }
    }
}
