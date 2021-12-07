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
        public override string attack(Actor target, string attackMessage)
        {
            target.takeDamage(1, " barely notices the struggle of the villager");
            return "";
        }

        public override void die(string deathMessage = "A civilian has been killed!")
        {
            UILineManager.PrintLine(deathMessage);
            Processor.WipeNPCFromExistence(this);
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
        }
        

        public override string specialAttack(Actor target)
        {
            string m1 = " never expected the raw power just unleashed upon them";
            target.takeDamage(100, m1);

            return target.Name + m1;
        }
    }
}
