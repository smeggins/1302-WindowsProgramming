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
        public Knight(string name, ILogger logger) : base(name, 24, 20, 10, logger) {  }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine("Get absolutely fuckerd");
            target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
            this.CurrentEnergy = 0;
        }
    }
}
