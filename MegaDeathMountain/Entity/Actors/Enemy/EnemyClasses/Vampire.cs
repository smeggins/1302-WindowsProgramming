using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Vampire : Enemy
    {
        public Vampire(string name, int playerLevel) : base(name, creationDefense(playerLevel, 3), creationAttack(playerLevel, 3), creationHealth(playerLevel)) { }

        public override List<string> Image()
        {
            return EnemyImages.Instance.GetVampire();
        }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine("\nThe Vampire appears behind you an sinks its teeth deep in your neck!");
            target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
