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

        public override string specialAttack(Actor target)
        {
            StringBuilder sb = new StringBuilder();
            string m1 = "The beast leaps into the enemy, slicing wildly";
            string m2 = " slashes in a FURY";
            string m3 = " is covered in wounds from the vicious attack";
            sb.Append(m1);
            sb.Append("\n");
            sb.Append(this.Name + m2);
            sb.Append("\n");
            sb.Append(target.Name + m3);

            UILineManager.PrintLine(m1);
            this.Attack = Attack / 2;
            for (int i = 0; i < 3; i++)
            {
                attack(target, m2);
            }
            this.Attack = Attack * 2;
            target.takeDamage(this.Attack, m3);
            Processor.Player.CurrentEnergy = Processor.Player.CurrentEnergy / 2;

            return sb.ToString();
        }
    }
}
