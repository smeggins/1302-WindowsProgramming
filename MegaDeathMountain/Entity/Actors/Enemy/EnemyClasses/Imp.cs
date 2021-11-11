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

        public override void specialAttack(IActor target)
        {
            
            if (target.dodge(Attack) == false)
            {
                target.missAttack(Dialogue.Instance.getRandomMissMsg());
                return;
            }
            else
            {
                UILineManager.PrintLine($"\nThe Imp Sends a massive fireball towards you!");
                target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            }
        }
    }
}
