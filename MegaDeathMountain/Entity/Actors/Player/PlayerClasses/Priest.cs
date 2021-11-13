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
    public class Priest : Player
    {
        public Priest(string name, ILogger logger) : base(name, 12, 15, 7, logger, PlayerClass.Priest) {  }

        public override void specialAttack(IActor target)
        {
            int Heal = (TotalHealth / RegenRate) * 4;
            UILineManager.PrintLine("A bright light emits from the priests staff!");
            UILineManager.PrintLine($"You gained {Heal} health");

            target.takeDamage( ( (int)(this.Attack * 1.5) ), " feels excrusiating pain when caught in the light from the priests staff" );
            Processor.Player.CurrentEnergy = 0;
        }
    }
}
