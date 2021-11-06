using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    /// <summary>
    // public string _Name;
    // public float _Defence;
    // public float _Level;
    // public float _TotalHealth;
    // public float _CurrentHealth
    // public float _TotalEnergy;
    // public float _RegenRate;
    // public float _CurrentEnergy
    /// </summary>
    public class Knight : Player
    {
        public Knight(string name) : base(name, 24, 20, 10) {  }

        public override void specialAttack(IActor target)
        {
            Console.WriteLine("Get absolutely fuckerd");
            target.takeDamage(this._Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
