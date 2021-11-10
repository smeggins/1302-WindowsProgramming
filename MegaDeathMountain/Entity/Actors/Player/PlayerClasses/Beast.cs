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
        public Beast(string name) : base(name, 12, 10, 15) {  }

        public override void specialAttack(IActor target)
        {
            UILineManager.PrintLine("Get absolutely fuckerd");
            target.takeDamage(this.Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
