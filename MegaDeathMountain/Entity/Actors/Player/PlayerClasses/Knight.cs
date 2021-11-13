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
    public class Knight : Player
    {
        public Knight(string name, ILogger logger) : base(name, 24, 20, 10, logger, PlayerClass.Knight) {  }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine("The Knights Sword Glows With A Holy Light");
            target.takeDamage(this.Attack * 3, " is engulfed in holy flame as the knights sword makes contact");
            Processor.Player.CurrentEnergy = 0;
        }
    }
}
