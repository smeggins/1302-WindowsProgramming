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

        public override string specialAttack(Actor target)
        {
            int Heal = (TotalHealth / RegenRate) * 4;

            StringBuilder sb = new StringBuilder();
            string m1 = "A bright light emits from the priests staff!";
            string m2 = $"You gained {Heal} health";
            string m3 = " feels excrusiating pain when caught in the light from the priests staff";
            sb.Append(m1);
            sb.Append("\n");
            sb.Append(m2);
            sb.Append("\n");
            sb.Append(target.Name + m3);

            
            UILineManager.PrintLine(m1);
            UILineManager.PrintLine(m2);

            target.takeDamage( ( (int)(this.Attack * 1.5) ), m3 );
            Processor.Player.CurrentEnergy = 0;

            return sb.ToString();
        }
    }
}
