using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Demon : Enemy
    {
        public Demon(string name, int playerLevel) : base(name, creationDefense(playerLevel, 2), creationAttack(playerLevel, 2), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetDemon();
        }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine("\nThe demon rears back, and begins an all out frenzied attack");
            target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
