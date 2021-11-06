using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MegaDeathMountain
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

        public void makeCamp()
        {
            Console.Clear();
            if (this._CurrentHealth != this._TotalHealth)
            {
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

                    // clears console buffer
                    Game.clearConsoleBuffer();

                    Console.WriteLine("\n\nYou Wake up feeling rested and ready for battle!");
                    _CurrentHealth += lifeGain;
                    Console.WriteLine($"\nNew Health: {_CurrentHealth}  Gained {lifeGain}!");
                    _CurrentEnergy += energyLost;
                    Console.WriteLine($"New Energy: {_CurrentEnergy}  Lost {energyLost}...");
                    return;
                }
                else
                {
                    Console.WriteLine($"Rest is for the Weak. Onwards and upwards!");
                }
            }
            
            Console.WriteLine($"Having taken no damage you decide to continue acending MEGA DEATH MOUNTAIN!");
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

            if (_Level % 2 == 0 || _Level % 3 == 0)
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
    }
}
enum PlayerClass
{
    Beast,
    Knight,
    Priest
}