using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public class NPC : Actor
    {
        public NPC(ILogger logger) : base(NPCNames.Instance.getRandomName(), 0,0, logger, (ConsoleColor.Blue, '@')) {}
        public override int attack(IActor target, string attackMessage)
        {
            // Not USED
            throw new NotImplementedException();
        }

        public override void die(string deathMessage)
        {
            UILineManager.PrintLine(deathMessage);

        }

        public override void specialAttack(IActor target)
        {
            // Not Used
            throw new NotImplementedException();
        }
    }
}
