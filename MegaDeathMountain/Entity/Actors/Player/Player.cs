using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoomSlayer9000OmegaForce1;

namespace DoomSlayer9000OmegaForce1
{
    

    public abstract class Player : Actor
    {
        public int _TotalEnergy;
        public int _RegenRate;
        public int currentEnergy;
        public int _CurrentEnergy
        {
            get { return currentEnergy; }
            set
            {
                if ((currentEnergy + value) > 0)
                {
                    currentEnergy = ((currentEnergy + value) < _TotalEnergy) ? (currentEnergy + value) : _TotalEnergy;
                }
                else
                {
                    currentEnergy = 0;
                }
            }
        }

        public Player(string name, int regenRate, int defense, int attack) : base(name, defense, attack) { _TotalEnergy = 10; _RegenRate = regenRate; }

        public abstract void makeCamp();
    }

    
}
enum PlayerClass
{
    Beast,
    Knight,
    Priest
}