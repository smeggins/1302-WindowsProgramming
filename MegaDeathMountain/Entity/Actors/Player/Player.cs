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
        public int TotalEnergy;
        public int RegenRate;
        private int currentEnergy;
        public int CurrentEnergy
        {
            get { return currentEnergy; }
            set
            {
                if ((currentEnergy + value) > 0)
                {
                    currentEnergy = ((currentEnergy + value) < TotalEnergy) ? (currentEnergy + value) : TotalEnergy;
                }
                else
                {
                    currentEnergy = 0;
                }
            }
        }

        public Player(string name, int regenRate, int defense, int attack, ILogger logger) : base(name, defense, attack, logger, (ConsoleColor.Green, 'O')) { TotalEnergy = 10; RegenRate = regenRate; }

        public override int attack(IActor target, string attackMessage)
        {
            UILineManager.PrintLine(Name + attackMessage);
            if (target.dodge(Attack) == false)
            {
                target.missAttack(Dialogue.Instance.getRandomMissMsg());
                return 0;
            }
            else
            {
                CurrentEnergy += 1;
                target.takeDamage(Attack, Dialogue.Instance.getRandomHitMsg());
                return Attack;
            }

        }

        public void Defend()
        {
            this.Defending = true;
            UILineManager.PrintLine(this.Name + Dialogue.Instance.getRandomDefendMsg());
        }

        public void makeCamp()
        {
            Console.Clear();
            if (this.CurrentHealth != this.TotalHealth)
            {
                UILineManager.PrintLine("How many Hours Would you Like to Rest: (0-24)");
                UILineManager.PrintLine("24 hours fully heals you from 1 health, energy depletes while resting.\n\n");

                UILineManager.PrintChars("How many Hours Would you Like to Rest (0-24): ");
                int restTime;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out restTime))
                    {
                        break;
                    }
                    UILineManager.PrintLine("Not a valid entry. Please enter a number between 1 and 24");
                }

                if (restTime > 0)
                {
                    int lifeGain = (TotalHealth / RegenRate) * restTime;
                    int energyLost = (TotalEnergy / 24) * restTime;

                    UILineManager.PrintLine($"Ok, you rest for {restTime} hours.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    UILineManager.PrintChars("                   ");
                    for (int i = 0; i < 4; i++)
                    {
                        Thread.Sleep(1000);
                        UILineManager.PrintChars("Z");
                    }
                    Thread.Sleep(1000);
                    UILineManager.PrintChars("z");
                    Thread.Sleep(1000);
                    Console.Clear();

                    // clears console buffer
                    UILineManager.clearConsoleBuffer();

                    UILineManager.PrintLine("\n\nYou Wake up feeling rested and ready for battle!");
                    CurrentHealth += lifeGain;
                    UILineManager.PrintLine($"\nNew Health: {CurrentHealth}  Gained {lifeGain}!");
                    CurrentEnergy = CurrentEnergy + energyLost;
                    UILineManager.PrintLine($"New Energy: {CurrentEnergy}  Lost {energyLost}...");
                    return;
                }
                else
                {
                    UILineManager.PrintLine($"Rest is for the Weak. Onwards and upwards!");
                }
            }
            
            UILineManager.PrintLine($"Having taken no damage you decide to continue acending MEGA DEATH MOUNTAIN!");
        }

        public void level()
        {
            Console.Clear();
            this.Level += 1;
            UILineManager.SkipLine(2);
            UILineManager.DrawMenuLine();
            UILineManager.DrawMenuLine(" You've battled your way a little closer to the top of MEGA DEATH MOUNTAIN ");
            UILineManager.DrawMenuLine();
            UILineManager.DrawMenuLine((ConsoleColor.Blue, $" Level {Level} "));

            if (Level % 2 == 0 || Level % 3 == 0)
            {
                TotalHealth += 10;
                CurrentHealth += 10;

                UILineManager.DrawMenuLine(new List<(ConsoleColor, string)>() { (ConsoleColor.DarkYellow, " New "), (ConsoleColor.White, $" Total Health: {TotalHealth} ") });
            }
            else
            {
                Defence += 1;

                UILineManager.DrawMenuLine(new List<(ConsoleColor, string)>() { (ConsoleColor.DarkYellow, " New "), (ConsoleColor.White, $" Defence: {Defence} ") });
            }
            UILineManager.DrawMenuLine();
        }
    }
}
enum PlayerClass
{
    Beast,
    Knight,
    Priest
}