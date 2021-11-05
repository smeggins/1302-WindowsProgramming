using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoomSlayer9000OmegaForce1
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
        public override int attack(IActor target, string attackMessage)
        {
            Console.WriteLine(_Name + attackMessage);
            if (target.defend(_Attack) == false)
            {
                target.missAttack(Dialogue.Instance.getRandomMissMsg());
                return 0;
            }
            else
            {
                _CurrentEnergy += 1;
                target.takeDamage(_Attack, Dialogue.Instance.getRandomHitMsg());
                return _Attack;
            }
            
        }

        public override bool defend(int attack)
        {
            int rn = _RNG.Next(1, 100);

            if (attack != (this._Attack * 2))
            {
                return (rn >= this._Defence) ? true : false;
            }
            else
            {
                return (rn >= (this._Defence / 2)) ? true : false;
            }
        }

        public override void die(string deathMessage)
        {
            Console.WriteLine(_Name + deathMessage);
        }

        public override void makeCamp()
        {
            Console.Clear();
            Console.WriteLine("How many Hours Would you Like to Rest: (0-24)");
            Console.WriteLine("24 hours fully heals you from 1 health, energy depletes while resting.\n\n");
            
            Console.Write("How many Hours Would you Like to Rest (0-24): ");
            int restTime;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out restTime))
                {
                    break;
                }
                Console.WriteLine("Not a valid entry. Please enter a number between 1 and 24");
            }
            
            if (restTime > 0)
            {
                int lifeGain = (_TotalHealth / _RegenRate) * restTime;
                int energyLost = (_TotalEnergy / 24) * restTime;

                Console.WriteLine($"Ok, you rest for {restTime} hours.");
                Thread.Sleep(1000);
                Console.Clear();
                Console.Write("                   ");
                for (int i = 0; i < 4; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write("Z");
                }
                Thread.Sleep(1000);
                Console.Write("z");
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine("\n\nYou Wake up feeling rested and ready for battle!");
                _CurrentHealth += lifeGain;
                Console.WriteLine($"\nNew Health: {_CurrentHealth}  Gained {lifeGain}!");
                _CurrentEnergy += energyLost;
                Console.WriteLine($"New Energy: {_CurrentEnergy}  Lost {energyLost}...");
            }
            else
            {
                Console.WriteLine($"Rest is for the Weak. Onwards and upwards!");
            }



            // how many hours do you want to rest
            // currenthp += hours * totalhp/regen 
            // currentener -= hour * totalener/regen*2
            // log your rested
        }

        public void level()
        {
            Console.Clear();
            //Console.WriteLine("******************************************|******************************************");
            this._Level += 1;
            Console.WriteLine("\n\n*************************************************************************************");
            Console.WriteLine("***** You've battled your way a little closer to the top of MEGA DEATH MOUNTAIN *****");
            Console.WriteLine("*************************************************************************************");
            Console.WriteLine($"************************************** Level {_Level} **************************************");

            if (_Level%2 == 0 || _Level%3 == 0)
            {
                _TotalHealth += 10;
                _CurrentHealth += 10;

                Console.Write($"****************************** ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("New");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" Total Health: {_TotalHealth} *******************************");
            }
            else
            {
                _Defence += 1;
                

                Console.Write($"****************************)** ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("New");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" Defence: {_Defence} + {10} *****************************");
            }
            Console.WriteLine("\n*************************************************************************************");
        }

        public override void missAttack(string missMessage)
        {            
            Console.WriteLine(_Name + missMessage);
        }

        public override void specialAttack(IActor target)
        {
            Console.WriteLine("Get absolutely fuckerd");
            target.takeDamage(this._Attack * 3, Dialogue.Instance.getRandomHitMsg());
        }
    }
}
