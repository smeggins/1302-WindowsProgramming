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

        public override string specialAttack(Actor target)
        {
            StringBuilder sb = new StringBuilder();
            string m1 = "The Knights Sword Glows With A Holy Light";
            string m2 = " is engulfed in holy flame as the knights sword makes contact";
            sb.Append(m1);
            sb.Append("\n");
            sb.Append(target.Name + m2);
            
            UILineManager.PrintLine(m1);
            target.takeDamage(this.Attack * 3, m2);
            Processor.Player.CurrentEnergy = 0;

            return sb.ToString();
        }
    }
}
