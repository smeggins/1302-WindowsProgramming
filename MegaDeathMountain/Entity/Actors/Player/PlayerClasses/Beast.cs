using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    /// <summary>
    // public string Name;
    // public float Defence;
    // public float Level;
    // public float TotalHealth;
    // public float CurrentHealth
    // public float TotalEnergy;
    // public float RegenRate;
    // public float CurrentEnergy
    /// </summary>
    public class Beast : Player
    {
        public Beast(string name, ILogger logger) : base(name, 12, 10, 15, logger, PlayerClass.Beast) {  }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine("The beast leaps into the enemy, slicing wildly");
            this.Attack = Attack / 2;
            for (int i = 0; i < 3; i++)
            {
                attack(target, " slashes in a FURY");
            }
            this.Attack = Attack * 2;
            target.takeDamage(this.Attack, " is covered in wounds from the vicious attack");
            Processor.Player.CurrentEnergy = Processor.Player.CurrentEnergy / 2;
        }
    }
}
