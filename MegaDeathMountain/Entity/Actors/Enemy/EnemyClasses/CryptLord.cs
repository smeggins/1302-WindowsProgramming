using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class CryptLord : Enemy
    {
        public CryptLord(string name, int playerLevel) : base(name, creationDefense(playerLevel, 5), creationAttack(playerLevel, 5), creationHealth(playerLevel)) { } 

        public override void specialAttack(IActor target)
        {
            Console.WriteLine("\nThe Crypt Lord rises from the ground, as the life begins to drain from you!");
            target.takeDamage(this._Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
