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
            target.takeDamage(1, " barely notices the struggle of the villager");
            return 0;
        }

        public override void die(string deathMessage = "A civilian has been killed!")
        {
            UILineManager.PrintLine(deathMessage);
            Processor.WipeNPCFromExistence(this);
            UILineManager.waitForEnter();
        }

        public  void Rescued(string rescueMessage, int amountHealed = 15)
        {
            UILineManager.PrintLine(rescueMessage);

            if (amountHealed > 0)
            {
                UILineManager.PrintLine($"You were healed for {amountHealed} damage");
                Processor.Player.CurrentHealth = CurrentHealth + amountHealed;
            }
            
            Processor.WipeNPCFromExistence(this);
            UILineManager.waitForEnter();
        }
        

        public override void specialAttack(IActor target)
        {
            target.takeDamage(100, " never expected the raw power just unleashed upon them");
        }
    }
}
