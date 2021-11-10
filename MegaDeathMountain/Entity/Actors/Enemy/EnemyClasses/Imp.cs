using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Imp : Enemy
    {
        public Imp(string name, int playerLevel) : base(name, creationDefense(playerLevel, 1), creationAttack(playerLevel, 1), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetImp();
        }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine($"\nThe Imp Sends a massive fireball towards you!");
            target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
